using UnityEngine;
using UnityEngine.Events;

public class LogTrigger : MonoBehaviour
{
    public event UnityAction Crossed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            Crossed?.Invoke();
    }
}
