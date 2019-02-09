using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform rocketBarrel;
    public GameObject enemyPrefab;

    private float lastSpawned;

    private void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    private void Update()
    {
        var v = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, v * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(rocketPrefab, rocketBarrel.position, Quaternion.LookRotation(rocketBarrel.forward));
        }

        // Spawn enemy
        bool shouldSpawn = (Time.time - lastSpawned) > 3.0f;
        if (shouldSpawn)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        lastSpawned = Time.time;

        Instantiate(enemyPrefab, new Vector3(-9.0f, Random.Range(-5.0f, 5.0f)), Quaternion.LookRotation(enemyPrefab.transform.forward));
    }

}
