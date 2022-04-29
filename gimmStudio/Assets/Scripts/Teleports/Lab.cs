using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{
    public bool enterLab;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enterLab = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterLab = false;
        }
    }
}
