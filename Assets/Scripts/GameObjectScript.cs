using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectScript : MonoBehaviour
{
    private string thisCompareTag;
    private MeshRenderer meshRenderer;
    private Rigidbody rb;
    private AudioSource audioSource;

    private Color green = new Color(0, 255, 0);
    private bool goalReached = false;
    private int deactivateBuffer = 120;

    // Start is called before the first frame update
    void Start()
    {
        thisCompareTag = gameObject.tag;
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goalReached)
        {
            deactivateBuffer -= 1;
            if (deactivateBuffer == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(thisCompareTag))
        {
            meshRenderer.material.color = green;
            other.GetComponent<MeshRenderer>().material.color = green;
            gameObject.transform.position = new Vector3(other.transform.position.x, gameObject.transform.position.y + 0.5f, other.transform.position.z);
            rb.isKinematic = true;
            goalReached = true;
            audioSource.Play();
            other.gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
}
