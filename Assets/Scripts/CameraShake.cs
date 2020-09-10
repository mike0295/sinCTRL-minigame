using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera mainCam;
    private float shakeAmt;


    private void Awake()
    {
        if (mainCam == null) {
            mainCam = Camera.main;
        }
    }

    public void Shake(float amt, float length) {
        shakeAmt = amt;
        InvokeRepeating("BeginShake", 0, 0.1f);
        Invoke("StopShake", length);

    }

    void BeginShake() {
        Vector3 camPos = mainCam.transform.position;

        float offsetX = Random.value * shakeAmt * 2 - shakeAmt;
        float offsetY = Random.value * shakeAmt * 2 - shakeAmt;
        camPos.x += offsetX;
        camPos.y += offsetY;

        mainCam.transform.position = camPos;
    }


    void StopShake() {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}
