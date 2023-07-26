using Assets.Sashka.Scripts.Minions;
using TMPro;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class Treasure : MonoBehaviour
    {
        [SerializeField] private ItemData _itemData;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private GameObject _description;
        [SerializeField] private TreasureSpawner _treasureSpawner;

        public ItemData ItemData => _itemData;

        public TreasureSpawner TreasureSpawner => _treasureSpawner;

        private void Start()
            => _treasureSpawner = GetComponentInParent<TreasureSpawner>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BaseMinion minion))
            {
                Debug.Log("Minion");
            }           
        }

        private void OnMouseEnter()
            => _description.SetActive(true);

        private void OnMouseExit()
            => _description.SetActive(false);
    }
}
