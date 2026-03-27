using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BuildZone : MonoBehaviour
{
    public bool IsOccupied { get; private set; }

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    public bool TryOccupy()
    {
        if (IsOccupied) return false;
        IsOccupied = true;
        return true;
    }

    public void Free() => IsOccupied = false;
}