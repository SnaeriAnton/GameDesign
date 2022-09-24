using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private Branche _branche;
    [SerializeField] private List<GameObject> _gameObjects;

    private void OnEnable()
    {
        _branche.ChopedBranch += OnDelete;
    }

    private void OnDisable()
    {
        _branche.ChopedBranch -= OnDelete;
    }


    public void ChangeLayer()
    {
        foreach (var gameObject in _gameObjects)
            if (gameObject != null)
                gameObject.layer = 6;
    }

    private void OnDelete()
    {
        _gameObjects.RemoveAt(_gameObjects.Count - 1);
        _gameObjects.RemoveAt(_gameObjects.Count - 1);
        _branche.ChopedBranch -= OnDelete;
    }
}
