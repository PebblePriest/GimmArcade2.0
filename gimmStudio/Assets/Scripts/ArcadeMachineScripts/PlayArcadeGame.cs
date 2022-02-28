using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class PlayArcadeGame : MonoBehaviourPunCallbacks
{
   
    public PhotonView PV;
    public GameObject playPanel;
    public Text gameText;
    public bool isPlaying;
    private bool isLoaded;
    private GameObject player;
    public GameObject testCam;
   
    public void Awake()
    {
        PV = this.photonView;
        playPanel.SetActive(false);
    }
    public void Start()
    {
        gameText.text += " Test Scene.";
    }
 
    public void OnTriggerEnter(Collider other)
    {
        if(PV.IsMine)
        {
            if (other.tag == "Player")
            {
                player = other.gameObject;
                playPanel.SetActive(true);
                isPlaying = true;
                
            }
        }
       
    }
    public void OnTriggerExit(Collider other)
    {
        if (PV.IsMine)
        {
            if (other.tag == "Player")
            {
                playPanel.SetActive(false);
                isPlaying = false;
            }
        }
       
    }
    public void Update()
    {
        if (PV.IsMine)
        {
            if (isPlaying)
            {
                if (!isLoaded)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        player.GetComponentInChildren<Camera>().enabled = false;
                        Debug.Log("Loaded new Scene");
                        SceneManager.LoadSceneAsync("Test", LoadSceneMode.Additive);
                        isLoaded = true;
                        playPanel.SetActive(false);
                        testCam.SetActive(true);


                    }
                   
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        player.GetComponentInChildren<Camera>().enabled = true;
                        SceneManager.UnloadSceneAsync("Test");
                        isLoaded = false;
                        playPanel.SetActive(true);
                        testCam.SetActive(false);
                    }
                }
                

            }
        }
      
       
    }
    
}
