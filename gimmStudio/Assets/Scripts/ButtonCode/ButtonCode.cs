using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Com.MyCompany.MyGame;

public class ButtonCode : MonoBehaviourPunCallbacks
{
    public GameObject mainUser;
    public AvatarChanges avatar;
    public GameObject manager;
    private GameManager mana;
    bool userFound = false;
    bool managerFound = false;
    List<GameObject> players = new List<GameObject>();
    [Tooltip("PhotonView for the Game Manager so changes cross over the network, as well as the player name saved over the network")]
    public PhotonView PV;
   

    public void Update()
    {
        if (PV.IsMine)
        {
            if(!managerFound)
            {
                StartUp();
            }
            else
            {
                Debug.Log("Looking for manager!");
            }
           
            
            if (!userFound)
            {
                players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
                for (int i = 0; i < players.Count; i++)
                {
                    mainUser = players[i];
                    break;
                }
                userFound = true;
            }

            if (mainUser)
            {
                avatar = mainUser.GetComponent<AvatarChanges>();
            }
            else
            {
                Debug.Log("Can't find the user");
            }
        }
       

    }
    public void StartUp()
    {
        manager = GameObject.Find("GameManager");
        mana = manager.GetComponent<GameManager>();
    }
    public void ControlsOn()
    {
        if (PV.IsMine)
        {

            avatar.KeyControlsOn();
        }
    }
    public void ControlsOff()
    {
        if (PV.IsMine)
        {
            avatar.KeyControlsOff();
        }
    }
    public void AvatarOn()
    {
        if (PV.IsMine)
        {
            avatar.AvatarMenu();
        }
    }
    public void AvatarOff()
    {
        if (PV.IsMine)
        {
            avatar.StartGame();
        }
    }
    public void LeaveGame()
    {
        if (PV.IsMine)
        {
            mana.LeaveRoom();
        }
    }
}
