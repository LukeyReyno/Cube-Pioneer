using UnityEngine;

using TMPro;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI massText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI fpsText;
    public TextMeshProUGUI titleText;
    public GameObject winTextObject;
    public List<GameObject> mainObjectList;

    public int playerSpeed = 6;

    private int objectCount;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private Vector3 scaleChange = new Vector3(0, 0.0002f, 0);
    private float massChange = 0.00005f;
    private float timer = 0;
    private int fps = 0;
    private int titleBuffer = 120;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        // Set the count to zero
        objectCount = mainObjectList.Count;

        SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the "You Win" (game over message) blank
        winTextObject.SetActive(false);
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

        SetCountText();
    }

    private void Update()
    {
        fps = (int)(1 / Time.unscaledDeltaTime); //from craftgames.co

        if (titleBuffer > 0)
        {
            titleBuffer -= 1;
            titleText.fontSize += 0.1f;
        }
        else if (titleBuffer == 0)
        {
            titleText.gameObject.SetActive(false);
            titleBuffer -= 1;
        }
        else if (!gameOver)
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

    void SetCountText()
    {
        countText.text = "Remaining Cubes: " + objectCount.ToString();
        massText.text = "Mass: " + rb.mass.ToString();
        timeText.text = "Time: " + timer.ToString("0.00");
        fpsText.text = "FPS: " + fps.ToString();

        if (objectCount == 0)
        {
            // Set the text value of your "winText"
            winTextObject.SetActive(true);
            gameOver = true;
        }
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
