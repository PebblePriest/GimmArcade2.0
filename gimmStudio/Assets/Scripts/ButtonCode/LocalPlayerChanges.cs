using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LocalPlayerChanges : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    public GameObject playPanel;
    public void Awake()
    {
        PV = GameObject.Find("Local").GetComponent<PhotonView>();
        if (PV.IsMine)
        {

            playPanel = this.gameObject;
            playPanel.name = "LocalStartGame";
        }
    }
   
}
