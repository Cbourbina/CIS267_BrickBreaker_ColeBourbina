using UnityEngine;

public class BrickController : MonoBehaviour
{
    private float brickHealth;
    private float explosionDamage = 2;
    private bool effectedByRadius;
    private bool isFrozen;
    private Collider2D radiusCollision;
    //public bool radiusAnimationComplete = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (CompareTag("Explosive"))
        {
            brickHealth = 1;
        }
        else if (CompareTag("Ice"))
        {
            brickHealth = 1;
        }
        else if (CompareTag("Steel"))
        {
            brickHealth = 3;
        }
        else 
        {
            brickHealth = 1;
        }
        effectedByRadius = false;
        isFrozen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (effectedByRadius == true)
        {
            brickEffectRadius effectRadius = radiusCollision.GetComponent<brickEffectRadius>();
            if (radiusCollision.transform.parent.gameObject.CompareTag("Explosive") && effectRadius.radiusAnimationComplete == true)
            {
                brickHealth -= explosionDamage;
                if (brickHealth <= 0)
                {
                    Destroy(this.gameObject);
                }
                effectedByRadius = false;
            }
            else if (radiusCollision.transform.parent.gameObject.CompareTag("Ice") && effectRadius.radiusAnimationComplete == true)
            {
                if (CompareTag("Ice"))
                {
                    effectedByRadius = false;
                }
                else
                {
                    brickHealth = 1;
                    isFrozen = true;
                    GetComponent<Collider2D>().isTrigger = enabled;
                    Debug.Log("Brick Is Frozen");
                    effectedByRadius = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        brickEffectRadius effectRadius = collision.GetComponent<brickEffectRadius>();
        if (collision.transform.parent != null)
        { 
            if (collision.transform.parent.gameObject.CompareTag("Explosive") || collision.transform.parent.gameObject.CompareTag("Ice"))
            {
                radiusCollision = collision;
                effectedByRadius = true;
            }
        }
        if (collision.gameObject.CompareTag("Ball") && CompareTag("Ice"))
        {
            //animate this
            collision.GetComponent<BallBehaviour>().slowBall();
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("startGrow");
        }
        if (collision.gameObject.CompareTag("Ball") && isFrozen == true)
        {
            collision.GetComponent<BallBehaviour>().slowBall();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (CompareTag("Explosive"))
            {
                GetComponent<Collider2D>().isTrigger = enabled;
                transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("startGrow");
            }
            else if (CompareTag("Ice"))
            {
            }
            else
            {
                brickHealth -= 1;
                if (brickHealth <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }    
    }
}
