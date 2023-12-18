using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelPrefab; 
    [SerializeField] private List<GameObject> _levels;

    public void CreateLevels()
    {
        if (_levels.Count == 0)
        {
            for (int i = 0; i < _levelPrefab.Count; i++)
            {
                GameObject newLevel = Instantiate(_levelPrefab[i]);

                newLevel.transform.parent = gameObject.transform;

                _levels.Add(newLevel);
            }
        }

    }

    private void OnDisable()
    {
        for (int i = 0; i < _levels.Count; i++)
        {
            Destroy(_levels[i]);
        }

        _levels.Clear();
    }
}