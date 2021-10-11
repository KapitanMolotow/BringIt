using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Activator
{

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material = transparent;
        foreach (GameObject myOms in Omnimans)
        {
            myOms.GetComponent<Renderer>().material = transparent;
            myOms.GetComponent<Collider>().isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material = normal;
        foreach (GameObject myOms in Omnimans)
        {
            myOms.GetComponent<Renderer>().material = normal;
            myOms.GetComponent<Collider>().isTrigger = false;
        }
    }
}
