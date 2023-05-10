using UnityEngine;

public class OpenPanelTower : MonoBehaviour
{
    [SerializeField] private Transform _panel;
    [SerializeField] private Transform _closePanel;

    private void Start()
    {
        _panel.gameObject.SetActive(false);
        _closePanel.gameObject.SetActive(false);
    }

    public void OpenPanel()
    {
        _panel.gameObject.SetActive(true);
        _closePanel.gameObject.SetActive(true);
    }

    public void ClosePAnel()
    {
        _panel.gameObject.SetActive(false);
    }
}
