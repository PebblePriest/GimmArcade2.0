using Com.MyCompany.MyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SettingsAndTools : MonoBehaviourPunCallbacks
{
    private GameObject mainUser;
    public GameObject settingsPanel;
    private bool mouseVisible;
    private bool settingOpen;
    public PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        mainUser = GameObject.Find("Local");
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
            if (!settingOpen)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    settingsPanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    mainUser.GetComponent<PlayerManager>().moveSpeed = 0f;
                    mainUser.GetComponent<PlayerManager>().lookSpeed = 0f;
                    settingOpen = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    settingsPanel.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    mainUser.GetComponent<PlayerManager>().moveSpeed = 20f;
                    mainUser.GetComponent<PlayerManager>().lookSpeed = 5f;
                    settingOpen = false;
                }
            }
        }
        
    }
}
