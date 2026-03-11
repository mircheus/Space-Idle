using System;
using UnityEngine;
using Zenject;

public class TestComponent : MonoBehaviour
{
    private string _info;
    
    [Inject]
    public void Construct(GameSettings settings)
    {
        _info = settings.Info;
    }

    private void Start()
    {
        Debug.Log($"Info: {_info}");
    }
}
