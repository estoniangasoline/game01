using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private bool _inStation;
    private LineRenderer _lineRenderer;
    private float _acceleration;
    private int _pointNumber;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.SetPosition(1, _rigidbody.position);
        _pointNumber = 0;
    }

    void FixedUpdate()
    {
        if (_inStation)
        {
            _lineRenderer.SetPosition(0, _rigidbody.position);
            if (Input.GetKey(KeyCode.S))
            {
                _direction.y += 1;
                _acceleration += 1;
                if ((_direction * _acceleration).y > _rigidbody.position.y)
                    _lineRenderer.SetPosition(1, _direction * _acceleration);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                _direction.y -= 1;
                _acceleration += 1;
                if ((_direction * _acceleration).y < _rigidbody.position.y)
                    _lineRenderer.SetPosition(1, _direction * _acceleration);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _direction.x += 1;
                _acceleration += 1;
                _lineRenderer.SetPosition(1, _direction * _acceleration);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _direction.x -= 1;
                _acceleration += 1;
                _lineRenderer.SetPosition(1, _direction * _acceleration);
            }
            else
            {
                _rigidbody.AddForce(_direction.normalized * _acceleration, ForceMode.Impulse);
                if (_acceleration > 0)
                {
                    _inStation = false;
                    _rigidbody.useGravity = true;
                }
                _direction.x = 0;
                _direction.y = 0;
                _direction.z = 0;
                _acceleration = 0;
                _lineRenderer.SetPosition(1, _rigidbody.position);
            }
        }
        else
        {
            _lineRenderer.SetPosition(1, _rigidbody.position);
        }

    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _inStation = true; 
    }


}
