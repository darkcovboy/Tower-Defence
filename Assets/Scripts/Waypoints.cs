using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //public static Transform[] points { get;private set ;}

    //private void Awake()
    //{
    //    points = new Transform[transform.childCount];

    //    for (int i = 0; i < points.Length; i++)
    //    {
    //        points[i] = transform.GetChild(i);
    //    }
    //}

    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform[] _points1;
    [SerializeField] private Transform[] _points2;
    [SerializeField] private Transform[] _points3;

    public Transform[] Points => _points;
    public Transform[] Points1 => _points1;
    public Transform[] Points2 => _points2;
    public Transform[] Points3 => _points3;
}