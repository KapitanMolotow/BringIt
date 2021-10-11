using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Activator
{
    public bool isActivated;
    public bool canPush;
    public Lever Brother;


    private void OnTriggerStay(Collider other)
    {
        if (canPush && isActivated)
            if (other.CompareTag("Blocker") || other.CompareTag("Hostage") || other.CompareTag("Slider"))
            {
                Switch();
                Brother.Switch();
                GetComponent<Renderer>().material = transparent;
                Brother.GetComponent<Renderer>().material = normal;
                Brother.canPush = true;
            }
    }
    private void Switch()
    {
        switch (isActivated)
        {
            case true:
                isActivated = false;
                break;
            default:
                isActivated = true;
                break;
        }
        foreach (GameObject myOms in Omnimans)
        {
            if (myOms.GetComponent<Renderer>().material.color.a == transparent.color.a)
            {
                myOms.GetComponent<Renderer>().material = normal;
                myOms.GetComponent<Collider>().isTrigger = false;
                return;
            }
            if (myOms.GetComponent<Renderer>().material.color.a == normal.color.a)
            {
                myOms.GetComponent<Renderer>().material = transparent;
                myOms.GetComponent<Collider>().isTrigger = true;
                return;
            }
        }
    }
}

/*


public GameObject[] Omnimans;
public Lever Brother;
public Material normal;
public Material transparent;
public bool canPush;

private void OnTriggerEnter(Collider other)
{
    if (canPush)
    {


        if (other.CompareTag("Blocker") || other.CompareTag("Hostage") || other.CompareTag("Slider"))
        {
            foreach (GameObject myOms in Omnimans)
            {
                myOms.GetComponent<Renderer>().material = transparent;
                myOms.GetComponent<Collider>().isTrigger = true;
            }

            foreach (GameObject hisOms in Brother.Omnimans)
            {
                hisOms.GetComponent<Renderer>().material = normal;
                hisOms.GetComponent<Collider>().isTrigger = false;
            }
            GetComponent<Renderer>().material = transparent;
            Brother.GetComponent<Renderer>().material = normal;
            Brother.canPush = true;
        }
    }


}
*/

/* MK. I
 * 
 * public GameObject[] firstGroup;
public GameObject[] secondGroup;
public Activator button;
public Material normal;
public Material transparent;
public bool canPush;

private void OnTriggerEnter(Collider other)
{
    if (canPush)
    {


        if (other.CompareTag("Blocker") || other.CompareTag("Hostage") || other.CompareTag("Slider"))
        {
            foreach (GameObject first in firstGroup)
            {
                first.GetComponent<Renderer>().material = normal;
                first.GetComponent<Collider>().isTrigger = false;
            }
            foreach (GameObject second in secondGroup)
            {
                second.GetComponent<Renderer>().material = transparent;
                second.GetComponent<Collider>().isTrigger = true;
            }
            GetComponent<Renderer>().material = transparent;
            button.GetComponent<Renderer>().material = normal;
            button.canPush = true;
        }
    }

}  */

