﻿using CodeBase.Data;
using CodeBase.Infrastructure.LevelLogic;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.PersistentProgress;
using CodeBase.Infrastructure.Service.SaveLoad;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class LoadProgressState: IState
    {
        private const string MenuScene = "MenuScene";
        private const string PortArea = "PortArea";
        
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
            
            _gameStateMachine.Enter<LoadPortState, string>(_progressService.Progress.WorldData.Level);
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
            Debug.Log("new Stats");
            
            var progress =  new PlayerProgress(initialLevel: PortArea);
            progress.HeroState.ResetHP();

            return progress;
        }
    }
}