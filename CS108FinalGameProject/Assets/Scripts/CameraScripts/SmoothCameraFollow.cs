using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{

    // get our object
    public Transform target;
    //used to fix the position of the camera?
    public Vector3 offset;
    //how fast the camera will move to the player
    public bool cameraZoomOut = false;
    [Range(0, 10)] public float smoothFactor;

    void FixedUpdate()
    {
        Follow();
        if (cameraZoomOut)
        {
            offset.z = -20;
        }

    }
    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        //LERP between two values: the camera's position and the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        //caerma's position becomes the smoothed position.
        transform.position = smoothedPosition;
    }
}
