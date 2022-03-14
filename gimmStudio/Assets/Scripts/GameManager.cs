using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [Tooltip("Makes sure the game only has one instance of the GameManager")]
        public static GameManager instance;

        [Tooltip("Script for the color changing Avatar Menu as well as values used within that script passed to this one")]
        public PlayerNameInputField field;
        public float hair, body, face;
        Color color;
        private bool avatarChanging;
       

        [Tooltip("PhotonView for the Game Manager so changes cross over the network, as well as the player name saved over the network")]
        PhotonView PV;
        public Text playerName;

        [Tooltip("The prefabs to use for representing the player")]
        public GameObject vrPlayerPrefab;
        public GameObject PlayerPrefab;

        [Tooltip("Finds the elements of the Local user, to apply effects")]
        private MeshRenderer player;
        public Material playerMaterial;
        bool playerMovementImpared = false;
        bool findPlayer = false;

        [Tooltip("Panels that are found in the Game, used to turn on and off at given times")]
        public GameObject avatarMenu;
        public GameObject mainUser;
        public GameObject hud;
        public GameObject controlsMenu;
        public GameObject keyBindings;
        
        public void Awake()
        {
            PV = this.photonView;
        }
        private void Start()
        {
           
            instance = this;
            
            if (vrPlayerPrefab == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            }
            else
            {
                if (PlayerManager.LocalPlayerInstance == null)
                {
                    if(Application.platform == RuntimePlatform.WindowsEditor)
                    {
                        Debug.Log("You on Windows");
                        PhotonNetwork.Instantiate(this.PlayerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
                        if (PV.IsMine)
                        {
                            controlsMenu.SetActive(true);
                            playerMovementImpared = true;
                        }

                    }
                    if(Application.platform == RuntimePlatform.Android)
                    {
                        Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                        // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                        PhotonNetwork.Instantiate(this.vrPlayerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
                        if (PV.IsMine)
                        {
                            controlsMenu.SetActive(true);
                            playerMovementImpared = true;
                        }
                    }
                   
                }
                else
                {
                    Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
                }
            }
            
            
            
        }
        public void Update()
        {
            if (PV.IsMine)
            {
                if (!findPlayer)
                {
                    mainUser = GameObject.Find("Local");
                    findPlayer = true;
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
            }
           
            
           
        }

        #region Photon Callbacks
        public void Instructions()
        {
            keyBindings.SetActive(true);
        }
        public void InstructionsOff()
        {
            keyBindings.SetActive(false);
        }

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public void AvatarMenu()
        {
            mainUser = GameObject.Find("Local");
            playerMaterial = mainUser.GetComponentInChildren<MeshRenderer>().material;
            avatarMenu.SetActive(true);
            hud.SetActive(false);
            mainUser.GetComponentInChildren<Camera>().enabled = false;
            avatarChanging = true;
            playerMovementImpared = true;
        }
        public void CustomizeCharacter()
        {
            AvatarMenu();
            controlsMenu.SetActive(false);
        }
        public void StartGame()
        {
            photonView.RPC("ChangeAvatarTexture", RpcTarget.All, playerMaterial);
            playerName.text = PhotonNetwork.NickName.ToString();
            avatarMenu.SetActive(false);
            hud.SetActive(true);
            mainUser.GetComponentInChildren<Camera>().enabled = true;
            avatarChanging = false;
            playerMovementImpared = false;
        }
        #endregion
        /// <summary>
        /// This RPC passes the texture set within the avatar menu to the player model, for all to see
        /// </summary>
        [PunRPC]
        void ChangeAvatarTexture()
        {
            hair = field.hair.value;
            face = field.face.value;
            body = field.body.value;
            //Debug.Log(hair + " " + face + " " + body);
            Color color = playerMaterial.color;
            color.r = hair;
            color.g = face;
            color.b = body;
            playerMaterial.color = color;
            playerMaterial.SetColor("Avatarbody", color);
        }

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
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            PhotonNetwork.LoadLevel(1);
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
}
