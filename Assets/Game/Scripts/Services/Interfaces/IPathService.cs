using UnityEngine;

namespace Game.Scripts.Project.Services
{
    public interface IPathService
    {
        Vector3[] GetWaypoints();
        Vector3 GetNextWaypoint(int current);
    }
}