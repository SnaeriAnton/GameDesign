using TMPro;
using UnityEngine;

public class ViewBranches : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Bag _bag;


    private void OnEnable()
    {
        _bag.Changed += OnChange;
    }

    private void OnDisable()
    {
        _bag.Changed -= OnChange;
    }

    private void Start()
    {
        _lable.text = "0";
    }

    private void OnChange(int value)
    {
        _lable.text =  value.ToString();
    }
}
