using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Enemy : Character
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FriendlyBullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
            Destroy(collision.gameObject);
        }
    }
}