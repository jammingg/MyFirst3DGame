using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()

    {        
        Debug.Log("start game...");
        SceneManager.LoadScene("Game");
        
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("quit game...");
        Application.Quit();

    }
}
