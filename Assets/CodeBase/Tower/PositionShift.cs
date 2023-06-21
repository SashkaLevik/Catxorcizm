using System.Collections;
using Assets.Sashka.Scripts.Minions;
using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Forms;
using UnityEngine;

namespace CodeBase.Tower
{
    public class PositionShift : MonoBehaviour
    {
        [SerializeField] private float _timeDragTrigger;

        private Camera _camera;
        private Vector3 _offset;
        private Transform _currentPosition;
        private TowerSpawner _selectSpawner;
        private TowerSpawner _currentSpawner;
        private bool _dragTrigger = true;
        private UpgradeWindow _panel;
        private TowerTypeID _typeID;
        private bool _isDragEntity;

        private void Start()
        {
            _currentPosition = transform.parent;
            _selectSpawner = _currentPosition.GetComponent<TowerSpawner>();
            _currentSpawner = _selectSpawner;
            _camera = Camera.main;
        }

        public void Construct(UpgradeWindow panel, TowerTypeID typeID)
        {
            _panel = panel;
            _typeID = typeID;
        }

        public void OnMouseDown()
        {
            var rayOrigin = _camera.transform.position;
            var rayDirection = GetMouseWorldPosition() - rayOrigin;
            
            RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);

            Debug.Log(hitInfo + " ap");

            if (hitInfo.collider.gameObject.TryGetComponent(out MinionHealth minion))
            {
                print(hitInfo.collider.gameObject + " взял коллайдер");
                transform.GetComponent<Collider2D>().enabled = false;
                StartCoroutine(DragTrigger());
            }
        }

        private IEnumerator DragTrigger()
        {
            _dragTrigger = false;
            yield return new WaitForSeconds(_timeDragTrigger);
            _dragTrigger = true;
            _isDragEntity = true;
            
        }

        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = _camera.WorldToScreenPoint(transform.position).z;
            return _camera.ScreenToWorldPoint(mouseScreenPos);
        }

        private void OnMouseDrag()
        {
            if (_isDragEntity)
            {
                transform.position = GetMouseWorldPosition() + _offset;
            }
        }

        private void OnMouseUp()
        {
            _isDragEntity = false;
            if (_dragTrigger)
            {
                var rayOrigin = _camera.transform.position;
                var rayDirection = GetMouseWorldPosition() - rayOrigin;
        
                RaycastHit2D[] hitInfo = Physics2D.RaycastAll(rayOrigin, rayDirection);
                bool isTowerSpawner = false;
                RaycastHit2D currentHit = new RaycastHit2D();
        
                foreach (RaycastHit2D hit2D in hitInfo)
                {
                    if (hit2D.collider.TryGetComponent(out TowerSpawner spawner))
                    {
                        if (!spawner.CreateTower)
                        {
                            isTowerSpawner = true;
                            currentHit = hit2D;
                        }
                    }
                }
        
                if (isTowerSpawner == true)
                {
                    NewPosition(currentHit);
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
                _panel.ShowMinions(_typeID);
                _panel.MaxLevelMinions();
            }
        }

        private void ReturnToCurrentPosition()
        {
            transform.localPosition = Vector3.zero;
            transform.GetComponent<Collider2D>().enabled = true;
        }

        private void NewPosition(RaycastHit2D hitInfo)
        {
            _currentSpawner = _currentPosition.GetComponent<TowerSpawner>();
            transform.parent = hitInfo.collider.transform;
            _selectSpawner.IsCreateTower();

            _currentPosition = transform.parent;
            ReturnToCurrentPosition();
            _selectSpawner = _currentPosition.GetComponent<TowerSpawner>();
            _selectSpawner.IsCreateTower();
            _selectSpawner.ChildMinion(_currentSpawner);
            _currentSpawner.ObjectOffset();
            
        }
    }
}