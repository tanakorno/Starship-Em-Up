using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    //public enum MenuStates { Play, Score, Help, Exit };

    void Awake() {

    }

    void Start() {
        CheckFile();    
    }


    void Update() {

    }


    void CheckFile() {
        string path = Application.dataPath + "/Resources/score.txt";
        if (!File.Exists(path)) {
            File.Create(path);
        }
    }

    public void OnPlayGame() {
        SceneManager.LoadScene("PlayGame");
    }

    public void OnScoreBoard() {
        SceneManager.LoadScene("ScoreBoard");
    }

    public void OnHelp() {
        SceneManager.LoadScene("Help");
    }

    public void OnQuitGame() {
        Application.Quit();
    }
}
