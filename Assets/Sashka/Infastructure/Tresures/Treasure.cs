using TMPro;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class Treasure : MonoBehaviour
    {
        [SerializeField] private ItemData _itemData;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private GameObject _description;

        private void Awake()
        {
            _descriptionText.text = _itemData.Description;
        }        

        public ItemData ItemData => _itemData;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out InventoryHolder inventory))
            {
                Debug.Log("AddToInv");

                if (inventory.Inventory.AddItem(ItemData))
                {
                    Debug.Log("Added");
                }                
            }            
        }

        private void OnMouseEnter()
        {
            _description.SetActive(true);
        }

        private void OnMouseExit()
        {
            _description.SetActive(false);
        }
    }
}
