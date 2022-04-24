using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingMinigame : MonoBehaviour
{
    public GameObject pins;
    public GameObject ball;
    public GameObject playCamera;
    public GameObject bowlingGame;
    public void PlayGame()
    {
        pins.SetActive(false);
        ball.SetActive(false);
        playCamera.SetActive(true);
        bowlingGame.SetActive(true);

    }
    public void LeaveGame()
    {
        pins.SetActive(true);
        ball.SetActive(true);
        playCamera.SetActive(false);
        bowlingGame.SetActive(false);
    }
}
