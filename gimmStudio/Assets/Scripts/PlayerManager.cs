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
        private bool isPlaying;
        public GameObject myCamera;
        public float lookSpeed = 5f;
        float cameraPitch = 0.0f;
        public GameObject player;
        private bool isLoaded;
        public GameObject testCam;
        private ArcadeScript arcadeCode;
        private float turnSmoothTime = .01f;
        private float turnSmoothVelocity = .15f;
        public Recorder primaryRecorder;
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
                //Vector3 direction = new Vector3(inputX, 0f, inputZ).normalized;

                //if (direction.magnitude >= 0.1f)
                //{
                //    //gets angle of camera to rotate player based on that angle
                //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + myCamera.transform.eulerAngles.y;
                //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                //    //rotates player
                //    transform.rotation = Quaternion.Euler(0f, angle, 0f);


                //    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                //    theRB.velocity = new Vector3(moveDir.normalized.x * moveSpeed * Time.deltaTime, theRB.velocity.y, moveDir.normalized.z * moveSpeed * Time.deltaTime);
                //}
                if (isPlaying)
                    {
                        if (!isLoaded)
                        {
                            if (Input.GetKeyDown(KeyCode.F))
                            {
                                avatar.LeaveArcadeGame();
                                avatar.playerMovementImpared = true;
                                arcadeCode.PlayGame();
                                Debug.Log("Loaded new Scene");
                                SceneManager.LoadSceneAsync("Test", LoadSceneMode.Additive);
                                isLoaded = true;


                            }

                        }
                        else
                        {
                            if (Input.GetKeyDown(KeyCode.L))
                            {
                                avatar.PlayArcadeGame();
                                avatar.playerMovementImpared = false;
                                arcadeCode.EndGame();
                                SceneManager.UnloadSceneAsync("Test");
                                isLoaded = false;
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
                    Debug.Log("TALKING");
                }
                if (Input.GetKeyUp(KeyCode.V))
                {
                    voiceManager.GetComponent<Recorder>().enabled = false;
                    Debug.Log("Stop TALKING");
                }
            }
                
            
        }
    }
}


