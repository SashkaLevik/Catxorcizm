using Assets.Sashka.Scripts.Minions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sashka.Infastructure.Tresures
{
    class DragAndDrop : MonoBehaviour
    {
        private Vector3 _startPosition;
        private Vector3 _offset;
        private Camera _camera;
        private Vector3 _mousePosition;

        public Vector3 StartPosition => _startPosition;

        private void Awake() 
            => _camera = Camera.main;

        private void Start()
        {
            _startPosition = transform.position;
        }        

        private void OnMouseDown()
        {
            _offset = transform.position - GetMousePosition();

            var rayOrigin = _camera.transform.position;
            var rayDirection = GetMousePosition() - rayOrigin;

            RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);
            transform.GetComponent<Collider2D>().enabled = false;

            Debug.Log(hitInfo.collider.name);
        }
           
        private void OnMouseDrag() 
            => transform.position = GetMousePosition() + _offset;

        private void OnMouseUp()
        {
            transform.GetComponent<Collider2D>().enabled = true;

            var rayOrigin = _camera.transform.position;
            var rayDirection = GetMousePosition() - rayOrigin;

            RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);
            Debug.Log(hitInfo.collider.name);

            if (hitInfo.collider.gameObject.TryGetComponent(out BaseMinion minion))
            {
                Debug.Log(minion.name);
            }
            else
            {
                transform.position = _startPosition;
            }     
        }        

        private Vector3 GetMousePosition()
        {
            if (Input.GetMouseButton(0))
            {
                _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                _mousePosition.z = 0;                
            }            
            return _mousePosition;
        }        
    }
}
