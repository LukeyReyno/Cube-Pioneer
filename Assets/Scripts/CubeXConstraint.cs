﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeXConstraint : MonoBehaviour
{
    public float lowerBound;
    public float upperBound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        if (x < lowerBound)
        {
            transform.position = new Vector3(lowerBound, y, z);
        }
        else if (x > upperBound)
        {
            transform.position = new Vector3(upperBound, y, z);
        }
    }
}