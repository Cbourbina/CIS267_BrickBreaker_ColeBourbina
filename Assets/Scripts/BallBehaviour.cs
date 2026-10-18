using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private bool startGame;
    private bool isSlowed;
    private Rigidbody2D ballRigidBody;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float defaultSpeed;
    private float previousVelocity;
    private float preSlowVelocity;
    [SerializeField]
    private float ballSpeedIncrement;
    private float timer;
    private float slowTimer;
    private float startGameTimer;
    private int gameLives = 3;
    private int bricksLeft;
    public Transform brickContainer;
    public Transform gameManager;
    private bool gameOver;
    private bool gameWon;
    GameObject paddle;
    public PlayerScore playerScore;
    private int curScore;
    private float scoreMod;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGame = false;
        isSlowed = false;
        slowTimer = 0f;
        startGameTimer = 0f;
        ballRigidBody = GetComponent<Rigidbody2D>();
        gameOver = false;
        gameWon = false;
        curScore = 0;
        scoreMod = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver != true)
        {
            if (brickContainer.childCount == 0)
            {
                gameWon = true;
                gameOver = true;
            }
            if (gameWon == true)
            {
                ballRigidBody.linearVelocity = new Vector2(0, 0);
                ballRigidBody.transform.position = new Vector2(0, -5);
                paddle = GameObject.FindGameObjectWithTag("Paddle");
                PaddleController paddleScript = paddle.GetComponent<PaddleController>();
                paddleScript.gameStarted = false;
                paddle.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
                paddle.transform.position = new Vector2(0, -6);
            }
            {
                
            }
            if (Input.GetKeyDown(KeyCode.Space) && startGame == false)
            {
                startGame = true;
                Debug.Log("Space");
            }
            if (ballRigidBody.linearVelocity.magnitude < minSpeed)
            {
                Vector2 currentDirection = ballRigidBody.linearVelocity.normalized;
                ballRigidBody.linearVelocity = currentDirection * defaultSpeed;
            }
        }
        if (bricksLeft != brickContainer.childCount)
        {
            bricksLeft = brickContainer.childCount;
            gameManager.GetComponent<GameManager>().updateBricksDisplay(bricksLeft);
        }
        //Debug.Log("Score is: " + curScore);
        playerScore.setPlayerScore(curScore);
    }

    private void FixedUpdate()
    {
        if (startGame == true && ballRigidBody.linearVelocity.magnitude == 0)
        {
            Debug.Log("Game Starting...");
            startGameTimer += Time.deltaTime;
            if (startGameTimer >= 3f)
            {
                ballRigidBody.linearVelocityY = -1 * defaultSpeed;
                startGameTimer = 0f;
                Debug.Log("Game Started");
                startGame = false;
                timer = 0f;
            }
        }
        previousVelocity = ballRigidBody.linearVelocity.magnitude;
        if (ballRigidBody.linearVelocity.magnitude != 0)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                Vector2 currentDirection = ballRigidBody.linearVelocity.normalized;
                if (previousVelocity < maxSpeed && isSlowed == false)
                {
                    previousVelocity += ballSpeedIncrement;
                }
                timer = 0f;
                ballRigidBody.linearVelocity = currentDirection * previousVelocity;
            }
        }
        if (isSlowed == true)
        {
            slowTimer += Time.deltaTime;
            if (slowTimer >= 3f)
            {
                slowTimer = 0f;
                Vector2 currentDirection = ballRigidBody.linearVelocity.normalized;
                previousVelocity = defaultSpeed;
                ballRigidBody.linearVelocity = preSlowVelocity * currentDirection;
                isSlowed = false;
            }
        }
        if (ballRigidBody.linearVelocityY < 0.1 && ballRigidBody.linearVelocityY > -0.1)
        {
            if (ballRigidBody.linearVelocityX != 0)
            {
                ballRigidBody.linearVelocity = new Vector2(ballRigidBody.linearVelocityX, 0.5f);
            }
        }
        if (ballRigidBody.linearVelocityX < 0.1 && ballRigidBody.linearVelocityX > -0.1)
        {
            if (ballRigidBody.linearVelocityY != 0)
            {
                ballRigidBody.linearVelocity = new Vector2(0.5f, ballRigidBody.linearVelocityY);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(previousVelocity);
        Quaternion angle;
        if (collision.collider.gameObject.CompareTag("90°"))
        {
            Debug.Log("Center");
            //ballRigidBody.linearVelocity = new Vector2(0f, -1 * previousVelocity);
            int randomCenterAngle = UnityEngine.Random.Range(85, 95);
            angle = Quaternion.Euler(0, 0, randomCenterAngle);
            Vector2 direction = angle * Vector2.right;
            ballRigidBody.linearVelocity = direction * previousVelocity;
        }
        else if (collision.collider.gameObject.CompareTag("70° Left"))
        {
            Debug.Log("70");
            angle = Quaternion.Euler(0, 0, 110f);
            Vector2 direction = angle * Vector2.right;
            ballRigidBody.linearVelocity = direction * previousVelocity;
        }
        else if (collision.collider.gameObject.CompareTag("70° Right"))
        {
            Debug.Log("70");
            angle = Quaternion.Euler(0, 0, 70f);
            Vector2 direction = angle * Vector2.right;
            ballRigidBody.linearVelocity = direction * previousVelocity;
        }
        else if (collision.collider.gameObject.CompareTag("45° Left"))
        {
            Debug.Log("45");
            angle = Quaternion.Euler(0, 0, 110f);
            Vector2 direction = angle * Vector2.right;
            ballRigidBody.linearVelocity = direction * previousVelocity;
        }
        else if (collision.collider.gameObject.CompareTag("45° Right"))
        {
            Debug.Log("45");
            angle = Quaternion.Euler(0, 0, 45f);
            Vector2 direction = angle * Vector2.right;
            ballRigidBody.linearVelocity = direction * previousVelocity;
        }
        else if (collision.collider.gameObject.CompareTag("30° Left"))
        {
            Debug.Log("30");
            angle = Quaternion.Euler(0, 0, 150f);
            Vector2 direction = angle * Vector2.right;
            ballRigidBody.linearVelocity = direction * previousVelocity;
        }
        else if (collision.collider.gameObject.CompareTag("30° Right"))
        {
            Debug.Log("30");
            angle = Quaternion.Euler(0, 0, 30f);
            Vector2 direction = angle * Vector2.right;
            ballRigidBody.linearVelocity = direction * previousVelocity;
        }
        else if (collision.collider.gameObject.CompareTag("15° Left"))
        {
            Debug.Log("15");
            angle = Quaternion.Euler(0, 0, 165f);
            Vector2 direction = angle * Vector2.right;
            ballRigidBody.linearVelocity = direction * previousVelocity;
        }
        else if (collision.collider.gameObject.CompareTag("15° Right"))
        {
            Debug.Log("15");
            angle = Quaternion.Euler(0, 0, 15f);
            Vector2 direction = angle * Vector2.right;
            ballRigidBody.linearVelocity = direction * previousVelocity;
        }
    }

    public void slowBall()
    {
        if (isSlowed == false)
        { 
            preSlowVelocity = previousVelocity;
        }
        Vector2 currentDirection = ballRigidBody.linearVelocity.normalized;
        float speed;
        if (isSlowed == false)
        {
            if (previousVelocity > defaultSpeed)
            {
                speed = defaultSpeed;
            }
            else
            {
                speed = minSpeed;
            }
            previousVelocity = speed;
            ballRigidBody.linearVelocity = speed * currentDirection;
            isSlowed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BottomBounds"))
        {
            gameLives--;
            gameManager.GetComponent<GameManager>().updateLivesDisplay(gameLives);
            ballRigidBody.linearVelocity = new Vector2(0, 0);
            ballRigidBody.transform.position = new Vector2 (0, -5);
            paddle = GameObject.FindGameObjectWithTag("Paddle");
            PaddleController paddleScript = paddle.GetComponent<PaddleController>();
            paddleScript.gameStarted = false;
            paddle.GetComponent<Rigidbody2D>().linearVelocity = new Vector2 (0,0);
            paddle.transform.position = new Vector2 (0, -6);
            if (gameLives <= 0)
            {
                gameOver = true;
            }
            else
            {
                gameManager.GetComponent<GameManager>().timerStarted = false;
            }
        }
    }

    public void setScoreTemp(int score)
    {
        curScore += (int)(score * scoreMod);
    }

    public void scoreModUp()
    {
        scoreMod *= 2;
    }

    public void scoreModDown()
    {
        if (scoreMod > 1)
        {
            scoreMod /= 2;
        }
    }
}
