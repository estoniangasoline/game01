using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroVelocity : MonoBehaviour
{
    Vector3 _startposition;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startposition = _rigidbody.position;
    }
    private void Update()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.position = _startposition;
    }
}
