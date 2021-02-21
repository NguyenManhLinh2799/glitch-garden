using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Attacker
{
    private void Jump(WallNut wallNut)
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), wallNut.GetComponent<Collider2D>());
        GetComponent<Animator>().SetTrigger("jump");
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        var wallNut = collision.GetComponent<WallNut>();
        if (wallNut)
        {
            Jump(wallNut);
        }
        else
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}
