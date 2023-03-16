using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public GameObject[] Susto;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(Susto[Random.Range(0, Susto.Length)]);
            Destroy(gameObject);
        }
    }
}
