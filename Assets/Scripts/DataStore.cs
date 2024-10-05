using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataStore : MonoBehaviour {
    public static DataStore Instance;
    public string userName = "";
    public int highScore = 0;
    public string highScoreName = "";

    private void Awake() {

        // Singleton
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData {
        public int highScore = 0;
        public string highScoreName = "";
    }

    public void SaveScore() {

        SaveData data = new SaveData();

        data.highScore = highScore;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadScore() {

        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path)) {

            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;

        }

    }

}
