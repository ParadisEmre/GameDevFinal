using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public GameObject shield;
    public bool isShieldActive = false;
    public float shieldTimer = 0f;
    public float shieldDuration = 3f;
    public float shieldCooldown = 10f;

    void Start()
    {
        shield.SetActive(false);
    }

    void Update()
    {
        // Check if shield is active
        if (isShieldActive)
        {
            shieldTimer += Time.deltaTime;

            // Check if shield duration has passed
            if (shieldTimer >= shieldDuration)
            {
                DeactivateShield();
            }
        }
        else
        {
            shieldTimer += Time.deltaTime;

            // Check if shield cooldown has passed
            if (shieldTimer >= shieldCooldown)
            {
                ActivateShield();
            }
        }
    }

    public void ActivateShield()
    {
        isShieldActive = true;
        shieldTimer = 0f;
        shield.SetActive(true);
    }

    public void DeactivateShield()
    {
        isShieldActive = false;
        shieldTimer = 0f;
        shield.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Asteroid")
        {
            shield.SetActive(false);
        }
    }
}