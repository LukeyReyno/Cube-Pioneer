using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class killObject : MonoBehaviour
{
    public TextMeshProUGUI lostText;
    public GameObject winTextObject;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        lostText.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.isStatic)
        {
            other.gameObject.SetActive(false);
            lostText.gameObject.SetActive(true);
            winTextObject.SetActive(false);
            audioSource.Play();
        }
    }
}
