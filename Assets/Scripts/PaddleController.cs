using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Rigidbody2D paddleRigidBody; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paddleRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePaddleLateral();
    }

    private void movePaddleLateral()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        paddleRigidBody.linearVelocity = new Vector2(inputHorizontal * moveSpeed, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
