using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Rigidbody2D paddleRigidBody;
    public bool gameStarted;
    public bool paddleGrown;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paddleRigidBody = GetComponent<Rigidbody2D>();
        gameStarted = false;
        paddleGrown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted == true)
        {
            movePaddleLateral();
        }
        if (paddleGrown == true)
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                paddleGrown = false;
                GetComponent<Animator>().SetTrigger("startPaddleShrink");
                timer = 0f;
            }
            Debug.Log("Timer: " + timer);
        }
    }

    private void movePaddleLateral()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            paddleRigidBody.linearVelocity = new Vector2(inputHorizontal * (moveSpeed * 2), 0f);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            paddleRigidBody.linearVelocity = new Vector2(inputHorizontal * (moveSpeed / 2), 0f);
        }
        else
        {
            paddleRigidBody.linearVelocity = new Vector2(inputHorizontal * moveSpeed, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameStarted == false)
        {
            gameStarted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Debug.Log("Collectable Collected");
            Destroy(collision.gameObject);
        }
    }
}
