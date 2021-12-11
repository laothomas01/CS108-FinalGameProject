using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBoss : MonoBehaviour
{
    public GameObject setBossActive;
    public GameObject cam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        setBossActive.SetActive(true);
        SmoothCameraFollow scf = cam.GetComponent<SmoothCameraFollow>();
        scf.cameraZoomOut = true;
        Destroy(gameObject);
    }
}
