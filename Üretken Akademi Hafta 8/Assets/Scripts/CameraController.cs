using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTarget;
    public float sSpeed = 0.5f;
    public Vector3 dist;
    public Transform lookTarget;
    public bool isCamActive = true; 
    private void FixedUpdate()
    {
        if (isCamActive)
        {
            Cam();
        }

    }
    public void Cam()
    {
        Vector3 dPos = cameraTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }
    public void DisableCam()
    {
        isCamActive = false;

    }

}
