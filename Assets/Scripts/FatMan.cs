using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatMan : Enemy
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxRotationSpeed;
    [SerializeField] private float minGunCooldown;
    [SerializeField] private RectTransform healthBar;
    private float _healthBarStep;
    private float _rotationStep;
    private float _coolDownStep;
    private bool _wasImmune = false;
    private bool _isImmune = false;
    private float _immunityTimeLeft = 30f;
    private FatManGun[] _guns;
    private void Start()
    {
        _guns = transform.GetComponentsInChildren<FatManGun>();
        _healthBarStep = healthBar.localScale.x / maxHealthPoints;
        _rotationStep = (maxRotationSpeed-rotationSpeed) / (maxHealthPoints);
        _coolDownStep = (minGunCooldown - _guns[0].coolDownTime)/(maxHealthPoints);
    }

    private void Update()
    {
        Vector3 rotationVector = new(0f, 0f, rotationSpeed);
        transform.Rotate(rotationVector);
        if(_immunityTimeLeft>0 && _isImmune)
        {
            _immunityTimeLeft -= Time.deltaTime;
            if(_immunityTimeLeft<=0)
            {
                _isImmune = false;
            }
        }
    }

    protected override void TakeDamage(int damage)
    {
        if(!_isImmune)
        {
            base.TakeDamage(damage);
            healthBar.localScale -= new Vector3(_healthBarStep * damage, 0f);
            if(currentHealthPoints<=maxHealthPoints/100*25)
            {
                foreach(var gun in _guns)
                {
                    gun.kamikazeSpawnChance = 5;
                }
            }
            else if (currentHealthPoints<= maxHealthPoints/100*50)
            {
                foreach(var gun in _guns)
                {
                    gun.kamikazeSpawnChance = 10;
                }
            }
            if (currentHealthPoints > maxHealthPoints / 100 * 5)
            {
                rotationSpeed += _rotationStep * damage;
                foreach (var gun in _guns)
                {
                    gun.coolDownTime += _coolDownStep;
                }
            }
            else if(!_wasImmune)
            {
                _isImmune = true;
                _wasImmune = true;
            }
        }
    }
}