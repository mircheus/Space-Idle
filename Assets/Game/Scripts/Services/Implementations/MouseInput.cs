using UnityEngine;

namespace Game.Scripts.Project.Services
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