using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour {

    public TMP_InputField nameField;
    public TextMeshProUGUI scoreField;
    private string userName = "";
    private int highScore = 0;
    private string highScoreName = "";


    // Start is called before the first frame update
    void Start() {
        
        if (DataStore.Instance != null) {
            userName = DataStore.Instance.userName;
            highScore = DataStore.Instance.highScore;
            highScoreName = DataStore.Instance.highScoreName;
        }

        if (SceneManager.GetActiveScene().name == "menu") {

            if (!string.IsNullOrEmpty(userName)) {
                nameField.text = userName;
            }

            if (string.IsNullOrEmpty(highScoreName)) {
                scoreField.text = "...is nothing. You are first!!";
            } else {
                scoreField.text = highScore + " by " + highScoreName;
            }

        } else if (SceneManager.GetActiveScene().name == "main") {

            if (string.IsNullOrEmpty(highScoreName)) {
                highScoreName = userName;
                DataStore.Instance.highScoreName = highScoreName;
            }

        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void StartGame() {

        userName = nameField.text;
        DataStore.Instance.userName = userName;

        if (string.IsNullOrEmpty(userName)) {
            Debug.Log("We have no username!");
        } else {
            SceneManager.LoadScene(1);
        }
    }

    public void Exit() {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }

}
