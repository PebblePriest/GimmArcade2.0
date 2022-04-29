using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckyGoRound : MonoBehaviour
{
    Vector3 speed = new Vector3(0, .006f, 0);
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(startPos, transform.position);
        if (distance >= 1) speed *= -1f;
        transform.position += speed;
        transform.Rotate(Vector3.forward * 0.7f);
    }
}
