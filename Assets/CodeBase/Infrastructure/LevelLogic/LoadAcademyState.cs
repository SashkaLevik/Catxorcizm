using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service.PersistentProgress;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Infrastructure.State;
using UnityEngine;

namespace CodeBase.Infrastructure.LevelLogic
{
    public class LoadAcademyState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string Academy = "Academy";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadAcademyState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => 
            _loadingCurtain.Hide();

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();

            _gameStateMachine.Enter<GameLoopState>();
        }
        
        private void InitGameWorld()
        {
            GameObject hud = _gameFactory.CreatHudAcademy();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }
    }
}