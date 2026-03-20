using UnityEngine;

namespace Game.Scripts.Interfaces
{
    public interface IPathService
    {
        Vector3[] GetWaypoints();
        Vector3 GetNextWaypoint(int current);
    }
}