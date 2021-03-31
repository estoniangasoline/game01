using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryDraw : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Rigidbody _rigidbody;
    private Move1 _move1;
    private Vector3 _endPoint;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _move1 = GetComponent<Move1>();
    }

    private void OnMouseDown()
    {
        _lineRenderer.SetPosition(0, _rigidbody.position);
    }

    private void OnMouseDrag()
    {
        Debug.Log(_move1.Direction);
        _lineRenderer.SetPosition(1, _move1.Direction * _move1.DragTime);
    }
}
