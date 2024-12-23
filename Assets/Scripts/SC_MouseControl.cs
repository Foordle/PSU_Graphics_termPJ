using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MouseControle : MonoBehaviour
{
    [SerializeField]
    private float rotXSpeed = 3;
    private float rotYSpeed = 3;

    private float MinX = -80;
    private float MaxX = 50;
    private float AngleX;
    private float AngleY;

    public float resetAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);

    }

    public void UpdateRotation(float mouseX, float mouseY)
    {

        AngleX -= mouseY * rotXSpeed;
        AngleY += mouseX * rotYSpeed;
        
        AngleX = resetAngle(AngleX, MinX, MaxX);

        transform.rotation = Quaternion.Euler(AngleX, AngleY,0);

    }

}
