using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;
using Com.MyCompany.MyGame;

public class AvatarChanges : MonoBehaviourPunCallbacks
{
    [Tooltip("Script for the color changing Avatar Menu as well as values used within that script passed to this one")]
    public PlayerNameInputField field;
    public float hair, body, face;
    Color color;
    private bool avatarChanging;


    [Tooltip("PhotonView for the Game Manager so changes cross over the network, as well as the player name saved over the network")]
    public PhotonView PV;
    public Text playerName;
    public Text hudPlayerName;

    [Tooltip("Finds the elements of the Local user, to apply effects")]
    private MeshRenderer player;
    public Material playerMaterial;
    public bool playerMovementImpared = true;
    private bool startUp = false;

    [Tooltip("Panels that are found in the Game, used to turn on and off at given times")]
    public Text miniGameText;
    public GameObject avatarMenu;
    public GameObject mainUser;
    public GameObject hud;
    public GameObject instructions;
    public GameObject controls;
    public GameObject settings;
    public GameObject miniGameStart;

    public Material choice1;
    public Material choice2;
    public Material choice3;


    public void Update()
    {
        if (PV.IsMine)
        {
            if(!startUp)
            {
                StartFunction();
            }
            if (!avatarChanging)
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {

                    AvatarMenu();
                }
            }
            if (playerMovementImpared)
            {

                mainUser.GetComponent<PlayerManager>().moveSpeed = 0f;
                mainUser.GetComponent<PlayerManager>().lookSpeed = 0f;
            }
            else
            {

                mainUser.GetComponent<PlayerManager>().moveSpeed = 20f;
                mainUser.GetComponent<PlayerManager>().lookSpeed = 5f;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                PV.RPC("ChangeAvatarTexture", RpcTarget.All, 1);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                PV.RPC("ChangeAvatarTexture", RpcTarget.All, 2);
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                PV.RPC("ChangeAvatarTexture", RpcTarget.All, 3);
            }
        }



    }
    public void KeyControlsOn()
    {
        if (PV.IsMine)
        {
            controls.SetActive(true);
            playerMovementImpared = true;
        }
    }
    public void KeyControlsOff()
    {
        if (PV.IsMine)
        {
            controls.SetActive(false);
            playerMovementImpared = true;
        }
    }
    public void AvatarMenu()
    {
        if (PV.IsMine)
        {
            avatarMenu.SetActive(true);
            hud.SetActive(false);
            settings.SetActive(false);
            controls.SetActive(false);
            hud.SetActive(false);
            instructions.SetActive(false);
            mainUser = GameObject.Find("Local");
            playerMaterial = mainUser.GetComponentInChildren<MeshRenderer>().material;
            mainUser.GetComponentInChildren<Camera>().enabled = false;
            avatarChanging = true;
            playerMovementImpared = true;
        }
        
    }
    public void CustomizeCharacter()
    {
        if (PV.IsMine)
        {
            AvatarMenu();
            instructions.SetActive(false);
            playerMovementImpared = true;
        }
    }
    public void StartGame()
    {
        if (PV.IsMine)
        {
            playerName.text = PhotonNetwork.NickName.ToString();
            PV.RPC("ChangeAvatarTexture", RpcTarget.All, 1);
            avatarMenu.SetActive(false);
            hud.SetActive(true);
            mainUser.GetComponentInChildren<Camera>().enabled = true;
            avatarChanging = false;
            playerMovementImpared = false;
        }
    }

 
    [PunRPC]
    void ChangeAvatarTexture(int choice)
    {
        if (choice == 1)
        {
            mainUser.GetComponentInChildren<Renderer>().material = choice1;
            mainUser.GetComponentInChildren<Text>().text = playerName.text;
            hudPlayerName.text = playerName.text;
        }
        if (choice == 2)
        {
            mainUser.GetComponentInChildren<Renderer>().material = choice2;
            mainUser.GetComponentInChildren<Text>().text = playerName.text;
            hudPlayerName.text = playerName.text;
        }
        if (choice == 3)
        {
            mainUser.GetComponentInChildren<Renderer>().material = choice3;
            mainUser.GetComponentInChildren<Text>().text = playerName.text;
            hudPlayerName.text = playerName.text;
        }
    }
    /// <summary>
    /// Runs in the first update to make sure all the elements of the player are found correctly, as well as pass over the network the username and color of the character.
    /// </summary>
    public void StartFunction()
    {
        if (PV.IsMine)
        {
            mainUser = GameObject.Find("Local");
            playerMaterial = mainUser.GetComponentInChildren<MeshRenderer>().material;
            playerName = GameObject.Find("PlayerName").GetComponent<Text>();
            playerName.text = PhotonNetwork.NickName.ToString();
            PV.RPC("ChangeAvatarTexture", RpcTarget.All, 1);
            playerMovementImpared = true;
            instructions.SetActive(true);
            miniGameStart.SetActive(false);
            startUp = true;
        }
    }
    public void PlayArcadeGame()
    {
        if (PV.IsMine)
        {
            miniGameStart.SetActive(true);
            miniGameText.text = "Press 'F' to play 'Test Scene'.";
        }
        
    }
    public void LeaveArcadeGame()
    {
        miniGameStart.SetActive(false);
    }

}
