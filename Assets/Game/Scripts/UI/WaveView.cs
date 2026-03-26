using System;
using Game.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class WaveView : MonoBehaviour
{
    [Header("References: ")]
    [SerializeField] private GameObject startWavePanel;
    [SerializeField] private Button startWaveButton;

    public event Action StartWaveButtonPressed;

    private void Awake()
    {
        startWaveButton.onClick.AddListener(OnStartWaveButtonPressed);
    }

    public void ShowPanel()
    {
        startWavePanel.SetActive(true);
    }

    public void HidePanel()
    {
        startWavePanel.SetActive(false);
    }
    
    private void OnStartWaveButtonPressed()
    {
        StartWaveButtonPressed?.Invoke();
    }
}
