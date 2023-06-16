using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.PersistentProgress;
using CodeBase.Infrastructure.Service.SaveLoad;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.State
{
    public class LoadProgressState: IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            
            _gameStateMachine.Enter<LoadLevelState, string>("Main");
        }

        public void Exit()
        {
        }
        
        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = 
                _saveLoadService.LoadProgress() 
                ?? NewProgress();
        }
        private PlayerProgress NewProgress()
        {
            var progress =  new PlayerProgress(initialLevel: "Main")
            {
                HeroState =
                {
                    CurrentHP = 4,
                    MaxHP = 4,
                    MeleeAttack = 3,
                    SpellAmount = 2,
                    Price = 50,
                    Level = 1
                }
            };

            progress.HeroState.ResetHP();

            return progress;
        }
    }
}