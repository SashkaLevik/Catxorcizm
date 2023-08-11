using CodeBase.Infrastructure;
using CodeBase.Infrastructure.LevelLogic;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Infrastructure.State;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI.Element
{
    public class ReloadLevel : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private IGameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;

        private ISaveLoadService _saveLoadService;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        public void Reload()
        {
            _saveLoadService.SaveProgress();
            string currentScene = SceneManager.GetActiveScene().name;
        }
    }
}