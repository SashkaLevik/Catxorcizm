using Assets.Sashka.Infastructure.Tresures;
using Assets.Sashka.Scripts.Enemyes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions
{
    public class BaseMinion : MonoBehaviour
    {        
        [SerializeField] protected Transform _firePos;
        [SerializeField] protected BaseEnemy _enemy;
        [SerializeField] protected int _fireDelay;
        [SerializeField] protected Inventory _inventory;

        public void Init(BaseEnemy enemy)
            => _enemy = enemy;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Treasure treasure))
            {
                _inventory.AddItem(treasure);
                Debug.Log("Added" + treasure.name);
            }
        }
    }
}