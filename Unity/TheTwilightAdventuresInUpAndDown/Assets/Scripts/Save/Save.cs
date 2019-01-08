using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour {

    public SaveData saveData;
    public static string dataPath;

	// Use this for initialization
	void Start () {
        dataPath = Path.Combine(Application.persistentDataPath, "SaveData.txt");
        Debug.Log(dataPath);
    }

    static void SaveGame (SaveData data, string path)
    {
        string jsonString = JsonUtility.ToJson(data);

        using (StreamWriter streamWriter = File.CreateText(path))
        {
            streamWriter.Write(jsonString);
        }
    }

    public static SaveData LoadGame (string path)
    {
        
        using (StreamReader streamReader = File.OpenText(path))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<SaveData>(jsonString);
        }
    }
}
