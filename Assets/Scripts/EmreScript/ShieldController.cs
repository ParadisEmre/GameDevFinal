using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public SphereCollider shieldCollider;
    public GameObject shield;
    public bool isShieldActive = true;
    public float shieldTimer = 0f;
    public float shieldDuration = 0.5f;
    public float shieldCooldown = 10f;

    void Start()
    {
        shield.SetActive(true);
        DeactivateShield();
    }

    void Update()
    {
        // Check if shield is active
        if (!isShieldActive)
        {
            shieldTimer += Time.deltaTime;

            if (shieldTimer >= shieldCooldown)
            {
                ActivateShield();
            }
        }
            
    }

    public void ActivateShield()
    {
        shieldCollider.enabled = true;
        isShieldActive = true;
        shield.SetActive(true);
        AudioControllerScript.instance.PlaySound(5);
    }

    public void DeactivateShield()
    {
        shieldCollider.enabled = false;
        isShieldActive = false;
        shieldTimer = 0f;
        shield.SetActive(false);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            AudioControllerScript.instance.PlaySound(6);
            DeactivateShield();
            Destroy(other.gameObject);
        }
    }
}