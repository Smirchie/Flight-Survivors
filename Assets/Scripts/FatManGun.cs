using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatManGun : Gun
{
    [SerializeField] private Enemy kamikazePrefab;
    [HideInInspector]public int kamikazeSpawnChance;
    protected override void Shoot()
    {
        base.Shoot();
        int randomInt = Random.Range(1, 101);
        if (randomInt<=kamikazeSpawnChance)
        {
            SpawnKamikaze();
        }
    }
    private void SpawnKamikaze()
    {
        kamikazePrefab.transform.position = barrel.position;
        Instantiate(kamikazePrefab);
    }
}
