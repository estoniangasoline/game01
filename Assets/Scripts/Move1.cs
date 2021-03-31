using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _mousePosition;
    private Vector3 _mousePosChange;
    public Vector3 Direction;
    public float DragTime;
    private bool _inStation;
    public float Acceleration;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        DragTime = 0;
        _inStation = true;
        Acceleration = 1000f;
    }

    private void OnMouseDown()
    {
        if (_inStation)
        {
            _mousePosition = Input.mousePosition;
        }
    }

    private void OnMouseDrag()
    {
        if (_inStation)
        {
            _mousePosChange = Input.mousePosition;
            DragTime += Time.deltaTime;
        }
    }

    private void OnMouseUp()
    {
        if (_inStation)
        {
            _mousePosChange = Input.mousePosition;
            Direction = SetDirection(_mousePosition, _mousePosChange);
            Debug.Log(Direction * DragTime * Acceleration);
            _rigidbody.AddForce(Direction * DragTime * Acceleration, ForceMode.Force);
            _rigidbody.useGravity = true;
            DragTime = 0;
            _inStation = false;
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        _inStation = true;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _inStation = true;
    }

    private Vector3 SetDirection(Vector3 _position, Vector3 _change)
    {
        if (Mathf.Abs(_position.x - _change.x) > Mathf.Abs(_position.y - _change.y))
        {
            if (_mousePosition.x < _mousePosChange.x)
            {
                return Vector3.left;
            }
            else
            {
                return Vector3.right;
            }
        }
        else
        {
            if (_mousePosition.y < _mousePosChange.y)
            {
                return Vector3.down;
            }
            else
            {
                return Vector3.up;
            }
        }
    }
}
