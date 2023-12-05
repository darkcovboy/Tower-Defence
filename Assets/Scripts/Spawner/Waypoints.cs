using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    public IReadOnlyList<Transform> Points => _points;
}