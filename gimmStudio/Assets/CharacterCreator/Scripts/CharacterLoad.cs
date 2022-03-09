using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoad : MonoBehaviourPunCallbacks
{
    [SerializeField] private CharacterCreatorSO characterData;
    [SerializeField] private CharacterCreatorSO tempCharData;

    private object[] datas;
    void Start()
    {
        if(photonView.IsMine)
        {
            characterData.LoadCharacter(transform);
            Transform[] children = GetComponentsInChildren<Transform>();

            foreach(Transform child in children)
            {
                child.gameObject.layer = 12;
            }
        }
        else
        {
            GetInstantiationData();
            tempCharData.LoadCharacter(transform);
        }
        
    }

    public void GetInstantiationData()
    {
        Debug.Log("OnPhotonInstantiate");
        PhotonView pv = transform.parent.GetComponent<PhotonView>();
        datas = pv.InstantiationData;

        tempCharData._hair = (bool)datas[0];
        tempCharData._hairIndex = (int)datas[1];
        Color color = new Color((float)datas[2], (float)datas[3], (float)datas[4]);
        tempCharData._hairColor = color;

        tempCharData._top = (bool)datas[5];
        tempCharData._topIndex = (int)datas[6];
        color = new Color((float)datas[7], (float)datas[8], (float)datas[9]);
        tempCharData._topColor = color;

        tempCharData._bottom = (bool)datas[10];
        tempCharData._bottomIndex = (int)datas[11];
        color = new Color((float)datas[12], (float)datas[13], (float)datas[14]);
        tempCharData._bottomColor = color;

        tempCharData._hat = (bool)datas[15];
        tempCharData._hatIndex = (int)datas[16];
        color = new Color((float)datas[17], (float)datas[18], (float)datas[19]);
        tempCharData._hatColor = color;

        tempCharData._wings = (bool)datas[20];
        tempCharData._wingsIndex = (int)datas[21];
        color = new Color((float)datas[22], (float)datas[23], (float)datas[24]);
        tempCharData._wingsColor = color;
    }
}
