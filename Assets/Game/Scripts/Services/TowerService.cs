using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Services
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
            _towerFactory.Create(type);
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