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
        public static GameManager instance;
        PhotonView PV;
        [Tooltip("The prefab to use for representing the player")]
        public GameObject vrPlayerPrefab;
        public GameObject PlayerPrefab;
        private MeshRenderer player;
        private GameObject mainUser;
        public GameObject settingsPanel;
        private bool mouseVisible;
        private bool settingOpen;
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
                        
                    }
                    if(Application.platform == RuntimePlatform.Android)
                    {
                        Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                        // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                        PhotonNetwork.Instantiate(this.vrPlayerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
                    }
                   
                }
                else
                {
                    Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
                }
            }
            if (PV.IsMine)
            {
                
                
            }
          
        }
        public void Update()
        {
            if(PV.IsMine)
            {
                if(!mouseVisible)
                {
                    if (Input.GetKeyDown(KeyCode.LeftAlt))
                    {
                        Cursor.lockState = CursorLockMode.None;
                        mouseVisible = true;
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.LeftAlt))
                    {
                        Cursor.lockState = CursorLockMode.Locked;
                        mouseVisible = false;
                    }
                }
                if(!settingOpen)
                {
                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        settingsPanel.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;
                        //PhotonNetwork.LocalPlayer.GetComponent<PlayerManager>().moveSpeed = 20f;
                        //GetComponent<PlayerManager>().lookSpeed = 0f;
                        settingOpen = true;
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        settingsPanel.SetActive(false);
                        Cursor.lockState = CursorLockMode.Locked;
                        //GetComponent<PlayerManager>().moveSpeed = 20f;
                        //GetComponent<PlayerManager>().lookSpeed = 5f;
                        settingOpen = false;
                    }
                }
               
            }
            
           
        }

        #region Photon Callbacks


        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
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
