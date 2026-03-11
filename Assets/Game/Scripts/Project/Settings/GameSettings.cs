using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Space-Idle/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Gameplay Settings")] 
    [SerializeField] private string info;

    public string Info => info;
}