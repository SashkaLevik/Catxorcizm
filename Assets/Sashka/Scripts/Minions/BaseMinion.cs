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

        public void Init(BaseEnemy enemy)
            => _enemy = enemy;                        
    }
}