using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int maxHealthPoints;
    protected int currentHealthPoints;
    private void Awake()
    {
        currentHealthPoints = maxHealthPoints;
    }
    protected virtual void TakeDamage(int damage)
    {
        currentHealthPoints -= damage;
        if(currentHealthPoints<=0)
        {
            Destroy(gameObject);
        }
    }
}