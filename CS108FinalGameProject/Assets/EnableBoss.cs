using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBoss : MonoBehaviour
{
    public GameObject setBossActive;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        setBossActive.SetActive(true);
        Destroy(gameObject);
    }
}
