using Assets.Sashka.Infastructure.Spell;
using Assets.Sashka.Scripts.Enemyes;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service.PersistentProgress;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Infrastructure.State;
using CodeBase.Player;
using CodeBase.Tower;
using CodeBase.UI.Element;
using CodeBase.UI.Forms;
using CodeBase.UI.Service.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.LevelLogic
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IPersistentProgressService _progressService;
        private IState _stateImplementation;
        private Camera _camera;


        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IGameFactory gameFactory, IUIFactory uiFactory, IPersistentProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, onLoaded: OnLoaded);
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
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag));
            hero.transform.SetParent(Camera.main.transform);
            GameObject hud = _gameFactory.CreateHud();
            //GameObject hud = _gameFactory.CreateHud();
            InitHud(hero, hud);
            GameObject additionalTool = _gameFactory.CreateDraggableItem();
            InitUiRoot(hero, hud, additionalTool);

            foreach (var towerSpawner in hero.GetComponentsInChildren<TowerSpawner>())
            {
                towerSpawner.Construct(_uiFactory);
            }
        }

        private void InitUiRoot(GameObject hero, GameObject hud, GameObject additionalTool)
        {
            GameObject uiRoot = _uiFactory.CreateUIRoot();
            
            uiRoot.GetComponentInChildren<ShopWindow>(true).Construct(
                hud.GetComponent<PlayerMoney>(),
                hero.GetComponent<Inventory>());

            uiRoot.GetComponentInChildren<UpgradeMinions>(true).Construct(
                hud.GetComponent<PlayerMoney>(),
                hero.GetComponent<Inventory>());
            
            additionalTool.GetComponent<DraggableItem>().Construct(uiRoot.GetComponentInChildren<UpgradeMinions>(true), hero.GetComponent<Inventory>());
        }

        private void InitHud(GameObject hero, GameObject hud)
        {
            hud.GetComponentInChildren<ActorUI>().Construct(hero.GetComponent<HeroHealth>(), hero.GetComponent<CastSpell>());
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }
    }
}
