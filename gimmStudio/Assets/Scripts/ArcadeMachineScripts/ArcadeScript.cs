using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeScript : MonoBehaviour
{
    public GameObject arcadeCamera;
    public GameObject arcadeVideo;
    public GameObject blankScreen;

    public void PlayGame()
    {
        blankScreen.SetActive(false);
        arcadeCamera.SetActive(true);
        arcadeVideo.SetActive(true);
    }
    public void EndGame()
    {
        blankScreen.SetActive(true);
        arcadeCamera.SetActive(false);
        arcadeVideo.SetActive(false);
    }
   
}
