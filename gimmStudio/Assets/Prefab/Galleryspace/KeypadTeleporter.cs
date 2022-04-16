using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadTeleporter : MonoBehaviour
{
    [SerializeField] KeypadCollider keypadCollider;
    [Header("Room waypoints")]
    [SerializeField] Transform[] waypointTransforms;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void Teleport()
    {
       keypadCollider.PlayerToBeTeleported.transform.position = waypointTransforms[0].transform.position;
    }
    public void Confirm()
    {
        Teleport();
    }

}

