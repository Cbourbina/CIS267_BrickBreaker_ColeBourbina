using UnityEngine;
using UnityEngine.SceneManagement;
public class GUIButtonHandler : MonoBehaviour
{
    private int randomNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }

    public void mainMenuPlay()
    {
        randomNum = Random.Range(0, 2);
        if (randomNum == 0)
        {
            SceneManager.LoadScene("Level 1");
        }
        else 
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
