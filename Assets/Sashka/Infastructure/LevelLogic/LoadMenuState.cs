﻿using System;
using UnityEngine.SceneManagement;
using UnityEngine;
namespace Assets.Sashka.Infastructure
{
    public class LoadMenuState : MonoBehaviour, IPayLoadedState<string>, IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ScenLoader _scenLoader;
        private readonly Loading _curtain;
        
        public LoadMenuState(GameStateMachine gameStateMachine, ScenLoader scenLoader, Loading curtain)
        {
            _gameStateMachine = gameStateMachine;
            _scenLoader = scenLoader;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _scenLoader.Load(sceneName, OnLoaded);
        }
                    
        private void OnLoaded()
        {
            if (GetSceneIndex() == 1)
            {
                _gameStateMachine.Enter<GameLoopState>();
                Debug.Log("EnterLoop");
            }
            else
                Debug.Log("LoadProgres");
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        public void Enter()
        {
            //_curtain.Show();
            //_scenLoader.Load(MenuScene);
        }
        private int GetSceneIndex()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }
}
