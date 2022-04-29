using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayers : MonoBehaviour
{
    public GameObject videoToPlay;
    public GameObject blankScreen;
    public void StartVideo()
    {
        blankScreen.SetActive(false);
        videoToPlay.SetActive(true);
    }
    public void StopVideo()
    {
        blankScreen.SetActive(true);
        videoToPlay.SetActive(false);
    }
}
