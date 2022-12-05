using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] planets;
    private float spawnDelay;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        //get a random spawn delay between 5 and 30 seconds
        spawnDelay = Random.Range(5, 45);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >= spawnDelay)
        {
            //spawn the planets in order
            for(int i = 0; i < planets.Length; i++)
            {
                GameObject.Instantiate(planets[i], new Vector3(15f+i*3f, 2.5f, 0), Quaternion.identity);
            }
            //reset the timer
            startTime = Time.time;
            //get a new random spawn delay
            spawnDelay = Random.Range(45, 90);
        }
    }
}
