using CodeBase.Infrastructure.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Element
{
    public class OpenPanelMinions : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textTitle;
        [SerializeField] private Image _imageIcon;
        [SerializeField] private TMP_Text _damageText;
        [SerializeField] private TMP_Text _cooldownText;
        [SerializeField] private TMP_Text _attackRangeText;
    
        private TowerStaticData _data;
    
        public void OpenPanel(GameObject panel)
        {
            panel.SetActive(true);
        }

        public void Show(TowerStaticData data)
        {
            _imageIcon.sprite = data.UIIcon;
            _damageText.text = data.Damage.ToString();
            _cooldownText.text = data.Cooldown.ToString();
            _attackRangeText.text = data.AttackRange.ToString();
        }

        public void ClosePanel(GameObject panel)
        {
            panel.SetActive(false);
        }
    }
}