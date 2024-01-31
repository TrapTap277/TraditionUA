using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountCollectedEggs : MonoBehaviour
{
    public static CountCollectedEggs Singleton;

    public static event Action OnCollectedAllEggs;
    public static List<GameObject> _eggs = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI _currentCountOfEggsTMP;
    [SerializeField] private TextMeshProUGUI _neddedCountOfEggsTMP;

    private int _neddedCountOfEggs;
    private int _collectedEggs;

    private bool _isDone;

    public void Start() => Singleton = this;

    public void FindAllEggs()
    {
        foreach (var egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            _eggs.Add(egg);

            _neddedCountOfEggs++;
        }

        foreach (var egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            egg.tag = "Untagged";
        }


        _neddedCountOfEggsTMP.text = _neddedCountOfEggs.ToString();

        ChangeCurrentNumberOfCollectedEggs();

        for (int i = 0; i < _eggs.Count; i++)
        {
            _eggs[i].GetComponent<EggsPickUpper>().OnPickedUp += CheckCollectedEggs;
        }
    }

    public void CheckCollectedEggs(GameObject currentGameObject)
    {
        if (_isDone)
            return;

        if (_eggs.Contains(currentGameObject))
        {
            StartCoroutine(DelayedDestroy(currentGameObject));
        }

        if (_eggs.Count == 0 && FirstTask._isDoneChecker == 3)
        {
            FinishFirstTask();
        }
    }

    private IEnumerator DelayedDestroy(GameObject obj)
    {
        yield return null;

        _eggs.Remove(obj);
        Destroy(obj);

        _collectedEggs++;
        ChangeCurrentNumberOfCollectedEggs();
        _isDone = true; 
        StartCoroutine(ChangeIsDone());
    }

    private IEnumerator ChangeIsDone()
    {
        yield return null;
        _isDone = false;
    }

    private void ChangeCurrentNumberOfCollectedEggs()
    {
        _currentCountOfEggsTMP.text = _collectedEggs.ToString();
    }

    public void FinishFirstTask()
    {
        if (_eggs.Count == 0 && FirstTask._isDoneChecker == 3)
        {
            OnCollectedAllEggs?.Invoke();

            Debug.Log("Finished");
        }

    }

    private void OnDestroy()
    {
        for (int i = 0; i < _eggs.Count; i++)
        {
            _eggs[i].GetComponent<EggsPickUpper>().OnPickedUp -= CheckCollectedEggs;
        }
    }
}
