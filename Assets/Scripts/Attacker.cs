using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float currentSpeed = 1f;
    Defender currentTarget;
    [SerializeField] float damage = 10f;

    // Update is called once per frame
    protected void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    protected void Attack(Defender target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var defender = collision.GetComponent<Defender>();
        if (defender)
        {
            Attack(defender);
        }
    }

    protected void StrikeCurrentTarget()
    {
        if (!currentTarget)
        {
            return;
        }

        currentTarget.GetComponent<Health>().DealDamage(damage);
    }

    protected void OnDestroy()
    {
        var levelController = FindObjectOfType<LevelController>();
        if (levelController)
        {
            levelController.AttackerKilled();
        }
    }
}
