using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StackerBranche))]
public class Branche : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private StackerBranche _stackerBranche;
    [SerializeField] private GameObject _bushObject;

    public event UnityAction ChopedBranch;

    public void SetBagTarget(Transform target)
    {
        _stackerBranche.SetTargetBag(target);
        ChopedBranch?.Invoke();
    }
}
