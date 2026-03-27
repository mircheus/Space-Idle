using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class Player : MonoBehaviour
    {
        private IInputService _input;
        private ITowerService _towerService;
        private Camera _mainCamera;
        private LayerMask _buildZoneLayer;
        
        [Inject]
        public void Construct(IInputService input, ITowerService towerService)
        {
            _input = input;
            _towerService = towerService;
        }

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (_input.IsClicking)
            {
                Vector2 clickPos = _mainCamera.ScreenToWorldPoint(_input.GetClickPosition());
                _towerService.PlaceTower(TowerType.BasicTower, clickPos);
            }
        }
    }
}