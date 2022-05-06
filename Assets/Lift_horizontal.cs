using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift_horizontal : MonoBehaviour
{
    public float maxPos;
    public float minPos;
    private Vector3 pos;    
    private const float defStep = 4f;
    private float step = defStep;

    void Update()
    {
        pos = transform.position;

        if (pos.x > maxPos)
            step = -defStep;
        if (pos.x < minPos)
            step = defStep;

        pos.x += Time.deltaTime * step;
        transform.position = pos;
    }
}
