using System;
using Assets.Sashka.Scripts.Enemyes;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Tower;
using UnityEngine;

namespace CodeBase.Player
{
    public class HeroAttack : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private int _meleeDamage;
        [SerializeField] private float _attackAngle;
        [SerializeField] private float _attackRate;
        [SerializeField] private Transform _meleeAttack;
        [SerializeField] private Vector2 _sizeMeleeAttack;
        [SerializeField] private LayerMask _layerMask;

        private State _state;
        private float _distance;

        public int MeleeDamage
        {
            get => _state.MeleeAttack;
            set => _state.MeleeAttack = value;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _state = progress.HeroState;
            _meleeDamage = _state.MeleeAttack;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out BaseEnemy enemy))
            {
                _attackRate -= Time.deltaTime;

                if (_attackRate <= 0)
                {
                    enemy.GetComponent<EnemyHealth>().Died += SetAttack;
                    _attackRate = 4;
                    
                    OnAttack();
                }
            }
        }

        private void SetAttack(BaseEnemy enemy)
        {
            enemy.GetComponent<EnemyHealth>().Died -= SetAttack;
        }

        private void OnAttack()
        {
            foreach (Collider2D enemy in Hit(_meleeAttack, _sizeMeleeAttack))
            {
                enemy.GetComponent<IHealth>().TakeDamage(_state.MeleeAttack);
            }
        }

        private Collider2D[] Hit(Transform attack, Vector2 sizeAttack)
        {
            return Physics2D.OverlapBoxAll(attack.position, sizeAttack, _attackAngle, _layerMask);
        }

        private void OnDrawGizmosSelected()
        {
            if (_meleeAttack == null)
                return;

            Gizmos.DrawWireCube(_meleeAttack.transform.position, _sizeMeleeAttack);
        }
    }
}