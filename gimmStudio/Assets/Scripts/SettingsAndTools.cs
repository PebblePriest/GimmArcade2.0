using Com.MyCompany.MyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SettingsAndTools : MonoBehaviourPunCallbacks
{
    private GameObject mainUser;
    private AvatarChanges avatar;
    public GameObject settingsPanel;
    private bool mouseVisible;
    private bool settingOpen;
    public PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        mainUser = GameObject.Find("Local");
        avatar = mainUser.GetComponent<AvatarChanges>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            if (!mouseVisible)
            {
                if (Input.GetKeyDown(KeyCode.LeftAlt))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    mouseVisible = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.LeftAlt))
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    mouseVisible = false;
                }
            }
            if (!settingOpen)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    settingsPanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    avatar.playerMovementImpared = true;
                    settingOpen = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    settingsPanel.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    avatar.playerMovementImpared = false;
                    settingOpen = false;
                }
            }
        }
        
    }
}
