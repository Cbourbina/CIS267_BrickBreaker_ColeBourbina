using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasRenderer startTimerPanel;
    public TMP_Text startTimer;
    public TMP_Text livesRemaining;
    public TMP_Text bricksRemaining;
    private float startGameTimer;
    public bool timerStarted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTimerPanel.SetAlpha(0f);
        startTimer.enabled = false;
        timerStarted = false;
        startGameTimer = 0f;
        timerStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timerStarted == false)
        {
            timerStarted = true;
            startTimerPanel.SetAlpha(1f);
            startTimer.enabled = true;
            timerStarted = true;
        }
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
}
