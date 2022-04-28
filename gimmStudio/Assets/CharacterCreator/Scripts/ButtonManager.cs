using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private CharacterCreatorSO characterCreatorSO;
    [SerializeField] private Transform headAnchor;
    [SerializeField] private Transform bodyAnchor;
    [SerializeField] private Transform visablePlayer;

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
        nextHairButton.onClick.AddListener(() => { characterCreatorSO.HairModel_GetNext(headAnchor, visablePlayer); });
        previousHairButton.onClick.AddListener(() => { characterCreatorSO.HairModel_GetPrevious(headAnchor, visablePlayer); });
        nextTopButton.onClick.AddListener(() => { characterCreatorSO.TopModel_GetNext(headAnchor, visablePlayer); });
        previousTopButton.onClick.AddListener(() => { characterCreatorSO.TopModel_GetPrevious(headAnchor, visablePlayer); });
        nextBottomButton.onClick.AddListener(() => { characterCreatorSO.BottomModel_GetNext(headAnchor, visablePlayer); });
        previousBottomButton.onClick.AddListener(() => { characterCreatorSO.BottomModel_GetPrevious(headAnchor, visablePlayer); });
        nextHatButton.onClick.AddListener(() => { characterCreatorSO.HatModel_GetNext(headAnchor, visablePlayer); });
        previousHatButton.onClick.AddListener(() => { characterCreatorSO.HatModel_GetPrevious(headAnchor, visablePlayer); });
        nextBaseButton.onClick.AddListener(() => { characterCreatorSO.BaseModel_GetNext(bodyAnchor, visablePlayer); });
        previousBaseButton.onClick.AddListener(() => { characterCreatorSO.BaseModel_GetPrevious(bodyAnchor, visablePlayer); });
    }
}