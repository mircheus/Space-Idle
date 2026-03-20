using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Interfaces
{
    public interface ITowerService
    {
        void PlaceTower(TowerType type, Vector3 pos);
        void UpgradeTower(Tower tower);
        List<Tower> GetAllTowers();
    }
}