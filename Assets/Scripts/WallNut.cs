using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNut : MonoBehaviour
{
    float maxHealth;
    Health health;
    Animator animator;
    float crack1HealthPercent = 0.6f;
    float crack2HealthPercent = 0.3f;
    int crackState = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();

        maxHealth = health.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        float healthPercent = health.GetHealth() / maxHealth;
        if (healthPercent <= crack1HealthPercent && crackState == 0)
        {
            crackState = 1;
            animator.SetTrigger("crack1");
        }
        else if (healthPercent <= crack2HealthPercent && crackState == 1)
        {
            crackState = 2;
            animator.SetTrigger("crack2");
        }
    }
}
