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
        [SerializeField] private int _meleeDamage;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Transform _meleeAttack;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _attackAngle;
        [SerializeField] private Vector2 _sizeMeleeAttack;
        [SerializeField] private float _spellSpeed;
        [SerializeField] private Transform _spawnPointFireBoll;
        [SerializeField] private FireBoll _prefabFireBoll;
        [SerializeField] private AttackTrigger _attackTrigger;
        
        private Stats _stats;
        private WaitForSeconds _rechargeMeleeAttack, _rechargeMagicAttack;
        private float _distance;
        private bool _onAttack;

        private void OnEnable()
        {
            _rechargeMeleeAttack = new WaitForSeconds(_attackSpeed);
            _rechargeMagicAttack = new WaitForSeconds(_spellSpeed);
            _attackTrigger.AttackZoneEntered += Attacking;
        }

        private void OnDestroy()
        {
            _attackTrigger.AttackZoneEntered -= Attacking;
        }

        private void Attacking(BaseEnemy baseEnemy)
        {
            _onAttack = true;

            StartCoroutine(Attack(baseEnemy));
        }

        private IEnumerator Attack(BaseEnemy enemy)
        {
            while (enemy != null)
            {
                while (_onAttack)
                {
                    enemy.GetComponent<EnemyHealth>().Died += SetAttack;
                    _distance = Vector2.Distance(transform.position, enemy.transform.position);

                    if (_distance >= 2f)
                    {
                        FireBoll fireBoll = Instantiate(_prefabFireBoll, _spawnPointFireBoll);
                        fireBoll.Init(enemy);
                        Debug.Log("hitRange");
                        yield return _rechargeMagicAttack;
                    }
                    else
                    {
                        OnAttack();

                        Debug.Log("Hit");
                        yield return _rechargeMeleeAttack;
                    }
                }
            }
        }

        private void SetAttack(BaseEnemy enemy)
        {
            _onAttack = false;
            enemy.GetComponent<EnemyHealth>().Died -= SetAttack;
        }

        private void OnAttack()
        {
            foreach (Collider2D enemy in Hit(_meleeAttack, _sizeMeleeAttack))
            {
                enemy.GetComponent<IHealth>().TakeDamage(_meleeDamage);
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