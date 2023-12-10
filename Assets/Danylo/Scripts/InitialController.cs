using System.Collections.Generic;
using Base;
using UnityEngine;
using UnityEngine.Serialization;

public class InitialController : MonoBehaviour 
{
    //Сюди в інспекторі вкласти всі префаби менеджерів
    [SerializeField] private UIManager uiManager;
    
    private List<IManager> managerPrefabs = new List<IManager>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        RegisterManagers();
        InitializeManagers();
    }

    private void RegisterManagers()
    {
        managerPrefabs.Add(uiManager);
        Register.Add(uiManager);
    }

    private void InitializeManagers()
    {
        managerPrefabs.ForEach(e => e.Init());
    }

    private void DisposeManagers()
    {
        managerPrefabs.ForEach(e => e.Dispose());
        managerPrefabs.Clear();
        Register.Remove(uiManager);
    }

    private void OnDestroy()
    {
        DisposeManagers();
    }
}
