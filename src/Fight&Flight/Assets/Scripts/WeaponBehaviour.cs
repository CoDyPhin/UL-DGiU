using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    private float speed = -6.0f;
    private Rigidbody2D body;
    private bool secondAttempt = true;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(speed, -1.0f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position[0] < -10.0f){
            if(secondAttempt){
                secondAttempt = false;
                transform.position = new Vector3(24.0f, startY, 0);
            }
            else{
                Destroy(gameObject);
            }
        }
        if(transform.position[1] > startY+0.2f || transform.position[1] < startY-0.2f){
            body.velocity = new Vector2(speed, body.velocity[1]*-1.0f);
        }
    }
}
