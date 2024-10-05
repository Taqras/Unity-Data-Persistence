using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

}
