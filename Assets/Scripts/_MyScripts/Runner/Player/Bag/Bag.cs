using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _bagTarget;

    private int _countOfBranches = 3;

    public int CountOfBranches => _countOfBranches;
    public Transform BagTarget => _bagTarget;

    public event UnityAction<int> Changed;
    public event UnityAction ReceivedBranche;

    private void Start()
    {
        Changed?.Invoke(_countOfBranches);
    }

    public void AddBranche()
    {
        _countOfBranches += 1;

        Changed?.Invoke(_countOfBranches);
    }

    public void Removebranche(int count)
    {
        int remainder = _countOfBranches - count;

        if (remainder > 0)
            _countOfBranches -= count;
        else
            _countOfBranches = 0;

        if (_countOfBranches > 0)
            _particleSystem.Play();

        Changed?.Invoke(_countOfBranches);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Branche>(out Branche branche))
        {
            ReceivedBranche?.Invoke();
            AddBranche();
        }
    }

}
