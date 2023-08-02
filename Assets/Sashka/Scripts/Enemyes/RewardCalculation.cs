using UnityEngine;
using TMPro;
using CodeBase.Player;
using UnityEngine.UI;
using System.Collections;
using CodeBase.UI.Element;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class RewardCalculation : MonoBehaviour
    {
        [SerializeField] private Image _rewardWindow;
        [SerializeField] private Image _oneStar;
        [SerializeField] private Image _twoStars;
        [SerializeField] private Image _threeStars;
        [SerializeField] private TMP_Text _rewardAmount;
        [SerializeField] private TMP_Text _killedPercent;
        [SerializeField] private PrizeSoul _prizeSoulPrefab;        
        [SerializeField] private ActorUI _actorUI;

        private int _lowPercent = 25; private int _mediumPercent = 50; private int _highPercent = 75;
        private int _lowReward = 40; private int _mediumReward = 80; private int _highReward = 120;

        private IEnumerator SpawnSoul(int amount)
        {
            for (int i = amount; i > 0; i--)
            {
                Instantiate(_prizeSoulPrefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
            }
        }

        public void GetReward()
        {           
            _actorUI.Spawner.CalculatePercentage();
            _rewardWindow.gameObject.SetActive(true);

            if (_actorUI.Spawner.KilledEnemies <= _lowPercent)
            {
                SetRewardValues(_lowReward, _oneStar);
                _killedPercent.text = _actorUI.Spawner.KilledEnemies.ToString();
                StartCoroutine(SpawnSoul(4));
            }
            else if (_actorUI.Spawner.KilledEnemies <= _mediumPercent)
            {
                SetRewardValues(_mediumReward, _twoStars);
                _killedPercent.text = _actorUI.Spawner.KilledEnemies.ToString();
                StartCoroutine(SpawnSoul(8));
            }
            else if (_actorUI.Spawner.KilledEnemies > _highPercent)
            {
                SetRewardValues(_highReward, _threeStars);
                _killedPercent.text = _actorUI.Spawner.KilledEnemies.ToString();
                StartCoroutine(SpawnSoul(12));
            }
        }

        private void SetRewardValues(int reward, Image rewardImage)
        {
            rewardImage.gameObject.SetActive(true);            
            _rewardAmount.text = reward.ToString();
        }
    }
}
