using UnityEngine;

public class ObjectDisplayToggle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Tree>(out Tree tree))
            tree.ChangeLayer();
    }
}
