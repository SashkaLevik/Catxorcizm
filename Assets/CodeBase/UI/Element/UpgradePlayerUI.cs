using CodeBase.Player;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Element
{
    public class UpgradePlayerUI : MonoBehaviour
    {
        [SerializeField] private Button _upgrade;

        private UpgradePlayer _upgradePlayer;

        public void Construct(UpgradePlayer player)
        {
            _upgradePlayer = player;
        }
        
        private void OnEnable()
        {
            _upgrade.onClick.AddListener(TrySellBuyUI);
        }

        private void OnDisable()
        {
            _upgrade.onClick.RemoveListener(TrySellBuyUI);
        }

        private void TrySellBuyUI()
        {
            _upgradePlayer.TrySellBuy();
        }
    }
}