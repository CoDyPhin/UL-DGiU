using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMechanics : MonoBehaviour
{
    private bool pressingSpace = false;
    private bool firing = false;
    private Rigidbody2D body;
    private Animator anim;
 
    [SerializeField]
    private ProjectileManager ProjectileManager;

    [SerializeField]
    private WeaponSpawner WeaponSpawner;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pressingSpace){
            anim.SetBool("flying", true);
            body.AddForce(new Vector2(0, 30), ForceMode2D.Force);
        }
        else anim.SetBool("flying", false);

        if(firing && anim.GetBool("rifle")){
            ProjectileManager.Shoot(transform.position[0], transform.position[1]);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Weapon"){
            // TODO: Change the weapon and the shooting behaviour
            Debug.Log("Picked up weapon " + other.gameObject.name);
            if(other.gameObject.name.Contains("Shotgun")){
                anim.SetBool("shotgun", true);
                ProjectileManager.setShotgun();
            }
            else if (other.gameObject.name.Contains("Rifle")){
                anim.SetBool("rifle", true);
                ProjectileManager.setRifle();
            }
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Obstacle"){
            // TODO: Transition to game over screen

            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
            // Time.timeScale = 0;
        }
    }

    void OnFly()
    {
        pressingSpace = !pressingSpace;
    }

    void OnFire()
    {
        firing = !firing;
        if(firing){
            ProjectileManager.Shoot(transform.position[0], transform.position[1]);
        }
    }
}
