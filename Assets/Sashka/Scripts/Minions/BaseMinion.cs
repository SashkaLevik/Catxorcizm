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
        [SerializeField] protected float _speed;
        [SerializeField] protected int _fireDelay;        

        private void Update()
            => Move();

        public void Init(BaseEnemy enemy)
            => _enemy = enemy;                

        private void Move()
            => transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}