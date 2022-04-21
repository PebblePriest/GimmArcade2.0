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
        private float inputX, inputZ;
        private Vector2 deltaPointer;
        public float moveSpeed = 1000;
        public Rigidbody theRB;
        public Transform theCam;
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;
        private AvatarChanges avatar;
        public GameObject myCamera;
        public float lookSpeed = 5f;
        float cameraPitch = 0.0f;
        public GameObject player;
        public GameObject testCam;
        private ArcadeScript arcadeCode;
        private float turnSmoothTime = .01f;
        private float turnSmoothVelocity = .15f;
        public bool isTest, isOcular, isLoaded, isPlaying;
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

        [Header("Microphone Settings")]
        public Recorder primaryRecorder;
        public GameObject micOn, micOff;
        public GameObject voiceManager;

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
                //Cursor.lockState = CursorLockMode.Locked;

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
                MouseLookAround();

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
                    if (isPlaying)
                    {
                        if (!isLoaded)
                        {

                            if (Input.GetKeyDown(KeyCode.F))
                            {
                                if (isTest)
                                {
                                    avatar.LeaveArcadeGame();
                                    avatar.playerMovementImpared = true;
                                    arcadeCode.PlayGame();
                                    Debug.Log("Playing Test Game");
                                    SceneManager.LoadSceneAsync("Test", LoadSceneMode.Additive);
                                    isLoaded = true;
                                }
                                if (isOcular)
                                {
                                    avatar.LeaveArcadeGame();
                                    avatar.playerMovementImpared = true;
                                    arcadeCode.PlayGame();
                                    Debug.Log("Playing Ocular Dark");
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
                        Debug.Log("Got the L key");
                        avatar.PlayArcadeGame();
                        avatar.playerMovementImpared = false;
                        arcadeCode.EndGame();
                        isLoaded = false;
                        if (isTest)
                        {
                            SceneManager.UnloadSceneAsync("Test");
                        }
                            

                        
                    }
                }
                    
                    





                
                
               
                //myCamera.transform.localEulerAngles = new Vector3(0f, theCam.localEulerAngles.y, 0f);

                PushToTalk();
            }
        }

        private void FixedUpdate()
        {
            if (photonView.IsMine)
            {
                theRB.AddForce(transform.forward * inputZ * moveSpeed, ForceMode.Force);
                theRB.AddForce(transform.right * inputX * moveSpeed, ForceMode.Force);

                //theRB.velocity = new Vector3(inputX * moveSpeed, theRB.velocity.y, inputZ * moveSpeed);

                

            }
        }

        public void Move(InputAction.CallbackContext context)
        {
            if (photonView.IsMine)
            {
                if (context.performed)
                {
                    inputX = context.ReadValue<Vector2>().x;

                    inputZ = context.ReadValue<Vector2>().y;
                }
            }
        }

        public void Look(InputAction.CallbackContext context)
        {
            if (photonView.IsMine)
            {
                deltaPointer = context.ReadValue<Vector2>();
            }
        }
        public void MouseLookAround()
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            cameraPitch -= mouseDelta.y * lookSpeed;

            cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

            theCam.localEulerAngles = Vector3.right * cameraPitch;

            transform.Rotate(Vector3.up * mouseDelta.x * lookSpeed);
        }
        public void OnTriggerEnter(Collider other)
        {
            if (photonView.IsMine)
            {
                if(other.name == "TestMachine")
                {
                    
                    avatar.PlayArcadeGame();
                    arcadeCode = other.GetComponent<ArcadeScript>();
                    isPlaying = true;
                    isTest = true;
                    Debug.Log("In front of test Machine");
                    avatar.miniGameText.text = "Press 'F' to play Test Scene.";
                }
                if(other.name == "OcularDark")
                {
                    avatar.PlayArcadeGame();
                    arcadeCode = other.GetComponent<ArcadeScript>();
                    isPlaying = true;
                    isOcular = true;
                    Debug.Log("In front of Ocular Dark");
                    avatar.miniGameText.text = "Press 'F' to play Ocular Dark.";
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
            }
        }
        public void OnTriggerExit(Collider other)
        {
            if (photonView.IsMine)
            {
                if(other.name == "TestMachine")
                {
                    avatar.LeaveArcadeGame();
                    isPlaying = false;
                    isTest = false;
                }
                if(other.name == "OcularDark")
                {
                    avatar.LeaveArcadeGame();
                    isPlaying = false;
                    isOcular = false;
                }
                if(other.tag == "Arcade")
                {
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


