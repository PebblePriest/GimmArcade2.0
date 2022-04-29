using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class JackPolifka : MonoBehaviour
{
    public bool enterJackPolifka;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enterJackPolifka = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterJackPolifka = false;
        }
    }
}
