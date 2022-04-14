using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaza : MonoBehaviour
{
    public bool enterPlaza;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enterPlaza = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterPlaza = false;
        }
    }
}
