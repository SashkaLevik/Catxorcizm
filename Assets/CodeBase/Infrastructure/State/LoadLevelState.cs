using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service.PersistentProgress;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Player;
using CodeBase.Tower;
using CodeBase.UI.Element;
using CodeBase.UI.Forms;
using CodeBase.UI.Service.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IGameFactory gameFactory, IUIFactory uiFactory, IPersistentProgressService progressService)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
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
            //CameraFollow(hero);

            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag));
            GameObject hud = _gameFactory.CreateHud();
            InitUiRoot(hero);

            hud.GetComponentInChildren<UpgradePlayerUI>(true).Construct(hero.GetComponent<UpgradePlayer>());

            foreach (var towerSpawner in hero.GetComponentsInChildren<TowerSpawner>())
            {
                towerSpawner.Construct(_uiFactory);
            }
        }

        private void InitUiRoot(GameObject hero)
        {
            GameObject uiRoot = _uiFactory.CreateUIRoot();
            
            uiRoot.GetComponentInChildren<ShopWindow>(true).Construct(
                hero.GetComponent<PlayerMoney>(),
                hero.GetComponent<Inventory>());

            uiRoot.GetComponentInChildren<UpgradeWindow>(true).Construct(
                hero.GetComponent<PlayerMoney>(),
                hero.GetComponent<Inventory>());
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }

        // private void CameraFollow(GameObject hero) =>
        //     Camera.main.GetComponent<CameraFollow>().Follow(hero);
    }
}