using UnityEngine;

public class TowerPlacementManager : MonoBehaviour
{
    public static TowerPlacementManager Instance { get; private set; }

    [Header("Setup")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask buildZoneLayer;

    [SerializeField] private GameObject selectedTowerPrefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (selectedTowerPrefab == null) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            TryPlaceTower(selectedTowerPrefab);
        }
    }


}