using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour {
     
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void ReturnToMainMenu () {
        SceneManager.LoadScene("Menu");
    }
     
}
