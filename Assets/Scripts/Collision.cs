using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    Rigidbody _rigidbody;
    private float _collisionX;
    private float _collizionY;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if ((Mathf.Abs(collision.rigidbody.transform.position.y - _rigidbody.transform.position.y) < 0.55) &&
            (Mathf.Abs(collision.rigidbody.transform.position.x - _rigidbody.transform.position.x) < 0.55))
        {
            _rigidbody.useGravity = false;
            if (collision.rigidbody.transform.position.x > _rigidbody.transform.position.x)
                _collisionX = collision.rigidbody.transform.position.x - 0.5f;
            else
                _collisionX = collision.rigidbody.transform.position.x + 0.5f;
            if (collision.rigidbody.transform.position.y > _rigidbody.transform.position.y)
                _collizionY = collision.rigidbody.transform.position.y - 0.5f;
            else
                _collizionY = collision.rigidbody.transform.position.y + 0.5f;
            _rigidbody.transform.position = new Vector3(_collisionX, _collizionY,
                collision.rigidbody.transform.position.z);
        }
    }
}
