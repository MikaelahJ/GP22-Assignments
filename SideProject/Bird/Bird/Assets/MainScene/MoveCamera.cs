using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider mapBounds;

    private Camera cam;
    private float camSize;
    private float camRatio;
    private float camX, camY;
    private float xMin, yMin, xMax, yMax;

    private Vector3 smoothPos;
    public float smoothSpeed = 0.5f;

    private void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;

        cam = GetComponent<Camera>();
        camSize = cam.orthographicSize;
        camRatio = (xMax + camSize) / 2.0f;
    }
    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camSize, yMax - camSize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + camRatio, xMax - camRatio);
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(camX, camY, this.transform.position.z), smoothSpeed);
        this.transform.position = smoothPos;
    }
}
