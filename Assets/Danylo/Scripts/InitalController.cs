using System.Collections.Generic;
using UnityEngine;

public class InitalController : MonoBehaviour
{
    //Сюди в інспекторі вкласти всі префаби менеджерів
    [SerializeField] private List<GameObject> managerPrefabs = new List<GameObject>();

    private List<IManager> _imanagers = new List<IManager>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        foreach (GameObject managerPrefab in managerPrefabs)
        {
            IManager manager;
            if (managerPrefab != null && managerPrefab.TryGetComponent(out manager))
            {
                GameObject managerObject = Instantiate(managerPrefab, transform.position, Quaternion.identity);

                manager.Init();
                _imanagers.Add(manager);
            }
            else
            {
                Debug.LogWarning("The manager prefab does not implement the IManager interface or manager prefab exactly null.");
            }
        }
    }

    private void DisposeManagers()
    {
        foreach (IManager manager in _imanagers)
        {
            manager.Dispose();

            GameObject managerObject = (manager as MonoBehaviour).gameObject;
            Destroy(managerObject);
        }

        _imanagers.Clear();
    }

    private void OnDestroy()
    {
        DisposeManagers();
    }
}
