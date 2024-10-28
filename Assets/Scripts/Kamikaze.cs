using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Enemy
{
    private Transform _playerTransform;
    public int damage;
    [SerializeField] private float moveSpeed;
    private void Start()
    {
        _playerTransform = FindObjectOfType<Player>().transform;
    }
    private void Update()
    {
        if(_playerTransform!=null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, moveSpeed * Time.deltaTime);
            RotateTowardsPlayer();
        }
    }
    private void RotateTowardsPlayer()
    {
        Vector3 differenceVector = _playerTransform.position - transform.position;
        float rotationZ = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90f);
    }
}
