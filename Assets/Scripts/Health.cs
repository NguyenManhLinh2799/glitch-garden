using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] Transform body;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (explosionVFX)
            {
                Instantiate(explosionVFX, body.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
