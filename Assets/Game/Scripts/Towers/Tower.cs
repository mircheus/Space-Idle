using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class Tower : MonoBehaviour
    {
        private TowerType _towerType;
        
        [Inject]
        public void Construct(TowerType towerType)
        {
            _towerType = towerType;
        }
        
        public class Factory : PlaceholderFactory<TowerType, Tower> { }
    }
}