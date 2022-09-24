using UnityEngine;

public class Stump : MonoBehaviour
{
    [SerializeField] private int _loseBrancheCount = 5;

    public int LoseBrancheCount => _loseBrancheCount;
}
