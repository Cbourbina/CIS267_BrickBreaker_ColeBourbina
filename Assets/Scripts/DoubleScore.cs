using UnityEngine;

public class DoubleScore : MonoBehaviour
{
    private GameObject ball;
    private bool scoreModified;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreModified = false;
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scoreModified == false)
        {
            ball.GetComponent<BallBehaviour>().scoreModUp();
            Debug.Log("Score Mod Doubled");
            scoreModified = true;
        }
    }
}
