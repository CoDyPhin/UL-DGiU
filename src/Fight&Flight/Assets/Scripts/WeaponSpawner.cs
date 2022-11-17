using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    private float spawnTimer = 10.0f;
    private float startTime = 0.0f;
    
    [SerializeField]
    private GameObject shotgunPrefab;

    [SerializeField]
    private GameObject riflePrefab;
    
    [SerializeField]
    private GameObject weaponHolder;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        // create an empty gameobject to hold the weapons
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > spawnTimer){
            startTime = Time.time;
            if(weaponHolder.transform.childCount == 0){
                SpawnWeapon();
            }
        }
    }

    void SpawnWeapon()
    {
        float y = Random.Range(-3.0f, 4.5f);
        float x = 24.0f;
        GameObject weapon;
        int weaponType = Random.Range(0, 2);
        if(weaponType == 0){
            weapon = GameObject.Instantiate(shotgunPrefab, new Vector3(x, y, 0), Quaternion.identity);
            weapon.transform.parent = weaponHolder.transform;
        }
        else{
            weapon = GameObject.Instantiate(riflePrefab, new Vector3(x, y, 0), Quaternion.identity);
            weapon.transform.parent = weaponHolder.transform;
        }

    }
}
