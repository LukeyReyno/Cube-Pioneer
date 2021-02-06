using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmonicMotion : MonoBehaviour
{
    public float upperBound;
    public float lowerBound;
    public string direction;
    public int movementSpeed = 1;

    private Vector3 move;
    private int sign = 1;
    // Start is called before the first frame update
    void Start()
    {
        switch (direction)
        {
            case "X":
                move = new Vector3(movementSpeed, 0, 0);
                break;
            case "Y":
                move = new Vector3(0, movementSpeed, 0);
                break;
            case "Z":
                move = new Vector3(0, 0, movementSpeed);
                break;
            default:
                move = Vector3.zero;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (getPosition() >= upperBound)
        {
            sign = -1;
        }
        else if (getPosition() <= lowerBound)
        {
            sign = 1;
        }
        transform.Translate(move*Time.deltaTime*sign);
    }

    private float getPosition()
    {
        switch (direction)
        {
            case "X":
                return transform.position.x;
            case "Y":
                return transform.position.y;
            case "Z":
                return transform.position.z;
            default:
                return 0;
        }
    }
}
