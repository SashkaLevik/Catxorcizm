using System;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.State;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.LevelLogic
{
    public class ReturnMenu : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public string TransferTo;
        private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
        }

        public void ClickMenu()
        {
            _stateMachine.Enter<LoadMenuState, string>(TransferTo);
        }
    }
}