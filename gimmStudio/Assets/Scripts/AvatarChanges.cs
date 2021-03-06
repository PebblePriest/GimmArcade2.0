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
    public Renderer hairModel;
    public Renderer shirtModel;
    public Material avatarBody;
    public Color color;
    public Color hairColor;
    public Material hairMaterial;
    public Color top;
    public Material topMaterial;

    [Header("Player GameObjects")]
    private GameObject playerBody;
    private GameObject hairBody;
    private GameObject playerShirt;
    public GameObject nonBinaryBody, femaleBody, maleBody, hairStyle1, hairStyle2, hairStyle3, hairStyle4, hat1, suitAndTie, fancyShirt;
    public bool isMale, isFemale, isNon,noHair, isHair1, isHair2, isHair3, isHair4, isFedora, isFancy, isSuit, isBare;
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
                hud.SetActive(false);
                mainUser.GetComponent<SUPERCharacterAIO>().enabled = false;

            }
            else
            {
                mainUser.GetComponent<SUPERCharacterAIO>().enabled = true;
                hud.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            if (avatarChanging)
            {
                if(hairBody == null)
                {
                    Debug.Log("Hair Color is Choice 1");
                    hairBody = GameObject.Find("Avatar_Hair_1(Clone)");
                    if (hairBody == null)
                    {
                        Debug.Log("Hair Color is Choice 2");
                        hairBody = GameObject.Find("Avatar_Hair_2(Clone)");
                        if (hairBody == null)
                        {
                            Debug.Log("Hair Color is Choice 3");
                            hairBody = GameObject.Find("Avatar_Hair_3(Clone)");
                            if (hairBody == null)
                            {
                                Debug.Log("Hair Color is Choice 4");
                                hairBody = GameObject.Find("Avatar_Hair_4(Clone)");
                                if (hairBody == null)
                                {
                                    Debug.Log("There is no hair here!");
                                    isHair1 = false;
                                    isHair2 = false;
                                    isHair3 = false;
                                    isHair4 = false;
                                    noHair = true;
                                }
                                else
                                {
                                    isHair1 = false;
                                    isHair2 = false;
                                    isHair3 = false;
                                    isHair4 = true;
                                    noHair = false;
                                    hairMaterial = hairBody.GetComponentInChildren<MeshRenderer>().material;
                                    hairColor = hairMaterial.color;
                                    hairBody = null;
                                    Debug.Log("You have chosen hair 4");
                                }
                            }
                            else
                            {
                                isHair1 = false;
                                isHair2 = false;
                                isHair3 = true;
                                isHair4 = false;
                                noHair = false;
                                hairMaterial = hairBody.GetComponentInChildren<MeshRenderer>().material;
                                hairColor = hairMaterial.color;
                                hairBody = null;
                                Debug.Log("You have chosen hair 3");
                            }
                        }
                        else
                        {
                            isHair1 = false;
                            isHair2 = true;
                            isHair3 = false;
                            isHair4 = false;
                            noHair = false;
                            hairMaterial = hairBody.GetComponentInChildren<MeshRenderer>().material;
                            hairColor = hairMaterial.color;
                            hairBody = null;
                            Debug.Log("You have chosen hair 2");
                        }
                    }
                    else
                    {
                        isHair1 = true;
                        isHair2 = false;
                        isHair3 = false;
                        isHair4 = false;
                        noHair = false;
                        hairMaterial = hairBody.GetComponentInChildren<MeshRenderer>().material;
                        hairColor = hairMaterial.color;
                        hairBody = null;
                        Debug.Log("You have chosen hair 1");
                    }
                }
                if(playerShirt == null)
                {
                    Debug.Log("Shirt 1 Chosen");
                    playerShirt = GameObject.Find("CharacterSuit(Clone)");
                    if(playerShirt == null)
                    {
                        Debug.Log("Shirt 2 Chosen");
                        playerShirt = GameObject.Find("FancyShirt(Clone)");
                        if (playerShirt == null)
                        {
                            Debug.Log("No Shirt found!");
                            isSuit = false;
                            isFancy = false;
                            isBare = true;
                        }
                        else
                        {
                            Debug.Log("Fancy");
                            isSuit = false;
                            isFancy = true;
                            isBare = false;
                            topMaterial = playerShirt.GetComponentInChildren<MeshRenderer>().material;
                            top = topMaterial.color;
                            playerShirt = null;
                        }
                    }
                    else
                    {
                        Debug.Log("Suit");
                        isSuit = true;
                        isFancy = false;
                        isBare = false;
                        topMaterial = playerShirt.GetComponentInChildren<MeshRenderer>().material;
                        top = topMaterial.color;
                        playerShirt = null;
                    }
                    
                }

                if (playerBody == null)
                {
                    Debug.Log("Avatar Color is NonBinary");
                    playerBody = GameObject.Find("avatarBase_NonBinary(Clone)");
                    
                    if (playerBody == null)
                    {
                        Debug.Log("You are not NonBinary");
                        playerBody = GameObject.Find("AvatarBase_Female(Clone)");
                       
                        
                        if (playerBody == null)
                        {
                            Debug.Log("You are not female");
                            playerBody = GameObject.Find("avatarBase_Male(Clone)");
                            
                            
                            if (playerBody == null)
                            {
                                Debug.Log("There is no body here!");
                            }
                            else
                            {
                                
                               
                                isMale = true;
                                isFemale = false;
                                isNon = false;
                                //playerModel = GameObject.Find("VisiblePlayerAnchor").transform.Find("avatarBase_Male(Clone)").GetComponentInChildren<Renderer>();
                                avatarBody = playerBody.GetComponentInChildren<MeshRenderer>().material;
                                color = avatarBody.color;
                                playerBody = null;
                                Debug.Log("I have gotten the material for the Male body!");
                            }
                        }
                        else
                        {
                            
                            isFemale = true;
                            isMale = false;
                            isNon = false;
                            //playerModel = GameObject.Find("VisiblePlayerAnchor").transform.Find("AvatarBase_Female(Clone)").GetComponentInChildren<Renderer>();
                            avatarBody = playerBody.GetComponentInChildren<MeshRenderer>().material;
                            color = avatarBody.color;
                           
                            playerBody = null;
                            Debug.Log("I have gotten the material for the Female body!");
                        }
                    }
                    else
                    {
                        
                        isNon = true;
                        isMale = false;
                        isFemale = false; 
                        //playerModel = GameObject.Find("VisiblePlayerAnchor").transform.Find("avatarBase_NonBinary(Clone)").GetComponentInChildren<Renderer>();
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
            AvatarBodySelect();
           
            avatarMenu.SetActive(false);
            hud.SetActive(true);
            mainUser.GetComponentInChildren<Camera>().enabled = true;
            avatarChanging = false;
            playerMovementImpared = false;
        }
    }
    [PunRPC]
    void ShirtOption1(bool isActive)
    {
        if (isActive)
        {
            fancyShirt.SetActive(isActive);
            shirtModel = fancyShirt.GetComponentInChildren<MeshRenderer>();
        }
        if (!isActive)
        {
            fancyShirt.SetActive(isActive);
            Debug.Log("Do not set the hairModel for the hairstyle1");
        }


    }
    [PunRPC]
    void ShirtOption2(bool isActive)
    {
        if (isActive)
        {
            suitAndTie.SetActive(isActive);
            shirtModel = suitAndTie.GetComponentInChildren<MeshRenderer>();
        }
        if (!isActive)
        {
            suitAndTie.SetActive(isActive);
            Debug.Log("Do not set the hairModel for the hairstyle1");
        }


    }
    [PunRPC]
    void HairOption1(bool isActive)
    {
        if (isActive)
        {
            hairStyle1.SetActive(isActive);
            hairModel = hairStyle1.GetComponentInChildren<MeshRenderer>();
        }
        if (!isActive)
        {
            hairStyle1.SetActive(isActive);
            Debug.Log("Do not set the hairModel for the hairstyle1");
        }


    }
    [PunRPC]
    void HairOption2(bool isActive)
    {
        if (isActive)
        {
            hairStyle2.SetActive(isActive);
            hairModel = hairStyle2.GetComponentInChildren<MeshRenderer>();
        }
        if (!isActive)
        {
            hairStyle2.SetActive(isActive);
            Debug.Log("Do not set the hairModel for the hairstyle2");
        }


    }
    [PunRPC]
    void HairOption3(bool isActive)
    {
        if (isActive)
        {
            hairStyle3.SetActive(isActive);
            hairModel = hairStyle3.GetComponentInChildren<MeshRenderer>();
        }
        if (!isActive)
        {
            hairStyle3.SetActive(isActive);
            Debug.Log("Do not set the hairModel for the hairstyle3");
        }


    }
    [PunRPC]
    void NonBinaryAvatar(bool isActive)
    {
        if (isActive)
        {
            nonBinaryBody.SetActive(isActive);
            playerModel = nonBinaryBody.GetComponentInChildren<MeshRenderer>();
        }
        if (!isActive)
        {
            nonBinaryBody.SetActive(isActive);
            Debug.Log("Do not set the playerModel color for nonbinary body");
        }
       
        
    }
    [PunRPC]
    void MaleAvatar(bool isActive)
    {
        if (isActive)
        {
            maleBody.SetActive(isActive);
            playerModel = maleBody.GetComponentInChildren<MeshRenderer>();
        }
        if (!isActive)
        {
            maleBody.SetActive(isActive);
            Debug.Log("Do not set the playerModel color for male body");
        }


    }
    [PunRPC]
    void FemaleAvatar(bool isActive)
    {
        if (isActive)
        {
            femaleBody.SetActive(isActive);
            playerModel = femaleBody.GetComponentInChildren<MeshRenderer>();
        }
        if (!isActive)
        {
            femaleBody.SetActive(isActive);
            Debug.Log("Do not set the playerModel color for female body");
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
    void HairColorChange(Vector3 randomColor)
    {

        Color hairColor = new Color(randomColor.x, randomColor.y, randomColor.z);
        hairModel.material.color = hairColor;
    }
    [PunRPC]
    void ShirtColorChange(Vector3 randomColor)
    {

        Color topColor = new Color(randomColor.x, randomColor.y, randomColor.z);
        shirtModel.material.color = topColor;
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
            PV.RPC("NonBinaryAvatar", RpcTarget.AllBuffered, true);
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
    public void AvatarBodySelect()
    {
        PV.RPC("ChangeUsername", RpcTarget.AllBuffered, 1);
        if (isNon)
        {

            PV.RPC("NonBinaryAvatar", RpcTarget.AllBuffered, true);
            PV.RPC("MaleAvatar", RpcTarget.AllBuffered, false);
            PV.RPC("FemaleAvatar", RpcTarget.AllBuffered, false);
            PV.RPC("ColorChange", RpcTarget.AllBuffered, new Vector3(color.r, color.g, color.b));
        }
        if (isMale)
        {

            PV.RPC("NonBinaryAvatar", RpcTarget.AllBuffered, false);
            PV.RPC("MaleAvatar", RpcTarget.AllBuffered, true);
            PV.RPC("FemaleAvatar", RpcTarget.AllBuffered, false);
            PV.RPC("ColorChange", RpcTarget.AllBuffered, new Vector3(color.r, color.g, color.b));
        }

        if (isFemale)
        {

            PV.RPC("NonBinaryAvatar", RpcTarget.AllBuffered, false);
            PV.RPC("MaleAvatar", RpcTarget.AllBuffered, false);
            PV.RPC("FemaleAvatar", RpcTarget.AllBuffered, true);
            PV.RPC("ColorChange", RpcTarget.AllBuffered, new Vector3(color.r, color.g, color.b));
        }
        if (noHair)
        {
            PV.RPC("HairOption1", RpcTarget.AllBuffered, false);
            PV.RPC("HairOption2", RpcTarget.AllBuffered, false);
            PV.RPC("HairOption3", RpcTarget.AllBuffered, false);
        }
        if(isHair1)
        {
            PV.RPC("HairOption1", RpcTarget.AllBuffered, true);
            PV.RPC("HairOption2", RpcTarget.AllBuffered, false);
            PV.RPC("HairOption3", RpcTarget.AllBuffered, false);
            PV.RPC("HairColorChange", RpcTarget.AllBuffered, new Vector3(hairColor.r, hairColor.g, hairColor.b));
        }
        if(isHair2)
        {
            PV.RPC("HairOption1", RpcTarget.AllBuffered, false);
            PV.RPC("HairOption2", RpcTarget.AllBuffered, true);
            PV.RPC("HairOption3", RpcTarget.AllBuffered, false);
            PV.RPC("HairColorChange", RpcTarget.AllBuffered, new Vector3(hairColor.r, hairColor.g, hairColor.b));
        }
        if (isHair3)
        {
            PV.RPC("HairOption1", RpcTarget.AllBuffered, false);
            PV.RPC("HairOption2", RpcTarget.AllBuffered, false);
            PV.RPC("HairOption3", RpcTarget.AllBuffered, true);
            PV.RPC("HairColorChange", RpcTarget.AllBuffered, new Vector3(hairColor.r, hairColor.g, hairColor.b));
        }
        if (isFancy)
        {
            PV.RPC("ShirtOption1", RpcTarget.AllBuffered, true);
            PV.RPC("ShirtOption2", RpcTarget.AllBuffered, false);
            PV.RPC("ShirtColorChange", RpcTarget.AllBuffered, new Vector3(top.r, top.g, top.b));
        }
        if (isSuit)
        {
            PV.RPC("ShirtOption1", RpcTarget.AllBuffered, false);
            PV.RPC("ShirtOption2", RpcTarget.AllBuffered, true);
            PV.RPC("ShirtColorChange", RpcTarget.AllBuffered, new Vector3(top.r, top.g, top.b));
        }
        if (isBare)
        {
            PV.RPC("ShirtOption1", RpcTarget.AllBuffered, false);
            PV.RPC("ShirtOption2", RpcTarget.AllBuffered, false);
        }
        
        
    }

}
