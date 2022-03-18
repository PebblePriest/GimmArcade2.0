using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Com.MyCompany.MyGame;

public class PlayArcadeGame : MonoBehaviour
{
   
    
    public GameObject playPanel;
    public Text gameText;
    public bool isPlaying;
    private bool isLoaded;
    private GameObject player;
    public GameObject testCam;
    bool findLocalPlayer = false;
   
    public void Awake()
    {
        
        
        testCam.SetActive(false);
    }
   
 
    public void OnTriggerEnter(Collider other)
    {
        
            if (other.name == "Local")
            {
                player = other.gameObject;
                playPanel = GameObject.Find("LocalStartGame");
                gameText = playPanel.GetComponentInChildren<Text>();
                gameText.text += " Test Scene.";
                playPanel.SetActive(true);
                isPlaying = true;
                
            }
        
       
    }
    public void OnTriggerExit(Collider other)
    {
        
            if (other.name == "Local")
            {
                playPanel.SetActive(false);
                isPlaying = false;
            }
        
       
    }
    public void Update()
    {
        if(!findLocalPlayer)
        {
            player = GameObject.Find("Local");
            playPanel = GameObject.Find("LocalStartGame");
        }
            if (isPlaying)
            {
                if (!isLoaded)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        player.GetComponentInChildren<Camera>().enabled = false;
                        player.GetComponent<PlayerManager>().enabled = false;
                        Debug.Log("Loaded new Scene");
                        SceneManager.LoadSceneAsync("Test", LoadSceneMode.Additive);
                        isLoaded = true;
                        playPanel.SetActive(false);
                        testCam.SetActive(true);


                    }
                   
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.L))
                    {
                        player.GetComponentInChildren<Camera>().enabled = true;
                        player.GetComponent<PlayerManager>().enabled = true;
                        SceneManager.UnloadSceneAsync("Test");
                        isLoaded = false;
                        playPanel.SetActive(true);
                        testCam.SetActive(false);
                    }
                }
                

            }
        
      
       
    }
    
}
