using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerCollision _playerCollision;

    private float _speedRun = 1f;
    private float _speedSlowRun = 0.6f;

    public const string Chop = nameof(Chop);

    private void OnEnable()
    {
        _playerCollision.EnteredGrass += OnSlowRunning;
        _playerCollision.ReachedTree += OnChop;
    }

    private void OnDisable()
    {
        _playerCollision.EnteredGrass -= OnSlowRunning;
        _playerCollision.ReachedTree -= OnChop;
    }

    private void OnSlowRunning(bool value)
    {
        if (value == true)
            _animator.speed = _speedSlowRun;
        else
            _animator.speed = _speedRun;
    }

    private void OnChop(bool value)
    {
        if (value == true)
            _animator.SetBool(Chop, value);
        else
            _animator.SetBool(Chop, value);
    }
}
