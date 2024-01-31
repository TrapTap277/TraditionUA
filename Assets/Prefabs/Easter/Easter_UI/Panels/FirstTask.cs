using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirstTask : MonoBehaviour
{
    public static event Action OnStartedTimer;
    public static event Action<float> OnGivenMoreTime;

    [SerializeField] private GameObject _eggPrefab;
    [SerializeField] private List<Sprite> _eggsSpritesPrefabs = new();
    [SerializeField] private List<GameObject> _eggsCounterChecker = new();
    [SerializeField] private CountCollectedEggs _countCollectedEggs;

    public static int _isDoneChecker = 0;

    private Coroutine _timerCoroutine;
    private bool _isStarted;

    public void Update()
    {
        if (_isDoneChecker <= 3 && _isStarted)
            OnStartedTimer?.Invoke();
    }

    public void TakeFirstTask()
    {
        int number = 0;
        float time = 0;

        if (_isDoneChecker <= 2 && CountCollectedEggs._eggs.Count == 0)
        {
            if (_isDoneChecker == 0)
            {
                number = 34;
                time = 15;
            }


            if (_isDoneChecker == 1)
            {
                number = 22;
                time = 30;
            }


            if (_isDoneChecker == 2)
            {
                number = 0;
                time = 60;
            }

            if (_timerCoroutine == null)
            {
                _timerCoroutine = StartCoroutine(TimerForStartingFirstTask(_eggsSpritesPrefabs, number, time));
            }
        }

        if (_isDoneChecker == 3)
            CountCollectedEggs.Singleton.FinishFirstTask();

        _isStarted = true;
    }

    private IEnumerator TimerForStartingFirstTask(List<Sprite> eggsSprites, int number, float time)
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

        OnGivenMoreTime?.Invoke(time);

        yield return new WaitForSeconds(1);

        OnStartedTimer?.Invoke();

        _timerCoroutine = null;
    }

    public void Lose()
    {
        Debug.Log("You Lost... :( ");
    }

    private void OnEnable()
    {
        PassingAndTakingTasks.OnTakenFirstTask += TakeFirstTask;
        EasterTimer.OnLost += Lose;
    }

    private void OnDisable()
    {
        PassingAndTakingTasks.OnTakenFirstTask -= TakeFirstTask;
        EasterTimer.OnLost -= Lose;
    }
}
