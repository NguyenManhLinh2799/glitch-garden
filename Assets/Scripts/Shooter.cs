using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount > 0)
        {
            return true;
        }
        return false;
    }

    private void SetLaneSpawner()
    {
        var attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in attackerSpawners)
        {
            if (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.position, Quaternion.identity);
    }
}
