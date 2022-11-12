
using UnityEngine;
using UnityEngine.UI;

public class ProjectileManager : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject projectileHolder;

    private float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(float x, float y){
        GameObject bullet = GameObject.Instantiate(bulletPrefab, new Vector2(x, y), Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        bullet.transform.SetParent(projectileHolder.transform);
        bullet.GetComponent<ProjectileBehavior>().SetSpeed(speed);
        
    }
}
