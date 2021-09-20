using UnityEngine;

using TMPro;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int playerSpeed = 6;
    private int objectCount;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private Vector3 scaleChange = new Vector3(0, 0.0002f, 0);
    private float massChange = 0.00005f;
    private float timer = 0;
    private bool gameOver = false;
    public List<GameObject> mainObjectList;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        if (rb.velocity.magnitude <= 40 && !gameOver)
        {
            rb.AddForce(movement * playerSpeed);
            gameObject.transform.position += scaleChange;
            gameObject.transform.localScale += scaleChange;
        }

        if (rb.velocity.y > 0)
        {
            rb.velocity += new Vector3(0, -5 * Time.deltaTime, 0);
        }

        objectCount = levelStatusComplete(mainObjectList);
    }

    private void Update()
    {
        if (!gameOver)
        {
            timer += Time.deltaTime;
            rb.mass += massChange;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private int levelStatusComplete(List<GameObject> gameObjects)
    {
        int numActive = 0;
        foreach (GameObject thing in gameObjects)
        {
            if (thing.activeSelf)
                numActive += 1;
        }
        return numActive;
    }
}
