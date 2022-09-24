using UnityEngine;

public class BagAnimator : MonoBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private Bag _bag;


    public const string BagScale = nameof(BagScale);

    private void OnEnable()
    {
        _bag.ReceivedBranche += OnScale;
    }

    private void OnDisable()
    {
        _bag.ReceivedBranche -= OnScale;
    }

    private void OnScale()
    {
        _animation.PlayQueued(BagScale, QueueMode.CompleteOthers);
    }
}
