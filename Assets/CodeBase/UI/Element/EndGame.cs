using CodeBase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.LevelLogic;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Infrastructure.State;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Element
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public string TransferTo;

        private IGameStateMachine _stateMachine;
        private IGameFactory _gameFactory;
        private ISaveLoadService _saveLoadService;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        public void ClickMenu()
        {
            _saveLoadService.ResetProgress();
            _stateMachine.Enter<LoadProgressState>();
        }

        public void OpenPanel(GameObject panel)
            => panel.SetActive(true);

        public void ClosePanel(GameObject panel)
            => panel.SetActive(false);
    }
}
