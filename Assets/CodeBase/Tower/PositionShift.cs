using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Tower
{
    public class PositionShift : MonoBehaviour
    {
        private Vector3 _offset;

        public void OnMouseDown()
        {
            _offset = gameObject.transform.position - GetMouseWorldPosition();
            transform.GetComponent<Collider>().enabled = false;
        }

        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
            return Camera.main.ScreenToWorldPoint(mouseScreenPos);
        }

        private void OnMouseDrag()
        {
            transform.position = GetMouseWorldPosition() + _offset;
        }

        private void OnMouseUp()
        {
            var rayOrigin = Camera.main.transform.position;
            var rayDirection = GetMouseWorldPosition() - rayOrigin;

            RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);
            
            //Debug.Log(hitInfo.collider.GetComponentInChildren<TowerSpawner>().CreateTower);
            
            Debug.Log(hitInfo.collider);

            if (hitInfo.collider)
            {
                if (!hitInfo.collider.GetComponentInChildren<TowerSpawner>().CreateTower)
                {
                    transform.parent = hitInfo.collider.transform;
                    transform.localPosition = Vector3.zero;
                    transform.GetComponent<Collider>().enabled = true;
                }
                else
                {
                    transform.localPosition = Vector3.zero;
                    transform.GetComponent<Collider>().enabled = true;
                }
            }
            else
            {
                transform.localPosition = Vector3.zero;
                transform.GetComponent<Collider>().enabled = true;
            }
        }
    }
}
