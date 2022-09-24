using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Transform _bagTarget;

    public event UnityAction<bool> EnteredGrass;
    public event UnityAction<Bonfire> LitBonfire;
    public event UnityAction PickedUpBranche;
    public event UnityAction<int> TrippedOnStump;
    public event UnityAction<bool> ReachedTree;

    private void Destroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Log>(out Log log))
            Destroy();
        
        if (collision.gameObject.TryGetComponent<Grass>(out Grass grass))
            EnteredGrass?.Invoke(true);

        if (collision.gameObject.TryGetComponent<Bonfire>(out Bonfire bonfire))
            LitBonfire?.Invoke(bonfire);

        if (collision.gameObject.TryGetComponent<Branche>(out Branche branche))
            branche.SetBagTarget(_bagTarget);

        if (collision.gameObject.TryGetComponent<Stump>(out Stump stump))
            TrippedOnStump?.Invoke(stump.LoseBrancheCount);

        if (collision.gameObject.TryGetComponent<Fance>(out Fance fance))
            Destroy();

        if (collision.gameObject.TryGetComponent<BearHead>(out BearHead bearHead))
            Destroy();

        if (collision.gameObject.TryGetComponent<Tree>(out Tree tree))
            ReachedTree?.Invoke(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Grass>(out Grass leaves))
            EnteredGrass?.Invoke(false);

        if (collision.gameObject.TryGetComponent<Tree>(out Tree tree))
            ReachedTree?.Invoke(false);
    }
}
