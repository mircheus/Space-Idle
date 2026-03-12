using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Services
{
    public class Tower : MonoBehaviour
    {
        private TowerType _towerType;
        
        // Добавь конструктор с параметром TowerType
        [Inject]
        public Tower(TowerType towerType)
        {
            _towerType = towerType;
        }
        
        public class Factory : PlaceholderFactory<TowerType, Tower> { }
    }
}