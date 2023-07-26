using Assets.Sashka.Scripts.Enemyes;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions
{
    public class MinionHealthView : MonoBehaviour
    {
        [SerializeField] private HPBar _hpBar;
        [SerializeField] private MinionHealth _health;

        private void OnEnable()
        {
            _health.HealthChanged += UpdateHPBar;
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= UpdateHPBar;
        }

        private void UpdateHPBar()
        {
            _hpBar.SetValue(_health.Current, _health.Max);
        }
    }
}
