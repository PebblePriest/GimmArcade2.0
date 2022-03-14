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
    PhotonView PV;
    public Text playerName;
    public Text hudPlayerName;

    [Tooltip("Finds the elements of the Local user, to apply effects")]
    private MeshRenderer player;
    public Material playerMaterial;
    bool playerMovementImpared = false;
    private bool startUp = false;

    [Tooltip("Panels that are found in the Game, used to turn on and off at given times")]
    
    public GameObject avatarMenu;
    public GameObject mainUser;
    public GameObject hud;
    public GameObject instructions;
    public GameObject controls;
    public GameObject settings;

    public Material choice1;
    public Material choice2;
    public Material choice3;

   
    public void Awake()
    {
        PV = this.photonView;
    }
    /// <summary>
    /// Find all the required components to run the game, panels and the avatar, as well as the player model and the username
    /// </summary>
    //public void Start()
    //{
    //    if(PV.IsMine)
    //    {
    //        Debug.Log("STARTING UP");
    //        field = GameObject.Find("AvatarInputField").GetComponent<PlayerNameInputField>();
    //        avatarMenu = GameObject.Find("AvatarMenu");
    //        hud = GameObject.Find("Hud");
    //        instructions = GameObject.Find("Instructions");
    //        controls = GameObject.Find("Controls");
    //        settings = GameObject.Find("Settings");
    //        hudPlayerName = GameObject.Find("HudPlayerName").GetComponent<Text>();
    //        settings.SetActive(false);
    //        avatarMenu.SetActive(false);
    //        hud.SetActive(false);
    //        controls.SetActive(false);
    //        playerMovementImpared = true;
    //    }
        

    //}

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
                PV.RPC("ChangeName", RpcTarget.All);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                PV.RPC("ChangeAvatarTexture", RpcTarget.All, 2);
                PV.RPC("ChangeName", RpcTarget.All);
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                PV.RPC("ChangeAvatarTexture", RpcTarget.All, 3);
                PV.RPC("ChangeName", RpcTarget.All);
            }
        }



    }
    public void KeyControlsOn()
    {
        if (PV.IsMine)
        {
            controls.SetActive(true);
        }
    }
    public void KeyControlsOff()
    {
        if (PV.IsMine)
        {
            controls.SetActive(false);
        }
    }
    public void AvatarMenu()
    {
        if (PV.IsMine)
        {
            settings.SetActive(false);
            controls.SetActive(false);
            hud.SetActive(false);
            instructions.SetActive(false);
            mainUser = GameObject.Find("Local");
            playerMaterial = mainUser.GetComponentInChildren<MeshRenderer>().material;
            avatarMenu.SetActive(true);
            hud.SetActive(false);
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
        }
    }
    public void StartGame()
    {
        if (PV.IsMine)
        {
            playerName.text = PhotonNetwork.NickName.ToString();
            PV.RPC("ChangeName", RpcTarget.All);
            avatarMenu.SetActive(false);
            hud.SetActive(true);
            mainUser.GetComponentInChildren<Camera>().enabled = true;
            avatarChanging = false;
            playerMovementImpared = false;
        }
    }

    /// <summary>
    /// This RPC passes the texture set within the avatar menu to the player model, for all to see
    /// </summary>
    [PunRPC]
    void ChangeName()
    {
        mainUser.GetComponentInChildren<Text>().text = playerName.text;
        hudPlayerName.text = playerName.text;
    }
    [PunRPC]
    void ChangeAvatarTexture(int choice)
    {
        if (choice == 1)
        {
            mainUser.GetComponentInChildren<Renderer>().material = choice1;
        }
        if (choice == 2)
        {
            mainUser.GetComponentInChildren<Renderer>().material = choice2;
        }
        if (choice == 3)
        {
            mainUser.GetComponentInChildren<Renderer>().material = choice3;
        }
        //hair = field.hair.value;
        //face = field.face.value;
        //body = field.body.value;
        ////Debug.Log(hair + " " + face + " " + body);
        //Color color = playerMaterial.color;
        //color.r = hair;
        //color.g = face;
        //color.b = body;
        //playerMaterial.color = color;
        ////playerMaterial.SetColor("Avatarbody", color);
        //mainUser.GetComponentInChildren<MeshRenderer>().material.SetColor("Avatarbody", color);
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
            PV.RPC("ChangeName", RpcTarget.All);
            startUp = true;
        }
    }

}
