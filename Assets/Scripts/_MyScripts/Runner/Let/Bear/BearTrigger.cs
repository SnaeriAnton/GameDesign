using UnityEngine;

public class BearTrigger : MonoBehaviour
{
    [SerializeField] private Bear _bear;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            _bear.Follow(player.Transform);
    }
}
