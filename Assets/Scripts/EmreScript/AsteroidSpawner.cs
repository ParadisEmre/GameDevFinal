using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject redAsteroidPrefab;
    public GameObject blueAsteroidPrefab;
    public Transform shipTransform;
    public float spawnRate = 1f;
    public float timer = 0f;
    public float minForce = 1f;
    public float maxForce = 5f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(shipTransform != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {

                if(Random.Range(0f, 1f) < 0.5f)
                {
                    SpawnRedAsteroid();
                }
                else
                {
                    SpawnBlueAsteroid();
                }
                timer = spawnRate;
            }
        }
    }

    public void SpawnRedAsteroid()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Vector3 direction = GetSpawnDirection(spawnPosition);
        
        GameObject asteroid = Instantiate(redAsteroidPrefab, spawnPosition, Quaternion.identity);

        Rigidbody asteroidRigidbody = asteroid.GetComponent<Rigidbody>();
        asteroidRigidbody.AddForce(direction * Random.Range(minForce, maxForce), ForceMode.Impulse);

        asteroid.transform.rotation = Random.rotation;
    }

    public void SpawnBlueAsteroid()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Vector3 direction = GetSpawnDirection(spawnPosition);

        GameObject asteroid = Instantiate(blueAsteroidPrefab, spawnPosition, Quaternion.identity);

        Rigidbody asteroidRigidbody = asteroid.GetComponent<Rigidbody>();
        asteroidRigidbody.AddForce(direction * Random.Range(minForce, maxForce), ForceMode.Impulse);

        asteroid.transform.rotation = Random.rotation;
    }

    public Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        
        int side = Random.Range(0, 4);
        float spawnDistance = Random.Range(10f, 20f);

        
        switch (side)
        {
            case 0:
                spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1f, spawnDistance));
                break;
            case 1:
                spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 0f, spawnDistance));
                break;
            case 2:
                spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(0f, Random.Range(0f, 1f), spawnDistance));
                break;
            case 3:
                spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(1f, Random.Range(0f, 1f), spawnDistance));
                break;
        }

        spawnPosition.z = 0f; 

        if (shipTransform != null)
        {
            Vector3 shipPosition = shipTransform.position;
            shipPosition.z = 0f;
            spawnPosition = shipPosition + (spawnPosition - shipPosition).normalized * spawnDistance;
        }

        return spawnPosition;
    }

    public Vector3 GetSpawnDirection(Vector3 spawnPosition)
    {
        if (shipTransform != null)
        {
            Vector3 direction = (shipTransform.position - spawnPosition).normalized;
            return direction;
        }

        return Vector3.zero;
    }
}