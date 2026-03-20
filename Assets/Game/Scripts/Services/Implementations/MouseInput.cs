using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Implementations
{
    public class MouseInput : IInputService
    {
        public bool IsClicking => Input.GetMouseButtonDown(0);
        
        public Vector3 GetClickPosition()
        {
            return Input.mousePosition;
        }
    }
}