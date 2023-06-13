using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawnerScript : MonoBehaviour
{
    public GameObject invincibleBuffPrefab;
    public GameObject scoreUpBuffPrefab;
    public Transform shipTransform;
    public float spawnRate = 20f;
    public float timer = 0f;
    public float minForce = 1f;
    public float maxForce = 5f;
    public int minScore;
    public int maxScore;

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
                    SpawnInvincibleBuff();
                }
                else
                {
                    SpawnScoreUpBuff();
                }
                timer = spawnRate;
            }
        }
    }

    public void SpawnInvincibleBuff()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Vector3 direction = GetSpawnDirection(spawnPosition);
        
        GameObject invBuff = Instantiate(invincibleBuffPrefab, spawnPosition, Quaternion.identity);

        Rigidbody invBuffRb = invBuff.GetComponent<Rigidbody>();
        invBuffRb.AddForce(direction * Random.Range(minForce, maxForce), ForceMode.Impulse);

        invBuff.transform.rotation = Random.rotation;
    }

    public void SpawnScoreUpBuff()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Vector3 direction = GetSpawnDirection(spawnPosition);
        
        GameObject scoreUpBuff = Instantiate(scoreUpBuffPrefab, spawnPosition, Quaternion.identity);

        scoreUpBuff.GetComponent<CollectibleScore>().tmp.text = "+" + Random.Range(minScore, maxScore).ToString();
        
        Rigidbody scoreUpRb = scoreUpBuff.GetComponent<Rigidbody>();
        scoreUpRb.AddForce(direction * Random.Range(minForce, maxForce), ForceMode.Impulse);

        
    }

    public Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        
        int side = Random.Range(0, 2);
        float spawnDistance = Random.Range(10f, 20f);

        
        switch (side)
        {
            case 0:
                spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1f, spawnDistance));
                break;
            case 1:
                spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 0f, spawnDistance));
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