using UnityEngine;

public class BrickSpawnerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject iceBrick;
    public GameObject steelBrick;
    public GameObject explosiveBrick;
    public GameObject standardBrick;
    
    private GameObject brickToSpawn;
    private int randomNumber;
    void Start()
    {
        spawnBrick();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void spawnBrick()
    {
        randomNumber = Random.Range(0, 10);
        if (randomNumber < 2)
        {
            brickToSpawn = Instantiate(iceBrick);
            //Debug.Log("Ice Brick Spawned");
        }
        else if (randomNumber >= 2 && randomNumber < 4)
        {
            brickToSpawn = Instantiate(steelBrick);
            //Debug.Log("Steel Brick Spawned");
        }
        else if (randomNumber >= 4 && randomNumber < 6)
        {
            brickToSpawn = Instantiate(explosiveBrick);
            //Debug.Log("Explosive Brick Spawned");
        }
        else
        {
            brickToSpawn = Instantiate(standardBrick);
            //Debug.Log("Standard Brick Spawned");
        }
        //Debug.Log("RandomNum: " + randomNumber);
        brickToSpawn.transform.position = this.transform.position;
    }
}
