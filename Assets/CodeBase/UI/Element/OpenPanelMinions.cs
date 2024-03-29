using Assets.Sashka.Infastructure.Tresures;
using Assets.Sashka.Scripts.Minions;
using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Forms;
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
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Image _itemIcon;        
    
        private TowerStaticData _data;        

        public void OpenPanel(GameObject panel)
        {
            panel.SetActive(true);
        }

        public void Show(TowerStaticData data)
        {            
            _textTitle.text = data.Name;
            _imageIcon.sprite = data.UIIcon;
            _damageText.text = data.Damage.ToString();
            _cooldownText.text = data.Cooldown.ToString();
            _healthText.text = data.MaxHP.ToString();                                               
        }

        public void ClosePanel(GameObject panel)
        {
            panel.SetActive(false);
        }

        public void SetItemIcon(BaseMinion minion)
        {
            _itemIcon.sprite = minion.ItemIcon;
            _itemIcon.color = new Color(1, 1, 1, 1);

            if (minion.ItemIcon == null)
            {
                _itemIcon.color = Color.clear;
            }
        }
    }
}