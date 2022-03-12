using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using Photon.Pun;

using System;
using System.Collections;

using UnityEngine.InputSystem;

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
        public float moveSpeed;
        public Rigidbody theRB;
        public Transform theCam;
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;

        public GameObject myCamera;
        public float lookSpeed = 5f;
        float cameraPitch = 0.0f;
        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
        /// </summary>
        void Awake()
        {


            // #Important
            // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
            if (photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
            }
            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            if (photonView.IsMine)
            {
                Cursor.lockState = CursorLockMode.Locked;

                if(myCamera.activeSelf == false)
                {
                    myCamera.SetActive(true);
                }
            }
        }

        private void Update()
        {
            if (photonView.IsMine)
            {
                MouseLookAround();
                
                //myCamera.transform.localEulerAngles = new Vector3(0f, theCam.localEulerAngles.y, 0f);
            }
        }

        private void FixedUpdate()
        {
            //theRB.velocity = new Vector3(inputX * moveSpeed, theRB.velocity.y, inputZ * moveSpeed);
            if (photonView.IsMine)
            {
                theRB.AddForce(transform.forward * inputZ * moveSpeed, ForceMode.Force);
                theRB.AddForce(transform.right * inputX * moveSpeed, ForceMode.Force);

                //myCamera.transform.Rotate(new Vector3(0f, deltaPointer.x, 0f), Space.World);
                //myCamera.transform.Rotate(new Vector3(-deltaPointer.y, 0f, 0f), Space.World);
                
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
    }
}


