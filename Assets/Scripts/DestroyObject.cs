using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float tiempo;

    void Start()
    {
        Destroy(gameObject, tiempo);
    }

}
