using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchWorldCoordinates : MonoBehaviour
{
    private Camera _camera;
    Vector3 Touch;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void OnMouseDown()
    {
        Touch = _camera.WorldToScreenPoint(Input.mousePosition);
    }
}
