using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private CharacterCreatorSO characterCreatorSO;
    [SerializeField] private Transform headAnchor;
    [SerializeField] private Transform bodyAnchor;

    [SerializeField] private UnityEngine.UI.Button nextHairButton;
    [SerializeField] private UnityEngine.UI.Button previousHairButton;
    [SerializeField] private UnityEngine.UI.Button nextTopButton;
    [SerializeField] private UnityEngine.UI.Button previousTopButton;
    [SerializeField] private UnityEngine.UI.Button nextBottomButton;
    [SerializeField] private UnityEngine.UI.Button previousBottomButton;
    [SerializeField] private UnityEngine.UI.Button nextHatButton;
    [SerializeField] private UnityEngine.UI.Button previousHatButton;
    [SerializeField] private UnityEngine.UI.Button nextBaseButton;
    [SerializeField] private UnityEngine.UI.Button previousBaseButton;

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
        nextBaseButton.onClick.AddListener(() => { characterCreatorSO.BaseModel_GetNext(bodyAnchor); });
        previousBaseButton.onClick.AddListener(() => { characterCreatorSO.BaseModel_GetPrevious(bodyAnchor); });
    }
}