using Assets.Sashka.Scripts.Minions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sashka.Infastructure.Tresures
{
    class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private bool _isButtonReleased;
        private Vector3 _startPosition;
        private Vector3 _offset;
        private Camera _camera;
        private Vector3 _mousePosition;
        private Vector3 _screenPosition;
        private Treasure treasure;

        public Vector3 StartPosition => _startPosition;

        private void Awake() 
            => _camera = Camera.main;

        private void Start()
        {
            _startPosition = transform.position;
            treasure = GetComponent<Treasure>();
        }           

        private void OnMouseDown()
        {
            _offset = transform.position - GetMousePosition();
            _isButtonReleased = false;
        }
           

        private void OnMouseDrag() 
            => transform.position = GetMousePosition() + _offset;

        private void OnMouseUp()
        {
            _isButtonReleased = true;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_isButtonReleased && collision.TryGetComponent(out BaseMinion baseMinion))
            {
                Debug.Log("minion");
            }
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

        public void OnBeginDrag(PointerEventData eventData)
        {
            _offset = transform.position - (Vector3)eventData.position;
            _offset.z = 0;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var dragPosition = (Vector3)eventData.position;
            dragPosition.z = 0;
            transform.position = dragPosition + _offset;
        }


        public void OnEndDrag(PointerEventData eventData)
        {
            transform.position = new Vector3();
        }
    }
}
//private void Update()
//{
//    if (_isDragActive && (Input.GetMouseButtonDown(0)) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
//    {
//        Drop();
//        return;
//    }
//    if (Input.GetMouseButton(0))
//    {
//        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
//        _mousePosition.z = 0;
//    }
//    else if (Input.touchCount > 0)
//    {
//        _mousePosition = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
//        _mousePosition.z = 0;
//    }
//    else
//        return;

//    if (_isDragActive)
//        Drag();
//    else
//    {
//        RaycastHit2D hit = Physics2D.Raycast()
//    }

//}

//private void Drag()
//{
//    throw new NotImplementedException();
//}

//private void Drop()
//{
//    throw new NotImplementedException();
//}