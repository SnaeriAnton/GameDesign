using System.Collections;
using UnityEngine;

public class StackerBranche : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _hight = 0.5f;
    [SerializeField] private float _speed = 0.7f;
    [SerializeField] private GameObject _gameObject;

    private Transform _transformTargetBag;
    private Coroutine _stack;
    private Coroutine _stackTest;
    private bool _isActivate = false;
    private Vector3 _lastposition;

    private void Update()
    {

        if (_isActivate == true)
        {
            _stack = StartCoroutine(Stack());
            _stackTest = StartCoroutine(StackTest());
        }

    }


    public void SetTargetBag(Transform target)
    {
        _transformTargetBag = target;
        _isActivate = true;
    }

    private IEnumerator Stack()
    {
        float expiredSecond = 0;
        float progress = 0;

        while (progress < 1)
        {
            expiredSecond += Time.deltaTime;
            progress = expiredSecond / _speed;

            _lastposition = new Vector3(0, _curve.Evaluate(progress) * _hight, 0);
            yield return null;
        }

        StopCoroutine(_stack);
    }

    private IEnumerator StackTest()
    {
        float expiredSecond = 0;
        float progress = 0;

        while (progress < 1)
        {
            expiredSecond += Time.deltaTime;
            progress = expiredSecond / _speed;

            _transform.position = Vector3.Lerp(_transform.position, _transformTargetBag.position, progress) + _lastposition;
            yield return null;
        }

        StopCoroutine(_stackTest);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Bag>(out Bag bag))
        {
            if (_stack != null)
                StopCoroutine(_stack);

            Destroy(_gameObject);

        }
    }
}
