using Game.Scripts.Project.Settings;
using UnityEngine;

namespace Game.Scripts.Project.Services
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
                return 
            }
            
            return _waypoints[current];
        }
    }
}