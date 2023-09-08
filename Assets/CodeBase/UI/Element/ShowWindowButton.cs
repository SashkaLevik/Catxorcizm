using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.Element
{
    public class ShowWindowButton : MonoBehaviour
    {
        [SerializeField] private List<OpenWindowButton> _buttons;
        
        private void Update()
        {
            foreach (OpenWindowButton windowButton in _buttons)
            {
                windowButton.gameObject.SetActive(!windowButton.TowerSpawner.IsTowerCreated);
            }
        }
    }
}