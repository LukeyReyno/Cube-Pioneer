using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Events : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI massText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI fpsText;
    public TextMeshProUGUI titleText;
    public GameObject winTextObject;
    private int titleBuffer = 120;

    private int fps = 0;

    // Start is called before the first frame update
    void Start()
    {
        //EventManager.StartListening("addPoints", addPoints);

        SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the "You Win" (game over message) blank
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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
    }

    void SetCountText()
    {
        //countText.text = "Remaining Cubes: " + objectCount.ToString();
        //massText.text = "Mass: " + rb.mass.ToString();
        //timeText.text = "Time: " + timer.ToString("0.00");
        fpsText.text = "FPS: " + fps.ToString();

        /*
        if (objectCount == 0)
        {
            // Set the text value of your "winText"
            winTextObject.SetActive(true);
            gameOver = true;
        }*/
    }
}
