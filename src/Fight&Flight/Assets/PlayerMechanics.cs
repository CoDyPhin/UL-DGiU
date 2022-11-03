using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    private bool pressingSpace = false;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pressingSpace){
            body.AddForce(new Vector2(0, 30), ForceMode2D.Force);
        }
    }

    void OnFly()
    {
        pressingSpace = !pressingSpace;
    }
}
