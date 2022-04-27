using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Com.MyCompany.MyGame;
using SUPERCharacter;
public class AvatarChanges : MonoBehaviourPunCallbacks
{
    [Tooltip("Script for the color changing Avatar Menu as well as values used within that script passed to this one")]
    public PlayerNameInputField field;
    public float hair, body, face;
    public bool avatarChanging;


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
    public Renderer playerModel;

    public Material avatarBody;
    public GameObject playerBody;
    public Material choice1;
    public Color color;
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
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                mainUser.GetComponent<SUPERCharacterAIO>().enabled = false;

            }
            else
            {
                mainUser.GetComponent<SUPERCharacterAIO>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            if (avatarChanging)
            {
                if (playerBody == null)
                {
                    Debug.Log("Avatar Color is NonBinary");
                    playerBody = GameObject.Find("avatarBase_NonBinary(Clone)");
                    if (playerBody == null)
                    {
                        playerBody = GameObject.Find("AvatarBase_Female(Clone)");
                        if (playerBody == null)
                        {
                            playerBody = GameObject.Find("avatarBase_Male(Clone)");
                            if (playerBody == null)
                            {
                                Debug.Log("There is no body here!");
                            }
                            else
                            {
                                avatarBody = playerBody.GetComponentInChildren<MeshRenderer>().material;
                                color = avatarBody.color;
                                playerBody = null;
                                Debug.Log("I have gotten the material for the Male body!");
                            }
                        }
                        else
                        {
                            avatarBody = playerBody.GetComponentInChildren<MeshRenderer>().material;
                            color = avatarBody.color;
                            playerBody = null;
                            Debug.Log("I have gotten the material for the Female body!");
                        }
                    }
                    else
                    {
                        avatarBody = playerBody.GetComponentInChildren<MeshRenderer>().material;
                        color = avatarBody.color;
                        playerBody = null;
                        Debug.Log("I have gotten the material for the Non Binary Body!");
                    }

                }

            }
        }
        else
        {
            playerName.text = PV.Owner.NickName;
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
            PV.RPC("ChangeUsername", RpcTarget.AllBuffered, 1);
            PV.RPC("ColorChange", RpcTarget.AllBuffered, new Vector3(color.r, color.g, color.b));
            avatarMenu.SetActive(false);
            hud.SetActive(true);
            mainUser.GetComponentInChildren<Camera>().enabled = true;
            avatarChanging = false;
            playerMovementImpared = false;
        }
    }


    [PunRPC]
    void ChangeUsername(int choice)
    {
        if (choice == 1)
        {
            mainUser.GetComponentInChildren<Text>().text = playerName.text;
            hudPlayerName.text = playerName.text;
        }
    }
    [PunRPC]
    void ColorChange(Vector3 randomColor)
    {

        Color playerColor = new Color(randomColor.x, randomColor.y, randomColor.z);
        playerModel.material.color = playerColor;
    }
    /// <summary>
    /// Runs in the first update to make sure all the elements of the player are found correctly, as well as pass over the network the username and color of the character.
    /// </summary>
    public void StartFunction()
    {
        if (PV.IsMine)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mainUser = GameObject.Find("Local");
            playerName = GameObject.Find("PlayerName").GetComponent<Text>();
            playerName.text = PhotonNetwork.NickName;
            PV.RPC("ChangeUsername", RpcTarget.AllBuffered, 1);
            PV.RPC("ColorChange", RpcTarget.AllBuffered, new Vector3(color.r, color.g, color.b));
            playerMovementImpared = true;
            instructions.SetActive(true);
            miniGameStart.SetActive(false);
            startUp = true;
        }
        else
        {
            playerName.text = PV.Owner.NickName;
        }
    }
    public void PlayArcadeGame()
    {
        if (PV.IsMine)
        {
            Debug.Log("Looking for matches");
            miniGameStart.SetActive(true);
          
        }
        
    }
    public void LeaveArcadeGame()
    {
        miniGameStart.SetActive(false);
    }

}
