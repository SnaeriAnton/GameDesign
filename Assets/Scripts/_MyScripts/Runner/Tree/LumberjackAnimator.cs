using UnityEngine;

public class LumberjackAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LogTrigger _trigger;

    public const string Chop = nameof(Chop);

    private void OnEnable()
    {
        _trigger.Crossed += OnChop;
    }

    private void OnDisable()
    {
        _trigger.Crossed -= OnChop;
    }

    private void OnChop()
    {
        _animator.SetTrigger(Chop);
    }
}
