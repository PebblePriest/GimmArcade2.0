using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody ballBody;
    [SerializeField] float ballForce;

    private void Start()
    {
        ballBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballBody.AddForce(Vector3.right * ballForce * -1);
        }
    }
}
