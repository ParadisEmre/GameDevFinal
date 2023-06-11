using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject blueAsteroidPrefab;
    public GameObject redAsteroidPrefab;
    public float spawnRadius = 10f;
    public float spawnRate = 1f;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer <= 0f && Random.Range(0, 10) > 5)
        {
            SpawnBlueAsteroid();
            timer = spawnRate;
        }
        else if(timer <= 0f && Random.Range(0, 10) <= 5)
        {
            SpawnRedAsteroid();
            timer = spawnRate;
        }
    }

    public void SpawnBlueAsteroid()
    {
        Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
        Instantiate(blueAsteroidPrefab, randomPosition, Quaternion.identity);
    }

    public void SpawnRedAsteroid()
    {
        Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
        Instantiate(redAsteroidPrefab, randomPosition, Quaternion.identity);
    }

    public Vector3 GetRandomSpawnPosition()
    {
        float viewportX = Random.Range(0f, 1f);
        float viewportY = Random.Range(0f, 1f);
        float viewportZ = mainCamera.nearClipPlane;

        return mainCamera.ViewportToWorldPoint(new Vector3(viewportX, viewportY, viewportZ));
    }

    public Vector3 GetSpawnDirection(Vector3 spawnPosition)
    {
        Vector3 screenCenter = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, mainCamera.nearClipPlane));
        return (screenCenter - spawnPosition).normalized;
    }

}
