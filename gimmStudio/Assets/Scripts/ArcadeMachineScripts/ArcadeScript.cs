using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeScript : MonoBehaviour
{
    public GameObject testCam;

    public void PlayGame()
    {
        testCam.SetActive(true);
    }
    public void EndGame()
    {
        testCam.SetActive(false);
    }
   
}
