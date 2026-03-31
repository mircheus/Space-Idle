using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public class HUDView : MonoBehaviour
    {
        private SignalBus _signalBus;
        
        [SerializeField] private TextMeshProUGUI healthPoints;
        [SerializeField] private TextMeshProUGUI goldAmount;

        public void SetHp(int newValue)
        {
            healthPoints.text = $"HP: {newValue}";
        }
        
        public void SetGold(int newValue)
        {
            goldAmount.text = $"Gold: {newValue}";
        }
    }
}