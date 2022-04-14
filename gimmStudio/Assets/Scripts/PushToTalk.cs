using Photon.Voice.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice;

public class PushToTalk : MonoBehaviourPunCallbacks
{
    

    // Start is called before the first frame update
    void Awake()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
             
                Debug.Log("TALKING");
            }
            if (Input.GetKeyUp(KeyCode.V))
            {
                
                Debug.Log("Stop TALKING");
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
