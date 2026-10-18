using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int playerScore;
    public TMP_Text guiScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScore = 0;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public int getScore()
    {
        return playerScore;
    }

    public void setPlayerScore(int val)
    {
        playerScore = val;
        setGUIPlayerScore();
    }

    public void setGUIPlayerScore()
    {
        guiScore.text = playerScore.ToString();
    }
}
