using UnityEngine;
using UnityEngine.SceneManagement;
public class GUIButtonHandler : MonoBehaviour
{
    private int randomNum;
    private int sceneLoaded;
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
            sceneLoaded = 1;
        }
        else 
        {
            SceneManager.LoadScene("Level 2");
            sceneLoaded = 2;
        }
    }

    public void playAgain()
    {
        if (sceneLoaded == 1)
        {
            Debug.Log(sceneLoaded);
            //SceneManager.LoadScene("Level 1");
        }
        else if (sceneLoaded == 2)
        {
            Debug.Log(sceneLoaded);
            //SceneManager.LoadScene("Level 2");
        }
    }
}
