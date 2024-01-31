using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour
{
    public static Shooting Singleton;
    public static event Action OnTimerStarted;

    public List<Sprite> _eggsSprites = new List<Sprite>();

    [SerializeField] private LayerMask _eggSecondTask;

    [SerializeField] private Sprite _defaultSprite;

    private List<GameObject> _eggs = new List<GameObject>();

    private int _randomSprite;
    private bool _isStarted;

    private void Start()
    {
        Singleton = this;   
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (_isStarted == true)
        {
            if (Physics.Raycast(ray, out hit, 100, _eggSecondTask))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    EasterCurrentSprite easterCurrentSprite = new EasterCurrentSprite();
                    _randomSprite = Random.Range(1, _eggsSprites.Count);
                    ChangeRandomSprite(hit.transform.gameObject, _randomSprite);
                    easterCurrentSprite.CheckSprite(hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite);
                }
            }

            if (_eggs.Count == 0)
            {
                Debug.Log("0");
            }
        }
    }

    public void ChangeRandomSprite(GameObject g, int randomSprite)
    {
        //EasterCurrentSprite.Instance.ChangeType();
        g.transform.gameObject.GetComponent<SpriteRenderer>().sprite = _eggsSprites[randomSprite];
    }

    public void EggsRemover(GameObject egg)
    {
        if (_eggs.Contains(egg))
            _eggs.Remove(egg);
    }

    public void OnStartTask()
    {
        foreach (GameObject egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            _eggs.Add(egg);
        }

        OnTimerStarted?.Invoke();
    }

    public void OnStart()
    {
        for (int i = 0; i < _eggs.Count; i++)
        {
            _eggs[i].GetComponent<SpriteRenderer>().sprite = _defaultSprite;
        }
        _isStarted = true;
    }
        
    private void OnEnable()
    {
        SecondTask.OnStartedTask += OnStartTask;
        EasterTimer.OnTimeEnded += OnStart;
    }  

    private void OnDisable()
    {
        SecondTask.OnStartedTask -= OnStartTask;
        EasterTimer.OnTimeEnded -= OnStart;
    }
}
