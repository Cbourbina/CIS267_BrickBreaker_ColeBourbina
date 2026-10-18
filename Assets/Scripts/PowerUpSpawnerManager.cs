using UnityEngine;

public class PowerUpSpawnerManager : MonoBehaviour
{
    public GameObject doubleScoreCollectable;
    public GameObject enlargePaddleCollectable;
    public GameObject halfScorecollectable;
    private GameObject collectableToSpawn;
    private float randomNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCollectable();
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnCollectable()
    {
        randomNumber = Random.Range(0, 3);
        if (randomNumber == 0)
        {
            collectableToSpawn = Instantiate(doubleScoreCollectable);
        }
        else if (randomNumber == 1)
        {
            collectableToSpawn = Instantiate(enlargePaddleCollectable);
        }
        else if (randomNumber == 2)
        {
            collectableToSpawn = Instantiate(halfScorecollectable);
        }
        collectableToSpawn.transform.position = this.transform.position;
    }

}
