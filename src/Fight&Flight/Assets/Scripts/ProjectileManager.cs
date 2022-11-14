
using UnityEngine;
using UnityEngine.UI;

public class ProjectileManager : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject projectileHolder;

    private float speed = 8f;
    private float reloadTime = 0.5f;
    private float lastShotTime;

    // Start is called before the first frame update
    void Start()
    {
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(float x, float y){
        if(Time.time - lastShotTime >= reloadTime){
            Vector2 offset = new Vector2(1.2f, 0.3f);
            GameObject bullet = GameObject.Instantiate(bulletPrefab, new Vector2(x+offset.x, y+offset.y), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            bullet.transform.SetParent(projectileHolder.transform);
            bullet.GetComponent<ProjectileBehavior>().SetSpeed(speed);
            lastShotTime = Time.time;
        }
    }
}
