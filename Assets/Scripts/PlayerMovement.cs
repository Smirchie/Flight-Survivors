using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        MovePlayer();
        LimitMovement();
    }

    private void MovePlayer()
    {
        Vector3 moveVector = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVector = moveSpeed * Time.deltaTime * moveVector.normalized;
        transform.position += moveVector;
    }
    private void LimitMovement()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector3 limitVector = transform.position;
        if(transform.position.x>screenBounds.x)
        {
            limitVector.x = screenBounds.x;
        }
        else if(transform.position.x<-screenBounds.x)
        {
            limitVector.x = -screenBounds.x;
        }
        if(transform.position.y>screenBounds.y)
        {
            limitVector.y = screenBounds.y;
        }
        else if(transform.position.y<-screenBounds.y)
        {
            limitVector.y = -screenBounds.y;
        }
        transform.position = limitVector;
    }
}