using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountCollectedEggs : MonoBehaviour
{
    public static event Action OnCollectedAllEggs;
    public List<GameObject> _eggs = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI _currentCountOfEggsTMP;
    [SerializeField] private TextMeshProUGUI _neddedCountOfEggsTMP;

    private int _neddedCountOfEggs = 10;

    public void Start()
    {
        foreach (var egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            _eggs.Add(egg);
        }

        _neddedCountOfEggs = _eggs.Count;
        _neddedCountOfEggsTMP.text = _neddedCountOfEggs.ToString();

        ChangeCurrentNumberOfCollectedEggs();

        for (int i = 0; i < _eggs.Count; i++)
        {
            _eggs[i].GetComponent<EggsPickUpper>().OnPickedUp += CheckCollectedEggs;

        }

    }

    public void Update()
    {
        // TODO - This needs to be removed

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CollectAllEggs();
        }
    }

    public void CheckCollectedEggs(GameObject currentGameObject)
    {

        _eggs.Remove(currentGameObject);
        Destroy(currentGameObject);

        ChangeCurrentNumberOfCollectedEggs();

        if (_eggs.Count == 0)
        {
            CollectAllEggs();
        }
    }

    private void CollectAllEggs()
    {
        OnCollectedAllEggs?.Invoke();
    }

    private void ChangeCurrentNumberOfCollectedEggs()
    {
        int count = 8 - _eggs.Count;
        _currentCountOfEggsTMP.text = count.ToString();
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _eggs.Count; i++)
        {
            _eggs[i].GetComponent<EggsPickUpper>().OnPickedUp -= CheckCollectedEggs;
        }
    }
}
