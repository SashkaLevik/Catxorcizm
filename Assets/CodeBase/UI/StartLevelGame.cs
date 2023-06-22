using System.Collections.Generic;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.LevelLogic;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.State;
using UnityEngine;

namespace CodeBase.UI
{
    public class StartLevelGame : MonoBehaviour
    {
        [SerializeField] private List<ButtonLevel> _levels;
        public LoadingCurtain Curtain;
        private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
        }

        private void OnEnable()
        {
            foreach (ButtonLevel level in _levels)
            {
                level.StartLevelButtonClick += LevelOnStartLevelButtonClick;
            }
        }

        private void OnDisable()
        {
            foreach (ButtonLevel level in _levels)
            {
                level.StartLevelButtonClick -= LevelOnStartLevelButtonClick;
            }
        }

        private void LevelOnStartLevelButtonClick(ButtonLevel level, string levelName)
        {
            _stateMachine.Enter<LoadMenuState, string>(level.TransferTo);
            _stateMachine.Enter<LoadProgressState>();
        }
    }
}