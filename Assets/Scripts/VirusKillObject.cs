using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VirusKillObject : MonoBehaviour
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
        if (other.gameObject.CompareTag("Sanitizer"))
        {
            this.gameObject.SetActive(false);
            audioSource.Play();
        }
    }
}
