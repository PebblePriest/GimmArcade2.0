using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallery : MonoBehaviour
{
    public bool enterGallery;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enterGallery = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterGallery = false;
        }
    }
}
