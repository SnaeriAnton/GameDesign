using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _transformPlayer;

    private float _offsetZ = 6f;
    private float _offsetY = 4f;
    private float _offsetRotateX = 20f;

    private void LateUpdate()
    {
        _transform.position = new Vector3(_transformPlayer.position.x, _transformPlayer.position.y + _offsetY, _transformPlayer.position.z - _offsetZ);
        _transform.LookAt(_transformPlayer);
        //_transform.rotation = Quaternion.Euler(_transform.rotation.eulerAngles.x, _transformPlayer.rotation.eulerAngles.y, _transform.rotation.z);
    }
}
