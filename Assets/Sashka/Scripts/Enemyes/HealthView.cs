using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private HPBar _hpBar;
        [SerializeField] private EnemyHealth _enemyHealth;

        private void OnEnable()
        {
            _enemyHealth.HealthChanged += UpdateHPBar;
        }

        private void OnDestroy()
        {
            _enemyHealth.HealthChanged -= UpdateHPBar;
        }

        private void UpdateHPBar()
        {
            _hpBar.SetValue(_enemyHealth.Current, _enemyHealth.Max);
        }
    }
}
