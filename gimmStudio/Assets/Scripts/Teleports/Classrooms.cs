using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Classrooms : MonoBehaviour
{
    public bool enterClassrooms;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enterClassrooms = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterClassrooms = false;
        }
    }
}
