using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private Transform _bagTarget;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Branche>(out Branche branche))
            branche.SetBagTarget(_bagTarget);
    }
}
