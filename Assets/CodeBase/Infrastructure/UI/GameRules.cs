using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.UI
{
    class GameRules : MonoBehaviour
    {
        private const string NextAnim = "NextAnim";

        [SerializeField] private GameObject _gameRules;
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private Button _next;

        private Animator _animator;
        private int _animNumber;
        private int _animCount = 3;

        public event UnityAction RulesShowed;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _menuScreen.ShowRules += OpenRulesPanel;
            _next.onClick.AddListener(ShowRules);
        }

        private void OnDisable()
        {
            //_menuScreen.ShowRules -= OpenRulesPanel;
            _next.onClick.RemoveListener(ShowRules);
        }

        private void OpenRulesPanel() 
            => _gameRules.SetActive(true);

        private void ShowRules()
        {
            _animator.SetTrigger(NextAnim);
            _animNumber++;

            if (_animNumber == _animCount)
            {
                RulesShowed?.Invoke();
                _animNumber = 0;
                _gameRules.SetActive(false);
            }
        }
    }
}
