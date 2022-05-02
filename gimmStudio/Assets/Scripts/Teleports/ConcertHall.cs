using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcertHall : MonoBehaviour
{
    public bool enterConcertHall;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enterConcertHall = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterConcertHall = false;
        }
    }

}
