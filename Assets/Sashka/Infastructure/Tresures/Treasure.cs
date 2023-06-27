﻿using Assets.Sashka.Scripts.Minions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class Treasure : MonoBehaviour
    {
        [SerializeField] private Sprite _icon;

        public Sprite Icon => _icon;
    }
}
