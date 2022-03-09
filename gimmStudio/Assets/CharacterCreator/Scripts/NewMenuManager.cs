using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMenuManager : MonoBehaviour
{
    public Image loadingTxt;
    public GameObject options;
    public Image colorwheelBox;
    //public Animation anim_CharacterPreview;

    Vector2 cwClosedPos;
    Vector2 cwOpenPos;
    Animator animCW;
    //bool cwOpen = false;

    private void Awake()
    {
        options.SetActive(false);
        animCW = colorwheelBox.GetComponent<Animator>();

    }

    private void Start()
    {
        StartCoroutine(EnableCharacterOptions());
    }

    public void OpenColorWheel()
    {
        //play color wheel open animation every time someone clicks on a color button
        animCW.Play("Base Layer.OpenWheel", -1, 0f);
        //cwOpen = true;
    }

    public void CloseColorWheel()
    {
        animCW.Play("Base Layer.CloseWheel", -1, 0f);
    }

    IEnumerator EnableCharacterOptions()
    {
        yield return new WaitForSeconds(3);

        loadingTxt.enabled = false;
        options.SetActive(true);

        //Animator characterPanel = characterPreviewBox.GetComponent<Animator>();
        //characterPanel.SetBool("timeToPlay", true);

    }

}
