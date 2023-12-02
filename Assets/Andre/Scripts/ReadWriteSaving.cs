using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReadWriteSaving : MonoBehaviour
{
    public InputField NameInput;

    public void Save()
    {
       SavingManager data = new SavingManager();
       data.Name = NameInput.text;

       string json = JsonUtility.ToJson(data, true);
       File.WriteAllText(Application.dataPath+"/SavingManager.Json", json);
    }

    public void Load()
    {
        string json = File.ReadAllText(Application.dataPath + "/SavingManager.Json");
        SavingManager data = JsonUtility.FromJson<SavingManager>(json);

        NameInput.text = data.Name;
    }
}
