using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float coolDownTime;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletSize;
    [SerializeField] private int bulletDamage;
    [SerializeField] protected Transform barrel;
    [SerializeField] private Bullet bulletPrefab;
    private float _currentCoolDown;

    private void Update()
    {
        if (!IsCoolDownActive())
        {
            Shoot();
        }
    }

    private void SetBulletData()
    {
        bulletPrefab.damage = bulletDamage;
        bulletPrefab.moveSpeed = bulletSpeed;
        bulletPrefab.transform.localScale = new Vector3(bulletSize, bulletSize, 0f);
        bulletPrefab.transform.position = barrel.position;
        bulletPrefab.movementVector = (barrel.position - transform.position).normalized;
    }

    protected virtual void Shoot()
    {
        _currentCoolDown = coolDownTime;
        SetBulletData();
        Instantiate(bulletPrefab);
    }

    private bool IsCoolDownActive()
    {
        if (_currentCoolDown <= 0)
        {
            _currentCoolDown = 0;
            return false;
        }
        else
        {
            _currentCoolDown -= Time.deltaTime;
            return true;
        }
    }
}