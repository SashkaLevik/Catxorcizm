﻿using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "TowerData", menuName = "StaticData/Tower")]
    public class TowerStaticData : ScriptableObject
    {
        [Range(1, 50)] public int Damage;
        [Range(1f, 10f)] public float AttackRange;
        [Range(1f, 3f)] public float Cooldown;
    
        public Sprite UIIcon;
        public int Price;
        public GameObject Prefab;

        public TowerTypeID TowerTypeID;
    }
}