using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class ShapeManager : MonoBehaviour
{
    [SerializeField] private bool canRotate = true;

    private void Start()
    {
        InvokeRepeating("MoveDown", 0f, 0.25f);
        InvokeRepeating("RotateRight", 0f, 0.25f);
    }

    public void MoveLeft()
    {
        transform.Translate(Vector3.left);
    }
    
    public void MoveRight()
    {
        transform.Translate(-Vector3.right);
    }

    public void MoveDown()
    {
        transform.Translate(Vector3.down);
    }
    
    public void MoveUp()
    {
        transform.Translate(Vector3.up);
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
