using System;
using System.Collections;
using Assets.Sashka.Scripts.Minions;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Player;
using CodeBase.Tower;
using CodeBase.UI.Forms;
using UnityEngine;

namespace CodeBase.UI.Element
{
    public class DraggableItem : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _timeDragTrigger;

        private BaseMinion _minion;
        private Camera _camera;
        private Vector3 _prefMousePosition;
        private Vector3 _mouseDelta;
        private Vector3 _selectedItemStartPosition;
        private RaycastHit2D _currentHit;

        private Transform _selected;
        private bool _dragTrigger;
        private bool _isDragEntity;
        private UpgradeMinions _panel;
        private TowerSpawner _selectSpawner;
        private TowerSpawner _currentSpawner;
        private TowerStaticData _data;
        private Inventory _playerInventory;

        public void Construct(UpgradeMinions panel, Inventory inventory)
        {
            _panel = panel;
            _playerInventory = inventory;
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            var currentMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0;
            _mouseDelta = currentMousePosition - _prefMousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 clickPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero, Single.PositiveInfinity, _layerMask);
                _currentHit = hit;

                if (hit.collider != null)
                {
                    if (hit.transform.TryGetComponent(out MinionHealth minionHealth))
                    {
                        _minion = hit.collider.GetComponent<BaseMinion>();
                        _selected = hit.transform;
                        _currentSpawner = hit.transform.parent.GetComponent<TowerSpawner>();
                        _data = hit.transform.parent.GetComponent<TowerSpawner>().Data;
                        _playerInventory.CurrentData(_data);
                        _playerInventory.SetSpawnPosition(_currentSpawner);
                        
                        _selectedItemStartPosition = _selected.transform.position;
                        hit.transform.GetComponent<Collider2D>().enabled = false;
                        StartCoroutine(DragTrigger());
                        Debug.Log(hit.transform.name);
                    }
                }
            }

            if (_selected != null)
            {
                if (_isDragEntity)
                {
                    _selected.position += new Vector3(_mouseDelta.x, _mouseDelta.y, 0);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_selected != null)
                {
                    _isDragEntity = true;
                    if (_dragTrigger)
                    {
                        Vector2 clickPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                        RaycastHit2D[] hitInfo = Physics2D.RaycastAll(clickPosition, Vector2.zero);
                        bool isTowerSpawner = false;
                        RaycastHit2D currentHit = new RaycastHit2D();
                
                        foreach (RaycastHit2D hit2D in hitInfo)
                        {
                            Debug.Log(hit2D.collider.name + " collider Tower");
                
                            if (hit2D.collider.TryGetComponent(out TowerSpawner spawner))
                            {
                                if (!spawner.CreateTower)
                                {
                                    isTowerSpawner = true;
                                    currentHit = hit2D;
                                    Debug.Log(hit2D.collider.name + "  collider Shift");
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
                        _panel.PanelMinions.SetItemIcon(_minion);
                        _panel.UpgradeData(_data);
                        _panel.ShowMinions(_data);
                        _panel.MaxLevelMinions(_data);
                    }
                }
            }

            _prefMousePosition = currentMousePosition;
        }

        private IEnumerator DragTrigger()
        {
            _dragTrigger = false;
            yield return new WaitForSeconds(_timeDragTrigger);
            _dragTrigger = true;
            _isDragEntity = true;
        }

        private void ReturnToCurrentPosition()
        {
            _currentHit.transform.localPosition = Vector3.zero;
            _currentHit.transform.GetComponent<Collider2D>().enabled = true;
            _selected = null;
        }

        private void NewPosition(RaycastHit2D hitInfo)
        {
            Debug.Log(hitInfo.collider.transform.name);
            _selected.SetParent(hitInfo.collider.transform, true);
            _selected.transform.localPosition = Vector3.zero;
            _currentHit.transform.GetComponent<Collider2D>().enabled = true;
            _selected = null;
            _currentSpawner.IsCreateTower();
            _selectSpawner = hitInfo.collider.transform.GetComponent<TowerSpawner>();
            _selectSpawner.IsCreateTower();
            _selectSpawner.ChildMinion(_currentSpawner);
            _currentSpawner.ObjectOffset();
            Debug.Log("NewPos");
        }
    }
}