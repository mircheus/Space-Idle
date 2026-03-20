using System.Collections.Generic;
using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Implementations
{
    public class TowerService : ITowerService
    {
        private Tower.Factory _towerFactory;
        
        [Inject]
        public void Construct(Tower.Factory towerFactory)
        {
            _towerFactory = towerFactory;
        }
        
        public void PlaceTower(TowerType type, Vector3 pos)
        {
            var tower = _towerFactory.Create(type);
            tower.transform.position = pos;
        }

        public void UpgradeTower(Tower tower)
        {

        }

        public List<Tower> GetAllTowers()
        {
            return null;
        }
    }
}