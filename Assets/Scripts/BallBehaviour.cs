using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private bool startGame = false;
    private Rigidbody2D ballRigidBody;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float defaultSpeed;
    private float previousVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballRigidBody.linearVelocityY = -1 * defaultSpeed;

    }
    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if (input != 0 && startGame == false)
        {
            startGame = true;
            Debug.Log("Game Started");
            //ballRigidBody.linearVelocityY = -1 * defaultSpeed;
        }
    }

    private void FixedUpdate()
    {
        previousVelocity = ballRigidBody.linearVelocity.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 currentDirection = ballRigidBody.linearVelocity.normalized;
        Debug.Log(previousVelocity);
        Quaternion angle;
        if (collision.collider.gameObject.CompareTag("90°"))
        {
            Debug.Log("Center");
            //ballRigidBody.linearVelocity = new Vector2(0f, -1 * previousVelocity);
            angle = Quaternion.Euler(0, 0, 90f);
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
            angle = Quaternion.Euler(0, 0, 180f);
            Vector2 direction = angle * Vector2.right;
            ballRigidBody.linearVelocity = direction * previousVelocity;
        }
        else 
        {
            ballRigidBody.linearVelocity = currentDirection * (previousVelocity + 0.25f);
        }
    }
}
