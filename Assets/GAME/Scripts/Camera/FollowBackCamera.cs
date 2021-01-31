using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBackCamera : MonoBehaviour
{

    public PlayerMovementController moveCtrl;

    public float cameraSpeed;
    public Vector3 offset;
    public float speedThreshold;
    public float distanceThreshold;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(moveCtrl.GetSpeed().x) < speedThreshold)
        {
            AlignCameraYPosition();
            return;
        }

        Vector3 currOffset = new Vector3(Mathf.Sign(moveCtrl.GetSpeed().x) * offset.x, offset.y > moveCtrl.transform.position.y? offset.y: 0f, offset.z);
        Vector3 desiredPosition = moveCtrl.transform.position + currOffset;

        if (Mathf.Abs(moveCtrl.transform.position.x - desiredPosition.x) < distanceThreshold)
            transform.position = moveCtrl.transform.position + currOffset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, smoothedPosition.z);
    }

    private void AlignCameraYPosition()
    {
        Vector3 currOffset = new Vector3(Mathf.Sign(moveCtrl.GetSpeed().x) * offset.x, offset.y > moveCtrl.transform.position.y ? offset.y : 0f, offset.z);
        Vector3 desiredPosition = moveCtrl.transform.position + currOffset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);
        transform.position = new Vector3(transform.position.x, smoothedPosition.y, transform.position.z);
    }
}
