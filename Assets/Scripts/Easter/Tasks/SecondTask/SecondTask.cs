using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SecondTask : MonoBehaviour
{
    public static event Action OnStartedTask;

    [SerializeField] private GameObject _eggPrefab;

    private List<float> _positionY = new List<float>();
    private int _randomSprite;

    public void Start()
    {
        _positionY.Add(15);
        _positionY.Add(13.3f);
        _positionY.Add(11.9f);
        _positionY.Add(10.5f);
    }

    public void OnSecondTask()
    {
        for (int i = 0; i < 4; i++)
        {
            float randomX = Random.Range(-10, -3);
            float positionZ = 37.6f;
            int randomY = Random.Range(0, 3);
            _randomSprite = Random.Range(0, Shooting.Singleton._eggsSprites.Count);

            Vector3 randomPositions = new Vector3(randomX, _positionY[randomY], positionZ);
            GameObject newEgg = Instantiate(_eggPrefab, randomPositions, Quaternion.identity);
            newEgg.GetComponent<SpriteRenderer>().sortingOrder = 1;
            Shooting.Singleton.ChangeRandomSprite(newEgg, _randomSprite);
            newEgg.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        OnStartedTask?.Invoke();
    }

    private void OnEnable() => PassingAndTakingTasks.OnTakenSecondTask += OnSecondTask;

    private void OnDisable() => PassingAndTakingTasks.OnTakenSecondTask -= OnSecondTask;
}
