using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BowlingManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    GameObject[] pins; //array for pins
    Vector3[] positions; //array for pin locations
    public TextMeshProUGUI scoreText;
    public Transform ballStart;
    int score = 0;

    private void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length]; //sets to equal length
        ball.transform.position = ballStart.position;
        for (int i = 0; i < pins.Length; i++)
        {
            positions[i] = pins[i].transform.position; //adds pin positions to positions array
        }

    }

    void Update()
    {
        MoveBall(); //checks for movement

        if (ball.transform.position.y < 20)
        {
            CountPinsKnocked();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPins();
        }
    }

    void MoveBall() // Lets you move ball left to right
    {
        Vector3 position = ball.transform.position;
        position += Vector3.forward * Input.GetAxis("Horizontal") * Time.deltaTime;
        position.z = Mathf.Clamp(position.z, 13.96f, 16f);
        ball.transform.position = position;
    }

    void CountPinsKnocked()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355
                && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
        }
        scoreText.text = score.ToString();
    }

    void ResetPins()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(true); //reactivate inactive pins
            pins[i].transform.position = positions[i]; //grab initaial positions
            //reset pin velocity
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.rotation = Quaternion.identity;

        }
        ball.transform.position = ballStart.position; //exact position will need to be adjusted to starting position of ball
        //reset ball velocity
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;
    }
}
