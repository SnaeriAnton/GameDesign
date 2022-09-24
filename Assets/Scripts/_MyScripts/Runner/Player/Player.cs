using UnityEngine;
using RunnerMovementSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCollision _collision;
    [SerializeField] private MovementSystem _movment;
    [SerializeField] private Bag _bag;
    [SerializeField] private Axe _axe;
    [SerializeField] private Transform _transform;

    public Transform Transform => _transform;    
    public Transform BagTarget => _bag.BagTarget;    

    private void OnEnable()
    {
        _collision.EnteredGrass += OnSlowDown;
        _collision.LitBonfire += OnSparkOffBonfire;
        _collision.PickedUpBranche += OnAddBranche;
        _collision.TrippedOnStump += OnLostBranche;
    }

    private void OnDisable()
    {
        _collision.EnteredGrass -= OnSlowDown;
        _collision.LitBonfire -= OnSparkOffBonfire;
        _collision.PickedUpBranche -= OnAddBranche;
        _collision.TrippedOnStump -= OnLostBranche;
    }

    private void OnSlowDown(bool value)
    {
        _movment.SlowDown(value);
    }

    private void OnAddBranche()
    {
        _bag.AddBranche();
    }

    private void OnLostBranche(int count)
    {
        _bag.Removebranche(count);
    }

    private void OnSparkOffBonfire(Bonfire bonfire)
    {
        if (_bag.CountOfBranches < bonfire.RightCountOfBranches)
            return;

        OnLostBranche(bonfire.RightCountOfBranches);
        bonfire.SparkOff();
    }
}
