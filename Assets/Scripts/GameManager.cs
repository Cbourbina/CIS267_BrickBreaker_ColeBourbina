using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasRenderer startTimerPanel;
    public TMP_Text startTimer;
    public TMP_Text livesRemaining;
    public TMP_Text bricksRemaining;
    public TMP_Text tip;
    private float startGameTimer;
    public bool timerStarted;
    public TMP_Text finalScore;
    public PlayerScore curScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTimerPanel.SetAlpha(0f);
        startTimer.enabled = false;
        //tip.enabled = false;
        timerStarted = false;
        startGameTimer = 0f;
        timerStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted == false)
        {
            tip.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && timerStarted == false)
        {
            timerStarted = true;
            startTimerPanel.SetAlpha(1f);
            startTimer.enabled = true;
            tip.enabled = false;
            timerStarted = true;
        }
        updateHighScore();
    }

    private void FixedUpdate()
    {
        if (timerStarted == true && startTimer.enabled == true)
        {
            startGameTimer += Time.deltaTime;
            startTimer.text = (3 - ((int)startGameTimer)).ToString();
            if (startGameTimer >= 3)
            {
                startTimerPanel.SetAlpha(0f);
                startTimer.enabled = false;
                tip.enabled = false;
                startGameTimer = 0f;
            }
        }
    }

    public void updateLivesDisplay(int lives)
    {
        livesRemaining.text = lives.ToString();
    }

    public void updateBricksDisplay(int bricks)
    {
        bricksRemaining.text = bricks.ToString();
    }

    public void updateHighScore()
    {
        if (curScore.getScore() > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", curScore.getScore());
        }
    }

}
