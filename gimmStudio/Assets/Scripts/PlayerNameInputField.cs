
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{
    /// <summary>
    /// player name input field. let the user input his name, will appear above the player in the game.
    /// </summary>

    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviourPunCallbacks
    {
        #region Private constants

        const string playerNamePrefKey = "PlayerName";

        #endregion
        
        public MeshRenderer avatar;
        public Slider face;
        public Slider hair;
        public Slider body;
        Color color;
        PhotonView PV;
        #region MonoBehaviour CallBacks

        /// <summary>
        /// monobehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        public void Awake()
        {
            PV = this.photonView;
        }
        void Start()
        {
            string defaultName = string.Empty;
            InputField _inputField = this.GetComponent<InputField>();
            if (_inputField != null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.text = defaultName;
                }
            }

            PhotonNetwork.NickName = defaultName;
            
        }

        #endregion

        #region Public Methods

        ///<summary>
        /// sets the name of the player, and save it in the playerprefs for future seesions.
        ///</summary>
        /// <param name="value">the name of the Player</param>
        public void SetPlayerName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player Name is null or empty");
                return;
            }
            PhotonNetwork.NickName = value;

            PlayerPrefs.SetString(playerNamePrefKey, value);
        }
        private void AvatarChange()
        {
            Color color = avatar.material.color;
            color.r = hair.value;
            color.g = face.value;
            color.b = body.value;
            avatar.material.color = color;
            avatar.material.SetColor("AvatarMaterial", color);

        }
       
        #endregion
    }
}