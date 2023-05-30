using System;
using Assets.Sashka.Scripts.Enemyes;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase.UI.Element
{
    public class ActionUI : MonoBehaviour
    {
        public HPBar HpBar;
        private HeroHealth _heroHealth;

        private void OnDestroy() => 
            _heroHealth.HealthChanged -= UpdateHpBar;

        public void Construct(HeroHealth heroHealth)
        {
            _heroHealth = heroHealth;

            _heroHealth.HealthChanged += UpdateHpBar;
        }

        private void UpdateHpBar() => 
            HpBar.SetValue(_heroHealth.Current, _heroHealth.Max);
    }
}