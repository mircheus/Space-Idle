using System;
using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Implementations
{
    public class MouseInput : IInputService
    {
        private Camera _mainCamera;
        
        public bool IsClicking => Input.GetMouseButtonDown(0);

        public MouseInput(Camera mainCamera)
        {
            _mainCamera = mainCamera;
            Debug.Log($"_mainCamera: {!(mainCamera == null)}");
        }
        
        public Vector3 GetClickPosition()
        {
            return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}