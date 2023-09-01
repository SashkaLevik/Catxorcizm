using Assets.Sashka.Infastructure;
using CodeBase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.Service.SaveLoad
{
    public class SaveLoadService: ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private const string MenuScene = "MenuScene";
        
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;
        private IGameStateMachine _gameStateMachine;
        
        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }
        
        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);
            
            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey)?
                .ToDeserialized<PlayerProgress>();
        }

        public void ResetProgress()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            _gameStateMachine.Enter<LoadMenuState, string>(MenuScene);
        }
    }
}