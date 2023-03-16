using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashlightON;
    public GameObject flashlightOFF;
    private bool isOn;

    private void Start()
    {
        isOn = false;
        flashlightOFF.SetActive(true);
        flashlightON.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            //if its on turn it off
            if (isOn)
            {
                flashlightON.SetActive(false);
                flashlightOFF.SetActive(true);
            }
            //if its off turn it on
            else
            {
                flashlightON.SetActive(true);
                flashlightOFF.SetActive(false);
            }
            // and set the boolean to whatever it isn't (if true it'll go false, if false it'll go true)
            isOn = !isOn;
        }
    }
}
