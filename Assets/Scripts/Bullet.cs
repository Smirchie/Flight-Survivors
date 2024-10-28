using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Bullet : MonoBehaviour
{
    public int damage;
    public float moveSpeed;
    public Vector3 movementVector;

    private void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * movementVector;
    }
}