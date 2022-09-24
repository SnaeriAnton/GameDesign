using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private bool _lit = false;
    private int _rightCountOfBranches = 3;

    public int RightCountOfBranches => _rightCountOfBranches;
    public bool Lit => _lit;

    public void SparkOff()
    {
        _particleSystem.Play();
        _lit = true;
    }
}
