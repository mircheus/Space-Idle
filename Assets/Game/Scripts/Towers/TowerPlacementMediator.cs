using System;
using Game.Scripts;
using Game.Scripts.Interfaces;
using UnityEngine;
using Zenject;

public class TowerPlacementMediator : IInitializable, ITickable
{
    private readonly IInputService _inputService;
    private readonly ITowerService _towerService;

    public TowerPlacementMediator(IInputService inputService, ITowerService towerService)
    {
        _inputService = inputService;
        _towerService = towerService;
    }
    
    public void Initialize()
    {
        Debug.Log($"TowerPlacementMediator.Initialize");
    }

    public void Tick()
    {
        if (_inputService.IsClicking)
        {
            Debug.Log($"TowerPlacementMediator.Click");
            TryBuild();
        }
    }

    private void TryBuild()
    {
        Vector2 worldPos = _inputService.GetClickPosition();
        Collider2D hit = Physics2D.OverlapPoint(worldPos, LayerMask.GetMask(Constants.BuildZone));
        
        if (hit == null) return;
        Debug.Log($"Hit : {hit.gameObject.name}");
        
        BuildZone zone = hit.GetComponent<BuildZone>();

        if (zone == null || !zone.TryOccupy()) return;
        
        _towerService.PlaceTower(TowerType.BasicTower, zone.Position);
    }
}