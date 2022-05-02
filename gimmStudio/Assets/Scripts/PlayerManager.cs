using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using Photon.Pun;

using System;
using System.Collections;

using UnityEngine.InputSystem;
using Photon.Voice;
using Photon.Voice.Unity;

namespace Com.MyCompany.MyGame
{
    /// <summary>
    /// Player manager.
    /// Handles fire Input and Beams.
    /// </summary>
    public class PlayerManager : MonoBehaviourPunCallbacks
    {
        //Old Code to move player
        //private float inputX, inputZ;
        //private Vector2 deltaPointer;
        //public float moveSpeed = 1000;
        //public Rigidbody theRB;
        //public Transform theCam;
        //public float lookSpeed = 5f;
        //float cameraPitch = 0.0f;
        //private float turnSmoothTime = .01f;
        //private float turnSmoothVelocity = .15f;

        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;
        private AvatarChanges avatar;
        public GameObject myCamera;
        public GameObject player;
        public GameObject exitScreen;
        private VideoPlayers video;
        [Header("Teleports")]
        public GameObject arcade;
        public GameObject arcadeHud;
        public bool canEnterArcade;
        public GameObject plaza;
        public GameObject plazaHud;
        public bool canEnterPlaza;
        public GameObject gallery;
        public GameObject galleryHud;
        public bool canEnterGallery;
        public GameObject classrooms;
        public GameObject classroomsHud;
        public bool canEnterClassrooms;
        public GameObject jackPolifka;
        public GameObject jackPolifkaHud;
        public bool canEnterJackPolifka;
        public GameObject concertHall;
        public GameObject concertHallHud;
        public bool canEnterConcertHall;

        [Header("Microphone Settings")]
        public Recorder primaryRecorder;
        public GameObject micOn, micOff;
        public GameObject voiceManager;

        [Header("MiniGames")]
        private bool isMachine, isLoaded, isPlaying, isBowling;
        private ArcadeScript arcadeCode;
        public BowlingMinigame bowlingCode;
        public GameObject playerModel;
        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
        /// </summary>
        void Awake()
        {      
            if (photonView.IsMine)
            {
                primaryRecorder = voiceManager.GetComponent<Recorder>();
            }
            
            // #Important
            // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
            if (photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
                player = this.gameObject;
                player.name = "Local";
                avatar = this.GetComponent<AvatarChanges>();
            }
            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            if (photonView.IsMine)
            {
                

                if(myCamera.activeSelf == false)
                {
                    myCamera.SetActive(true);

                    primaryRecorder.GetComponent<Recorder>().enabled = false;
                }
               
            }
        }

        private void Update()
        {
            if (photonView.IsMine)
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (canEnterArcade)
                    {
                        if (PhotonNetwork.IsMasterClient)
                        {

                            PhotonNetwork.AutomaticallySyncScene = false;
                            canEnterArcade = false;
                            arcadeHud.SetActive(false);
                            transform.position = new Vector3(-45, .2f, .5f);
                            PhotonNetwork.LoadLevel("PlayArea");

                        }
                        else
                        {
                            canEnterArcade = false;
                            arcadeHud.SetActive(false);
                            transform.position = new Vector3(-45, .2f, .5f);
                            PhotonNetwork.LoadLevel("PlayArea");
                        }
                        
                    }
                    if (canEnterPlaza)
                    {
                        if (PhotonNetwork.IsMasterClient)
                        {

                            PhotonNetwork.AutomaticallySyncScene = false;
                            canEnterPlaza = false;
                            plazaHud.SetActive(false);
                            transform.position = new Vector3(0, 5, 0);
                            PhotonNetwork.LoadLevel("Plaza");

                        }
                        else
                        {
                            canEnterPlaza = false;
                            plazaHud.SetActive(false);
                            transform.position = new Vector3(0, 5, 0);
                            PhotonNetwork.LoadLevel("Plaza");
                        }
                    }
                    if (canEnterGallery)
                    {
                        if (PhotonNetwork.IsMasterClient)
                        {

                            PhotonNetwork.AutomaticallySyncScene = false;
                            canEnterGallery = false;
                            galleryHud.SetActive(false);
                            transform.position = new Vector3(-2, 3, -472);
                            PhotonNetwork.LoadLevel("GallerySpace");

                        }
                        else
                        {
                            canEnterGallery = false;
                            galleryHud.SetActive(false);
                            transform.position = new Vector3(-2, 3, -472);
                            PhotonNetwork.LoadLevel("GallerySpace");
                        }
                    }
                    if (canEnterClassrooms)
                    {
                        if (PhotonNetwork.IsMasterClient)
                        {

                            PhotonNetwork.AutomaticallySyncScene = false;
                            canEnterClassrooms = false;
                            classroomsHud.SetActive(false);
                            transform.position = new Vector3(-200, 5f, 5f);
                            PhotonNetwork.LoadLevel("Classrooms");

                        }
                        else
                        {
                            canEnterClassrooms = false;
                            classroomsHud.SetActive(false);
                            transform.position = new Vector3(-200, 5f, 5f);
                            PhotonNetwork.LoadLevel("Classrooms");
                        }

                    }
                    if (canEnterJackPolifka)
                    {
                        if (PhotonNetwork.IsMasterClient)
                        {

                            PhotonNetwork.AutomaticallySyncScene = false;
                            canEnterJackPolifka = false;
                            jackPolifkaHud.SetActive(false);
                            transform.position = new Vector3(-18.4f, 0.5f, 0.5f);
                            PhotonNetwork.LoadLevel("Jack Polifka's Room");

                        }
                        else
                        {
                            canEnterJackPolifka = false;
                            jackPolifkaHud.SetActive(false);
                            transform.position = new Vector3(-18.44f, 0.5f, 0.5f);
                            PhotonNetwork.LoadLevel("Jack Polifka's Room");
                        }

                    }
                    if (isPlaying)
                    {
                        if (!isLoaded)
                        {

                            if (Input.GetKeyDown(KeyCode.F))
                            {

                                if (isMachine)
                                {
                                    avatar.LeaveArcadeGame();
                                    avatar.playerMovementImpared = true;
                                    arcadeCode.PlayGame();
                                    Debug.Log("Playing Arcade Machine");
                                    isLoaded = true;
                                }
                                    
                                
                                
                                if (isBowling)
                                {
                                    avatar.LeaveArcadeGame();
                                    avatar.playerMovementImpared = true;
                                    bowlingCode.PlayGame();
                                    myCamera.SetActive(false);
                                    playerModel.SetActive(false);
                                    Debug.Log("Bowling!");
                                    isLoaded = true;
                                }



                            }

                        }

                    }
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    if (isLoaded)
                    {
                        if (isBowling)
                        {
                            Debug.Log("Got the L key");
                            avatar.PlayArcadeGame();
                            avatar.playerMovementImpared = false;
                            bowlingCode.LeaveGame();
                            myCamera.SetActive(true);
                            playerModel.SetActive(true);
                            isLoaded = false;
                        }
                        if (isMachine)
                        {
                            Debug.Log("Got the L key");
                            avatar.PlayArcadeGame();
                            avatar.playerMovementImpared = false;
                            arcadeCode.EndGame();
                            isLoaded = false;
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    exitScreen.SetActive(true);
                    avatar.playerMovementImpared = true;
                }

                PushToTalk();
            }
        }
        public void OnTriggerEnter(Collider other)
        {
            if (photonView.IsMine)
            {
                if(other.tag == "ArcadeMachine")
                {
                    avatar.PlayArcadeGame();
                    arcadeCode = other.GetComponent<ArcadeScript>();
                    isPlaying = true;
                    isMachine = true;
                    avatar.miniGameText.text = "Press 'F' to play.";
                }
                if(other.name == "Bowl")
                {
                    avatar.PlayArcadeGame();
                    bowlingCode = other.GetComponent<BowlingMinigame>();
                    isPlaying = true;
                    isBowling = true;
                    avatar.miniGameText.text = "Press F to play Bowling Minigame";
                }
                if(other.tag == "Arcade")
                {
                    arcade = other.gameObject;
                    canEnterArcade = true;
                    arcadeHud.SetActive(true);
                }
                if(other.tag == "Plaza")
                {
                    plaza = other.gameObject;
                    canEnterPlaza = true;
                    plazaHud.SetActive(true);
                }
                if(other.tag == "Gallery")
                {
                    gallery = other.gameObject;
                    canEnterGallery = true;
                    galleryHud.SetActive(true);
                }
                if(other.tag == "Classrooms")
                {
                    classrooms = other.gameObject;
                    canEnterClassrooms = true;
                    classroomsHud.SetActive(true);
                }
                if(other.tag == "Jack Polifka")
                {
                    jackPolifka = other.gameObject;
                    canEnterJackPolifka = true;
                    jackPolifkaHud.SetActive(true);
                }
                if(other.tag == "ConcertHall")
                {
                    concertHall = other.gameObject;
                    canEnterConcertHall = true;
                    concertHallHud.SetActive(true);
                }
                if(other.tag == "Video")
                {
                    video = other.GetComponent<VideoPlayers>();
                    video.StartVideo();
                }
            }
        }
        public void OnTriggerExit(Collider other)
        {
            if (photonView.IsMine)
            {
                if(other.tag == "ArcadeMachine")
                {
                    avatar.LeaveArcadeGame();
                    isPlaying = false;
                    isMachine = false;
                    arcadeCode = null;
                }
                if(other.tag == "Arcade")
                {
                    arcade = other.gameObject;
                    arcadeHud.SetActive(false);
                    canEnterArcade = false;
                }
                if (other.tag == "Plaza")
                {
                    plaza = other.gameObject;
                    canEnterPlaza = false;
                    plazaHud.SetActive(false);
                }
                if (other.tag == "Gallery")
                {
                    gallery = other.gameObject;
                    canEnterGallery = false;
                    galleryHud.SetActive(false);
                }
                if (other.tag == "Classrooms")
                {
                    classrooms = other.gameObject;
                    canEnterClassrooms = false;
                    classroomsHud.SetActive(false);
                }
                if (other.tag == "Jack Polifka")
                {
                    jackPolifka = other.gameObject;
                    canEnterJackPolifka = false;
                    jackPolifkaHud.SetActive(false);
                }
                if (other.tag == "ConcertHall")
                {
                    concertHall = other.gameObject;
                    canEnterConcertHall = false;
                    concertHallHud.SetActive(false);
                }
                if (other.name == "Bowl")
                {
                    avatar.LeaveArcadeGame();
                    isPlaying = false;
                    isBowling = false;
                    bowlingCode = null;
                }
                if (other.tag == "Video")
                {

                    video.StopVideo();
                    video = null;
                }
            }
        }
        

        public void PushToTalk()
        {
            if(photonView.IsMine)
            {
                if (Input.GetKeyDown(KeyCode.V))
                {
                    voiceManager.GetComponent<Recorder>().enabled = true;
                    micOn.SetActive(true);
                    micOff.SetActive(false);
                    Debug.Log("TALKING");
                }
                if (Input.GetKeyUp(KeyCode.V))
                {
                    voiceManager.GetComponent<Recorder>().enabled = false;
                    micOn.SetActive(false);
                    micOff.SetActive(true);
                    Debug.Log("Stop TALKING");
                }
            }
                
            
        }
       
       
       
    }
}


