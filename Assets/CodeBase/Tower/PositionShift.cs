using System;
using System.Collections;
using Assets.Sashka.Scripts.Minions;
using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Forms;
using CodeBase.UI.Service.Windows;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Tower
{
    public class PositionShift : MonoBehaviour
    {
        [SerializeField] private Transform _attackTrigger;
        [SerializeField] private float _timeDragTrigger;
        
        private Vector3 _offset;
        private Transform _currentPosition;
        private bool _dragTrigger = true;
        private UpgradeWindow _panel;
        private TowerTypeID _typeID;

        private void Start()
        {
            _currentPosition = transform.parent;
        }

        public void Construct(UpgradeWindow panel, TowerTypeID typeID)
        {
            _panel = panel;
            _typeID = typeID;
        }

        public void OnMouseDown()
        {
            _offset = gameObject.transform.position - GetMouseWorldPosition();
            transform.GetComponent<Collider2D>().enabled = false;
            _attackTrigger.GetComponentInChildren<Collider2D>().enabled = false;
            StartCoroutine(DragTrigger());
        }

        private IEnumerator DragTrigger()
        {
            _dragTrigger = false;
            yield return new WaitForSeconds(_timeDragTrigger);
            _dragTrigger = true;
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
            if (_dragTrigger)
            {
                var rayOrigin = Camera.main.transform.position;
                var rayDirection = GetMouseWorldPosition() - rayOrigin;

                RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);

                Debug.Log(hitInfo.collider);

                if (hitInfo.collider)
                {
                    if (!hitInfo.collider.GetComponent<TowerSpawner>().CreateTower)
                    {
                        NewPosition(hitInfo);
                    }
                    else
                    {
                        ReturnToCurrentPosition();
                    }
                }
                else
                {
                    ReturnToCurrentPosition();
                }
            }
            else
            {
                ReturnToCurrentPosition();
                _panel.gameObject.SetActive(true);
                _panel.UpgradeData(_typeID);
                _panel.MaxLevelMinions();
            }
        }

        private void ReturnToCurrentPosition()
        {
            transform.localPosition = Vector3.zero;
            transform.GetComponent<Collider2D>().enabled = true;
            _attackTrigger.GetComponentInChildren<Collider2D>().enabled = true;
        }

        private void NewPosition(RaycastHit2D hitInfo)
        {
            transform.parent = hitInfo.collider.transform;
            _currentPosition.GetComponent<TowerSpawner>().IsCreateTower();

            _currentPosition = transform.parent;
            ReturnToCurrentPosition();
            transform.parent.GetComponent<TowerSpawner>().IsCreateTower();
        }
    }
}
