using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] private MovementSystem _movment;
    [SerializeField] private MouseInput _input; 

    public void Follow(Transform transform)
    {
        _input.enabled = true;
        _movment.enabled = true;
    }

    private void StopFollow()
    {
        _input.enabled = false;
        _movment.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Bonfire>(out Bonfire bonfire))
            if (bonfire.Lit == true)
                StopFollow();
    }
}
