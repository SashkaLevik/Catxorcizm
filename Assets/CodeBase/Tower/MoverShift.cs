using System.Collections;
using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Forms;
using UnityEngine;

namespace CodeBase.Tower
{
    public class MoverShift : MonoBehaviour
    {
        [SerializeField] private float _timeDragTrigger;
        [SerializeField] private UpgradeWindow _panel;
        
        private PositionShift _positionShift;
        private bool _dragTrigger;
        private TowerTypeID _typeID;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ButtonDown();
            }

            if (Input.GetMouseButton(0) && _dragTrigger == true)
            {
                //метод такскания
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_dragTrigger == true)
                {
                    NewPosition();
                }
                else
                {
                    OpenPanelUpgrade();
                }
            }
        }
        
        private IEnumerator DragTrigger()
        {
            _dragTrigger = false;
            yield return new WaitForSeconds(_timeDragTrigger);
            _dragTrigger = true;
        }
        
        private void OpenPanelUpgrade()
        {
            transform.localPosition = Vector3.zero;
            _panel.gameObject.SetActive(true);
            _panel.UpgradeData(_typeID);
            _panel.MaxLevelMinions();
        }

        private void ButtonDown()
        {
            var rayOrigin = Camera.main.transform.position;
            var rayDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            RaycastHit2D[] hitInfo = Physics2D.RaycastAll(rayOrigin, rayDirection);

            foreach (RaycastHit2D hit2D in hitInfo)
            {
                if (hit2D.collider.TryGetComponent(out PositionShift component))
                {
                    _positionShift = component;
                }
            }
            
            if (_positionShift == null)
            {
                StartCoroutine(DragTrigger());
            }
        }
        
        private void NewPosition()
        {
            RaycastHit2D currentHit = new RaycastHit2D();
            transform.parent = currentHit.collider.transform;
            _positionShift.GetComponent<TowerSpawner>().IsCreateTower();

            //_currentPosition = transform.parent;
            transform.localPosition = Vector3.zero;
            transform.parent.GetComponent<TowerSpawner>().IsCreateTower();
        }
    }
}