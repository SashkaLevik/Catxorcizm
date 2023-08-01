using Assets.Sashka.Scripts.Enemyes;
using CodeBase.Player;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Sashka.Infastructure.Spell;

namespace CodeBase.UI.Element
{
    public class ActorUI : MonoBehaviour
    {
        private const string SpawnerController = "SpawnerController";

        [SerializeField] private HPBar _hpBar;
        [SerializeField] private TMP_Text _soulCount;
        [SerializeField] private TMP_Text _spellAmount;
        [SerializeField] private TMP_Text _livesAmount;
        [SerializeField] private HeroHealth _heroHealth;
        [SerializeField] private CastSpell _spell;
        [SerializeField] private PlayerMoney _money;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Button _nextWave;
        [SerializeField] private Button _levelComplete;
        [SerializeField] private SpawnerController _spawnerController;
        [SerializeField] private RewardCalculation _reward;        

        private GameObject _spawner;       

        public SpawnerController Spawner => _spawnerController;

        private void Awake()
        {
            _spawner = GameObject.FindGameObjectWithTag(SpawnerController);
            _spawnerController = _spawner.GetComponent<SpawnerController>();
            _levelComplete.gameObject.SetActive(false);
        }

        private void Start()
        {
            _soulCount.text = _money.CurrentSoul.ToString();
            _spellAmount.text = _spell.SpellAmount.ToString();
            _canvas.worldCamera = Camera.main;
        }

        private void OnEnable()
        {
            _spawnerController.LevelCompleted += _reward.GetReward;
            _spawnerController.WaveCompleted += ShowButton;
            _nextWave.onClick.AddListener(_spawnerController.NextWave);
            _nextWave.onClick.AddListener(HideButton);
            _spawnerController.LevelCompleted += CompleteLevel;
            _levelComplete.onClick.AddListener(LoadMenu);
        }               

        private void OnDestroy()
        {
            _spawnerController.LevelCompleted -= _reward.GetReward;
            _spawnerController.WaveCompleted -= ShowButton;
            _nextWave.onClick.RemoveListener(_spawnerController.NextWave);
            _nextWave.onClick.RemoveListener(HideButton);
            _spawnerController.LevelCompleted -= CompleteLevel;
            _levelComplete.onClick.RemoveListener(LoadMenu);
            _heroHealth.HealthChanged -= UpdateHpBar;
            _money.CurrentSoulChanged -= UpdateSoulCount;
            //_heroHealth.Died -= _reward.GetReward;
            _heroHealth.Died -= CompleteLevel;
        }

        public void Construct(HeroHealth heroHealth, CastSpell spell)
        {
            _heroHealth = heroHealth;
            _spell = spell;
            _heroHealth.HealthChanged += UpdateHpBar;
            _spell.SpellUsed += UpdateSpellAmount;
            _money.CurrentSoulChanged += UpdateSoulCount;
            _heroHealth.Died += _reward.GetReward;
            _heroHealth.Died += CompleteLevel;
        }

        private void UpdateSoulCount(int soul)
            => _soulCount.text = soul.ToString();

        private void UpdateHpBar() => 
            _hpBar.SetValue(_heroHealth.Current, _heroHealth.Max);

        private void UpdateSpellAmount(int amount)
            => _spellAmount.text = amount.ToString();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Soul soul))
            {
                _money.AddMoney(soul.Reward);
            }
        }

        public void ShowButton()
            => _nextWave.gameObject.SetActive(true);

        public void HideButton()
            => _nextWave.gameObject.SetActive(false);

        private void CompleteLevel()
        {
            HideButton();
            _levelComplete.gameObject.SetActive(true);
            _spawnerController.WaveCompleted -= ShowButton;
        }

        private void LoadMenu()
            => SceneManager.LoadScene(1);
    }
}