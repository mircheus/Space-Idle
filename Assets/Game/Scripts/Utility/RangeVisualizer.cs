using System;
using UnityEngine;

public class RangeVisualizer : MonoBehaviour
{  
    [SerializeField] private CircleCollider2D circleCollider2D;

    private void Start()
    {
        transform.localScale = Vector3.one *  (circleCollider2D.radius * 2);
    }
}
