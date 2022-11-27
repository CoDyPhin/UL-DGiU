using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    Rigidbody2D body;
    
    void Start()
    {
        GameObject background = GameObject.Find("Background");
        float basespeed = background.GetComponent<CameraMovement>().GetSpeed();
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(-basespeed-1f, Random.Range(-3f, 3f));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -17.8) Destroy(gameObject);
        if(transform.position.y > 4.15){
            body.velocity = new Vector2(body.velocity.x, -body.velocity.y);
        }
        if(transform.position.y < -2.6){
            body.velocity = new Vector2(body.velocity.x, -body.velocity.y);
        }
    }
}
