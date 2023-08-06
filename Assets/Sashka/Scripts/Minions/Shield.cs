using UnityEngine;

namespace Assets.Sashka.Scripts.Minions
{
    public class Shield : MonoBehaviour
    {
        private const string Protect = "Protect";
        private Animator _animator;

        private void Start()
            => _animator = GetComponent<Animator>();

        public void ActivateProtect()
            => _animator.SetTrigger(Protect);
    }
}
