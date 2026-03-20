using UnityEngine;

namespace Game.Scripts.Interfaces
{
    public interface IInputService
    {
        bool IsClicking { get; }
        Vector3 GetClickPosition();
    }
}