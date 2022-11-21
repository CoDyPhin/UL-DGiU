using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    float speed = 0f;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position[0] >= 9){
            Destroy(this.gameObject);
        }
    }

}
