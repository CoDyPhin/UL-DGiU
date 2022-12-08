
using UnityEngine;
using UnityEngine.UI;

public class ProjectileManager : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject projectileHolder;

    [SerializeField]
    private Animator characterAnimator;

    private float speed = 8f;
    private float reloadTime = 0.5f;
    private float lastShotTime;
    private float shotgunTimer;
    private float rifleTimer;

    private bool shotgun = false;
    private bool rifle = false;

    // Start is called before the first frame update
    void Start()
    {
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(shotgun){
            if(Time.time - shotgunTimer >= 5){
                shotgun = false;
                characterAnimator.SetBool("shotgun", false);
            }
        }
        if(rifle){
            if(Time.time - rifleTimer >= 5){
                rifle = false;
                characterAnimator.SetBool("rifle", false);
                reloadTime = 0.5f;
            }
        }
    }

    public void Shoot(float x, float y){
        
        if(Time.time - lastShotTime >= reloadTime){
            Vector2 offset = new Vector2(1.2f, 0.3f);
            GameObject bullet = GameObject.Instantiate(bulletPrefab, new Vector2(x+offset.x, y+offset.y), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            bullet.transform.SetParent(projectileHolder.transform);
            bullet.GetComponent<ProjectileBehavior>().SetSpeed(speed);
            if(shotgun){
                GameObject bullet2 = GameObject.Instantiate(bulletPrefab, new Vector2(x+offset.x, y+offset.y), Quaternion.identity);
                bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.5f);
                bullet2.transform.SetParent(projectileHolder.transform);
                bullet2.GetComponent<ProjectileBehavior>().SetSpeed(speed);
                GameObject bullet3 = GameObject.Instantiate(bulletPrefab, new Vector2(x+offset.x, y+offset.y), Quaternion.identity);
                bullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, -0.5f);
                bullet3.transform.SetParent(projectileHolder.transform);
                bullet3.GetComponent<ProjectileBehavior>().SetSpeed(speed);
            }
            lastShotTime = Time.time;
        }

    }

    public void setShotgun(){
        if(rifle){
            rifle = false;
            characterAnimator.SetBool("rifle", false);
        }
        shotgunTimer = Time.time;
        shotgun = true;
    }

    public void setRifle(){
        if(shotgun){
            shotgun = false;
            characterAnimator.SetBool("shotgun", false);
        }
        rifleTimer = Time.time;
        rifle = true;
        reloadTime = 0.075f;
    }
}
