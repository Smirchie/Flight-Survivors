using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursorRotation : MonoBehaviour
{
    private void Update()
    {
        RotateTowardsCursor();
    }

    private void RotateTowardsCursor()
    {
        Vector3 differenceVector = GetWorldMousePosition() - transform.position;
        float rotationZ = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90f);
    }

    private Vector3 GetWorldMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return worldMousePosition;
    }
}