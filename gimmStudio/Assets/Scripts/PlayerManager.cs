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
        public float moveSpeed;
        public Rigidbody theRB;
        
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;

       
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

        private void FixedUpdate()
        {
            theRB.velocity = new Vector3(inputX * moveSpeed, theRB.velocity.y, inputZ * moveSpeed);
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
    }
}


