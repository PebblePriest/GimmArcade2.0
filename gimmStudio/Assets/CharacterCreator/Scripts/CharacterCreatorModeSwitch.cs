using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreatorModeSwitch : MonoBehaviour
{
    private bool VREnabled;
    [SerializeField] private GameObject VRCustomization;
    [SerializeField] private GameObject desktopCustomization;
    private void Start()
    {
        if (PlayerPrefs.GetInt("vrEnabled") == 0)
        {
            VREnabled = false;
            desktopCustomization.SetActive(true);
        }

        else if (PlayerPrefs.GetInt("vrEnabled") == 1)
        {
            VREnabled = true;
            VRCustomization.SetActive(true);
            desktopCustomization.SetActive(false);
        }
    }

    public void LoadUsernameEntry()
    {
        if (VREnabled)
        {
            SceneManager.LoadScene("LauncherVR");
        }
        else
        {
            SceneManager.LoadScene("LauncherDesktop");
        }
    }
}
