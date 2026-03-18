using Game.Scripts.Project.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Towers
{
    public class Player : MonoBehaviour
    {
        private IInputService _input;
        private ITowerService _towerService;
        private Camera _mainCamera;
        
        [Inject]
        public void Construct(IInputService input, ITowerService towerService)
        {
            _input = input;
            _towerService = towerService;
        }

        private void Awake()
        {
            _mainCamera = Camera.main; // TODO: а как можно заинжектить камеру?
        }

        private void Update()
        {
            if (_input.IsClicking)
            {
                Vector2 clickPos = _mainCamera.ScreenToWorldPoint(_input.GetClickPosition());
                _towerService.PlaceTower(TowerType.Default, clickPos);
            }
        }
    }
}