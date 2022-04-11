using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private CharacterCreatorSO characterCreatorSO;
    [SerializeField] private Transform headAnchor;
    
    [SerializeField] private UnityEngine.UI.Button nextHairButton;
    [SerializeField] private UnityEngine.UI.Button previousHairButton;
    [SerializeField] private UnityEngine.UI.Button nextTopButton;
    [SerializeField] private UnityEngine.UI.Button previousTopButton;
    [SerializeField] private UnityEngine.UI.Button nextBottomButton;
    [SerializeField] private UnityEngine.UI.Button previousBottomButton;
    [SerializeField] private UnityEngine.UI.Button nextHatButton;
    [SerializeField] private UnityEngine.UI.Button previousHatButton;
    //[SerializeField] private UnityEngine.UI.Button nextMaskButton;
    //[SerializeField] private UnityEngine.UI.Button previousMaskButton;
    [SerializeField] private UnityEngine.UI.Button nextWingsButton;
    [SerializeField] private UnityEngine.UI.Button previousWingsButton;
    //[SerializeField] private UnityEngine.UI.Button nextHandsButton;
    //[SerializeField] private UnityEngine.UI.Button previousHandsButton;

    private void Start()
    {
        //characterCreatorSO.HairModel_GetNext(headAnchor); 
        nextHairButton.onClick.AddListener(() => { characterCreatorSO.HairModel_GetNext(headAnchor); });
        previousHairButton.onClick.AddListener(() => { characterCreatorSO.HairModel_GetPrevious(headAnchor); });
        nextTopButton.onClick.AddListener(() => { characterCreatorSO.TopModel_GetNext(headAnchor); });
        previousTopButton.onClick.AddListener(() => { characterCreatorSO.TopModel_GetPrevious(headAnchor); });
        nextBottomButton.onClick.AddListener(() => { characterCreatorSO.BottomModel_GetNext(headAnchor); });
        previousBottomButton.onClick.AddListener(() => { characterCreatorSO.BottomModel_GetPrevious(headAnchor); });
        nextHatButton.onClick.AddListener(() => { characterCreatorSO.HatModel_GetNext(headAnchor); });
        previousHatButton.onClick.AddListener(() => { characterCreatorSO.HatModel_GetPrevious(headAnchor); });
        //nextMaskButton.onClick.AddListener(() => { characterCreatorSO.MaskModel_GetNext(headAnchor); });
        //previousMaskButton.onClick.AddListener(() => { characterCreatorSO.MaskModel_GetPrevious(headAnchor); });
        nextWingsButton.onClick.AddListener(() => { characterCreatorSO.WingsModel_GetNext(headAnchor); });
        previousWingsButton.onClick.AddListener(() => { characterCreatorSO.WingsModel_GetPrevious(headAnchor); });
        //nextHandsButton.onClick.AddListener(() => { characterCreatorSO.HandsModel_GetNext(headAnchor); });
        //previousHandsButton.onClick.AddListener(() => { characterCreatorSO.HandsModel_GetPrevious(headAnchor); });
    }
}