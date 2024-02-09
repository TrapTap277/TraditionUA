using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThirdTask : MonoBehaviour
{
    public static int AddNewCarrotsCount;

    [SerializeField] private GameObject _carrot;

    [SerializeField] private List<Transform> _positions = new List<Transform>();

    private const int Default = 10;

    private const float QuaternionRotation = 15.0f;

    private List<int> usedIndices = new List<int>();

    public void OnThirdTask()
    {
        AddNewCarrotsCount = Default;
        StartCoroutine(CarrotSpawner());
    }

    public IEnumerator CarrotSpawner()
    {
        Quaternion rototationX = Quaternion.Euler(QuaternionRotation, 0, 0);

        for (int i = 0; i < AddNewCarrotsCount; i++)
        {
            yield return new WaitForSeconds(1f);

            int randomIndex = GetRandomIndex();

            usedIndices.Add(randomIndex);

            Instantiate(_carrot, _positions[randomIndex].position, rototationX);

            Debug.Log(randomIndex);
        }
    }

    private int GetRandomIndex()
    {
        int randomIndex = Random.Range(0, _positions.Count);

        while (usedIndices.Contains(randomIndex))
        {
            randomIndex = Random.Range(0, _positions.Count);
        }

        return randomIndex;
    }

    private void OnEnable() => PassingAndTakingTasks.OnTakenThirdTask += OnThirdTask;

    private void OnDisable() => PassingAndTakingTasks.OnTakenThirdTask -= OnThirdTask;

}