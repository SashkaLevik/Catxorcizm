using CodeBase.Infrastructure.Factory;
using CodeBase.Player;
using CodeBase.Tower;
using CodeBase.UI.Forms;
using CodeBase.UI.Service.Factory;
using CodeBase.UI.Service.Windows;
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

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IGameFactory gameFactory, IUIFactory uiFactory)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
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
            //InitUiRoot();

            GameObject uiRoot = _uiFactory.CreateUIRoot();
            GameObject hud = _gameFactory.CreateHud();
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag));

            uiRoot.GetComponentInChildren<ShopWindow>(true).Construct(
                hero.GetComponent<PlayerMoney>(), 
                hero.GetComponent<Inventory>());
            
            foreach (var towerSpawner in hero.GetComponentsInChildren<TowerSpawner>())
            {
                towerSpawner.Construct(_uiFactory);
            }
            
            //CameraFollow(hero);

            _stateMachine.Enter<GameLoopState>();
        }

        private void InitUiRoot() =>
            _uiFactory.CreateUIRoot();

        // private void CameraFollow(GameObject hero) =>
        //     Camera.main.GetComponent<CameraFollow>().Follow(hero);
    }
}