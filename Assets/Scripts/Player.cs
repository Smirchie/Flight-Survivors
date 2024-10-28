using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private RectTransform healthBar;
    private float healthBarStep;

    private void Start()
    {
        healthBarStep = healthBar.localScale.x / maxHealthPoints;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Kamikaze"))
        {
            TakeDamage(collision.gameObject.GetComponent<Kamikaze>().damage);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(maxHealthPoints);
        }
    }

    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthBar.localScale -= new Vector3(healthBarStep * damage, 0f);
        healthBar.position -= new Vector3(healthBarStep * damage / 2, 0f);
    }

}