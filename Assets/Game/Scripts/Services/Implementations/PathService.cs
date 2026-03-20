using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Implementations
{
    public class PathService : IPathService
    {
        private Vector3[] _waypoints;

        public PathService(LevelPointsConfig levelPointsConfig)
        {
            _waypoints = levelPointsConfig.WayPoints;
        }
        
        public Vector3[] GetWaypoints()
        {
            return _waypoints;
        }

        public Vector3 GetNextWaypoint(int current)
        {
            if (current == _waypoints.Length)
            {
                return _waypoints[^1]; // NOTE: не уверен, что это ок просто отдавать последнюю точку
            }
            
            return _waypoints[current];
        }
    }
}