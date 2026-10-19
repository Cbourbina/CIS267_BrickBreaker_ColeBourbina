using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2GUIHandler : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text scoreDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.text;
    }
    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }

    public void playAgain()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
