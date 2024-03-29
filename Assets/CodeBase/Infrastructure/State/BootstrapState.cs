﻿using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.PersistentProgress;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Infrastructure.Service.StaticData;
using CodeBase.UI.Service.Factory;
using CodeBase.UI.Service.Windows;

namespace CodeBase.Infrastructure.State
{
    public class BootstrapState : IState
    {
        private const string Initial = "MyInitial";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            //_services.RegisterSingle<IInputService>(InputService());
            RegisterStaticData();
            
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());

            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IWindowService>(new WindowService(_services.Single<IUIFactory>()));

            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IAssetProvider>(),
                _services.Single<IStaticDataService>(),
                _services.Single<IWindowService>()));
            
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(), 
                _services.Single<IGameFactory>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadProgressState>();
        }
    }
}