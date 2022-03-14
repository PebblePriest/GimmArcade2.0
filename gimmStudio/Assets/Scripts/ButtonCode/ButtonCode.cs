using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCode : MonoBehaviour
{
    public GameObject mainUser;
    public AvatarChanges avatar;
    bool userFound = false;
    List<GameObject> players = new List<GameObject>();
    public void Update()
    {
        if (!userFound)
        {
            players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
            for (int i = 0; i < players.Count; i++)
            {
                mainUser = players[i];
                break;
            }
            userFound = true;
        }
       
        if (mainUser)
        {
            avatar = mainUser.GetComponent<AvatarChanges>();
        }
        else
        {
            Debug.Log("Can't find the user");
        }

    }
    public void ControlsOn()
    {
        avatar.KeyControlsOn();
    }
    public void ControlsOff()
    {
        avatar.KeyControlsOff();
    }
    public void AvatarOn()
    {
        avatar.AvatarMenu();
    }
    public void AvatarOff()
    {
        avatar.StartGame();
    }
}
