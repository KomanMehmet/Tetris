using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class ShapeManager : MonoBehaviour
{
    [SerializeField] private bool canRotate = true;
    

    public void MoveLeft()
    {
        transform.Translate(Vector3.left, Space.World);
    }
    
    public void MoveRight()
    {
        transform.Translate(-Vector3.right, Space.World);
    }

    public void MoveDown()
    {
        transform.Translate(Vector3.down, Space.World);
    }
    
    public void MoveUp()
    {
        transform.Translate(Vector3.up, Space.World);
    }

    public void RotateRight()
    {
        if (canRotate)
        {
            transform.Rotate(0, 0, -90);
        }
    }
    
    public void RotateLeft()
    {
        if (canRotate)
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
