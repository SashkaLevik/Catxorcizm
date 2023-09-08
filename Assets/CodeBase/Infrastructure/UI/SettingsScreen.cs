using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Assets.CodeBase.Infrastructure.UI
{
    public class SettingsScreen : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private Button _riseDifficult;
        [SerializeField] private Button _lowDifficult;
        [SerializeField] private TMP_Text _difficultText;

        private int _minLevel = 0;        
        private int _difficult;

        private void Start()
            => _difficultText.text = _difficult.ToString();

        private void OnEnable()
        {
            _riseDifficult.onClick.AddListener(RiseLevel);
            _lowDifficult.onClick.AddListener(LowLevel);
        }

        public void LoadProgress(PlayerProgress progress)
            => _difficult = progress.HeroState.Difficult;

        public void UpdateProgress(PlayerProgress progress)
            => progress.HeroState.Difficult = _difficult;

        private void RiseLevel()
        {
            _difficult++;
            _difficultText.text = _difficult.ToString();
        }

        private void LowLevel()
        {
            if (_difficult > _minLevel)
            {
                _difficult--;
                _difficultText.text = _difficult.ToString();
            }
        }
            
    }
}
