using UnityEngine;

public class brickEffectRadius : MonoBehaviour
{
    private BrickController parentBrickController;
    public bool radiusAnimationComplete;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radiusAnimationComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (radiusAnimationComplete == true)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }

    public void onRadiusGrowComplete()
    {
        parentBrickController = GetComponentInParent<BrickController>();
        radiusAnimationComplete = true;
    }
}
