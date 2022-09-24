using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Quaternion _rotateAngle;

    private bool _isPlayer = false;
    private float _speed = 2f;

    private void Update()
    {
        if (_isPlayer == true)
            Fall();
    }

    private void Fall()
    {
        _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.Euler(_rotateAngle.x, _rotateAngle.y, _rotateAngle.z), _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<AxeLumberjack>(out AxeLumberjack axe))
            _isPlayer = true;
    }
}
