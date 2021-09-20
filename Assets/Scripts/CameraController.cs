using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public int mouseSensitivity = 5;
    public float cameraMoveSpeed = 5;

    public float maxDistance = 12;
    public float minDistance = 2;

    public float smooth = 10.0f;
    private Vector3 dollyDir;
    private float distance;
    
    private float mouseXvalue;
    private Vector3 defaultPosition;
    private Transform defaultTransform;
    private GameObject cameraFollowObject;
    private Mouse mouse;

    private int layerMask = 1 << 8;

    // Start is called before the first frame update
    void Start()
    {
        mouse = InputSystem.GetDevice<Mouse>();
        defaultPosition = transform.position;
        defaultTransform = transform.parent.transform;
        cameraFollowObject = transform.parent.gameObject;
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse.press.isPressed) {
            mouseXvalue = mouse.delta.ReadValue().x;
            RotateCamera(mouseXvalue*Time.deltaTime*mouseSensitivity);
        }

        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);

        Vector3 dir = getDirection(transform.position, transform.parent.transform.position);

        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit, ~layerMask)) {
            distance = Mathf.Clamp((hit.distance * 0.9f), minDistance, maxDistance);
            Debug.DrawRay(transform.position, dir * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        } else {
            distance = maxDistance;
            Debug.DrawRay(transform.position, dir *1000, Color.blue);
            //Debug.Log("Did not Hit");
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
        
    }

    private void RotateCamera(float xValue) {
        transform.parent.Rotate( new Vector3(0, xValue, 0));
    }

    private Vector3 getDirection(Vector3 start, Vector3 end) {
        float x = end.x - start.x;
        float y = end.y - start.y;
        float z = end.z - start.z;
        return new Vector3(x, y, z).normalized;
    }
}
