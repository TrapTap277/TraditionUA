using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirstTask : MonoBehaviour
{
    [SerializeField] private GameObject _eggPrefab;
    [SerializeField] private List<Sprite> _eggsSpritesPrefabs = new();
    [SerializeField] private List<GameObject> _eggsCounterChecker = new();
    [SerializeField] private CountCollectedEggs _countCollectedEggs;

    public static int _isDoneChecker = 0;

    public void TakeFirstTask()
    {
        int number = 0;

        if (_isDoneChecker == 0)
            number = 34;

        if (_isDoneChecker == 1)
            number = 22;

        if (_isDoneChecker == 2)
            number = 0;

        if (_isDoneChecker == 3)
            CountCollectedEggs.Singleton.FinishFirstTask();

        if (_isDoneChecker <= 2 && CountCollectedEggs._eggs.Count == 0)
            StartCoroutine(TimerForStartingFirstTask(_eggsSpritesPrefabs, number));
    }

    private IEnumerator TimerForStartingFirstTask(List<Sprite> eggsSprites, int number)
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < eggsSprites.Count - number; i++)
        {
            float randomX = Random.Range(8, -20);
            float positionY = 1.0f;
            float randomZ = Random.Range(-10, 19);
            int randomSprite = Random.Range(1, eggsSprites.Count - number);

            Vector3 randomPositions = new Vector3(randomX, positionY, randomZ);

            GameObject newEgg = Instantiate(_eggPrefab, randomPositions,
                Quaternion.Euler(40.0f, 0.0f, 0.0f));
            newEgg.GetComponent<SpriteRenderer>().sprite = eggsSprites[randomSprite];

            _eggsCounterChecker.Add(newEgg);
        }

        _isDoneChecker++;

        _countCollectedEggs.FindAllEggs();

        if (_isDoneChecker != 3)
        {
            PassingAndTakingTasks.SingleTon.TakeFirstTask();
        }
    }

    private void OnEnable() => PassingAndTakingTasks.OnTakenFirstTask += TakeFirstTask;
    private void OnDisable() => PassingAndTakingTasks.OnTakenFirstTask -= TakeFirstTask;
}
