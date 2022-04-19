using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Arcade : MonoBehaviour
{
    public bool enterArcade;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enterArcade = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterArcade = false;
        }
    }
}
