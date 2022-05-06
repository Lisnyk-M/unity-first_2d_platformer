using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public float maxPos = 13f;
    public float minPos = 0.0f;
    private Vector3 pos;    
    private const float defStep = 4f;
    private float step = defStep;

    void Update()
    {        
        pos = transform.position;
        if (pos.y > maxPos)
            step = -defStep;
        if (pos.y < minPos)
            step = defStep;

        pos.y += Time.deltaTime * step;
        transform.position = pos;
    }
}
