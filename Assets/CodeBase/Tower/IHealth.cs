using UnityEngine.Events;

namespace CodeBase.Tower
{
    public interface IHealth
    {
        event UnityAction HealthChanged;
        float Current { get; set; }
        float Max { get; set; }
        void TakeDamage(int damage);
    }
}