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
    bool managerFound = false;
    List<GameObject> players = new List<GameObject>();
    [Tooltip("PhotonView for the Game Manager so changes cross over the network, as well as the player name saved over the network")]
    public PhotonView PV;
    public GameObject exitScreen;
   

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
        mainUser = GameObject.Find("Local");
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
    public void ExitGame()
    {
        if (PV.IsMine)
        {
            mana.LeaveRoom();
            Application.Quit();
        }
       
    }
    public void Return()
    {
        exitScreen.SetActive(false);
        avatar.playerMovementImpared = false;
    }
}
