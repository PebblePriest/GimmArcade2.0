using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Com.MyCompany.MyGame;

public class ButtonCode : MonoBehaviourPunCallbacks
{
    public GameObject mainUser;
    public AvatarChanges avatar;
    [Tooltip("PhotonView for the Game Manager so changes cross over the network, as well as the player name saved over the network")]
    public PhotonView PV;
    public GameObject exitScreen;
   

    public void Update()
    {
        if (PV.IsMine)
        {
           
            StartUp();
            
            
           
            
          
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
           LeaveRoom();
        }
    }
    public void ExitGame()
    {
        if (PV.IsMine)
        {
            LeaveRoom();
            Application.Quit();
        }
       
    }
    public void Return()
    {
        exitScreen.SetActive(false);
        avatar.playerMovementImpared = false;
    }

    #region Photon Callbacks


    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene.
    /// </summary>
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Launcher");
    }

    #endregion
    #region Public Methods


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    #endregion

    #region Private Methods

    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetowrk : trying to load a level but we are not the master Client");
        }
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        }

    }

    #endregion

    #region Photon Callbacks


    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


            LoadArena();
        }
    }


    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


            LoadArena();
        }
    }

    #endregion
}
