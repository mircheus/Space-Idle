using UnityEngine;

namespace Game.Scripts.Project.Services
{
    public interface IInputService
    {
        bool IsClicking { get; }
        Vector3 GetClickPosition();
    }
}