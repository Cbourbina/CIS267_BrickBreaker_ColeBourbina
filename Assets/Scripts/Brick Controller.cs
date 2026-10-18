using UnityEngine;

public class BrickController : MonoBehaviour
{
    private float brickHealth;
    private float explosionDamage = 2;
    private float randomNumber;
    private bool effectedByRadius;
    private bool isFrozen;
    public GameObject collectableSpawner;
    private GameObject objectToSpawn;
    private Collider2D radiusCollision;
    public Sprite brickSprite;
    public Sprite frozenSprite;
    public Sprite[] steelSprites;
    private SpriteRenderer spriteRenderer;
    private int brickScore;
    //public bool radiusAnimationComplete = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (CompareTag("Explosive"))
        {
            brickHealth = 1;
            brickScore = 10;
        }
        else if (CompareTag("Ice"))
        {
            brickHealth = 1;
            brickScore = 5;
        }
        else if (CompareTag("Steel"))
        {
            brickHealth = 3;
            brickScore = 50;
        }
        else 
        {
            brickHealth = 1;
            brickScore = 10;
        }
        effectedByRadius = false;
        isFrozen = false;
        randomNumber = Random.Range(0, 100);
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
                if (CompareTag("Explosive"))
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
                    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = frozenSprite;
                }
            }
        }
        if (CompareTag("Steel") && isFrozen == false)
        {
            if (brickHealth == 3)
            {
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = steelSprites[0];
            }
            else if (brickHealth == 2)
            {
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = steelSprites[1];
            }
            else
            {
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = steelSprites[2];
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
            collision.gameObject.GetComponent<BallBehaviour>()?.setScoreTemp((int)(brickScore));
            collision.GetComponent<BallBehaviour>().slowBall();
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("startGrow");
            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (collision.gameObject.CompareTag("Ball") && isFrozen == true)
        {
            collision.GetComponent<BallBehaviour>().slowBall();
            if (randomNumber < 20)
            {
                spawnCollectableSpawner();
            }
            collision.gameObject.GetComponent<BallBehaviour>()?.setScoreTemp((int)(brickScore));
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
                transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = null;
                collision.gameObject.GetComponent<BallBehaviour>()?.setScoreTemp((int)(brickScore));
            }
            else if (CompareTag("Ice"))
            {
            }
            else
            {
                brickHealth -= 1;
                if (brickHealth <= 0)
                {
                    if (randomNumber < 20)
                    {
                        spawnCollectableSpawner();
                    }
                    collision.gameObject.GetComponent<BallBehaviour>()?.setScoreTemp((int)(brickScore));
                    Destroy(this.gameObject);
                }
            }
        }    
    }

    private void spawnCollectableSpawner()
    {
        objectToSpawn = Instantiate(collectableSpawner);
        objectToSpawn.transform.position = this.transform.position;
    }
}
