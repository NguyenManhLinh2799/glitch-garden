using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float flySpeed = 1f;
    [SerializeField] float damage = 50f;
    [SerializeField] GameObject explosionVFX;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * flySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            if (explosionVFX)
            {
                Instantiate(explosionVFX, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
