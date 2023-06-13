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
        private bool _isCorrectDrop;
        private bool _isDroped;        
        private Vector3 _startPosition;
        private Vector3 _offset;
        private Camera _camera;
        private Vector3 _mousePosition;
        private Vector3 _screenPosition;

        public Vector3 StartPosition => _startPosition;

        private void Awake() 
            => _camera = Camera.main;

        private void Start()
        {
            _isDroped = false;
            _startPosition = transform.position;
        }        

        private void OnMouseDown()
        {
            _offset = transform.position - GetMousePosition();
            _isDroped = false;
        }
           
        private void OnMouseDrag() 
            => transform.position = GetMousePosition() + _offset;

        private void OnMouseUp()
        {
            _isDroped = true;           
            if(_isCorrectDrop == false) { StartCoroutine(Return()); }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_isDroped)
            {
                if (collision.TryGetComponent(out BaseMinion minion))
                {
                    Debug.Log(minion);
                    _isCorrectDrop = true;
                }                
            }
        }

        private IEnumerator Return()
        {
            yield return new WaitForSeconds(0.2f);
            transform.position = _startPosition;
        }

        private Vector3 GetMousePosition()
        {
            if (Input.GetMouseButton(0))
            {
                _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                _mousePosition.z = 0;                
            }
            else if (Input.touchCount > 0)
            {
                _screenPosition = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
                _screenPosition.z = 0;
            }
            return _mousePosition;
        }        
    }
}
