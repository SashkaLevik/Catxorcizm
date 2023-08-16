using CodeBase.Infrastructure.LevelLogic;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Infrastructure.State;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Element
{
    public class ReturnMenu : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public string TransferTo;
        private IGameStateMachine _stateMachine;

        private ISaveLoadService _saveLoadService;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        public void ClickMenu()
        {
            _saveLoadService.SaveProgress();
            _stateMachine.Enter<LoadMenuState, string>(TransferTo);
        }
    }
}