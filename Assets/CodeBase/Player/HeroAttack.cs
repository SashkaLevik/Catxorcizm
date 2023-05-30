using System;
using System.Collections;
using Assets.Sashka.Scripts.Enemyes;
using Assets.Sashka.Scripts.Minions;
using CodeBase.Data;
using CodeBase.Tower;
using UnityEngine;

namespace CodeBase.Player
{
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Transform _attackPosition;
        [SerializeField] private float _attackRate;
        [SerializeField] private float _attackRanged;
        [SerializeField] private Vector2 _attackRange;

        private BaseEnemy _enemy;
        private Stats _stats;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out _enemy))
            {
                Debug.Log(_enemy);
                StartCoroutine(Attack());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            
        }
        
        private IEnumerator Attack()
        {
            while (_enemy != null)
            {
                OnAttack();

                Debug.Log("Hit");
                yield return new WaitForSeconds(_attackRate);
            }
        }
        
        private void OnAttack()
        {
            foreach (Collider2D enemy in Hit())
            {
                enemy.GetComponent<IHealth>().TakeDamage(_damage);
            }
        }

        private Collider2D[] Hit()
        {
            return Physics2D.OverlapCircleAll(_attackPosition.position, _attackRanged, _layerMask);
            //Physics2D.OverlapBoxAll(_attackPosition.position, _attackRange, _layerMask);
        }

        private void OnDrawGizmosSelected()
        {
            if (_attackPosition == null)
                return;
            
            Gizmos.DrawWireSphere(_attackPosition.transform.position, _attackRanged);
            //Gizmos.DrawWireCube(_attackPosition.transform.position, _attackRange);
        }
    }
}