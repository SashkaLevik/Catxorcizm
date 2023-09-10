using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using UnityEngine;

namespace Assets.CodeBase.Player
{
    public class PlayerMove : MonoBehaviour, ISavedProgressReader
    {
        private const string IsMoving = "IsMoving";

        private Animator _animator;
        private int _gameLevel;

        private void Start()
            => _animator = GetComponent<Animator>();

        public void Move()
        {
            if (_gameLevel > 0)
            {
                _animator.SetBool(IsMoving, true);
            }
        }            

        public void Stop()
        {
            if (_gameLevel > 0)
            {
                _animator.SetBool(IsMoving, false);
            }
        }            

        public void LoadProgress(PlayerProgress progress)
        {
            _gameLevel = progress.HeroState.GameLevel;
        }
    }
}
