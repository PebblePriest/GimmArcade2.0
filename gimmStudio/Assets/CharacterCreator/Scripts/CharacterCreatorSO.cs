using System;
using UnityEditor;
using UnityEngine;

public class CharacterCreatorSO : ScriptableObject
{
    public enum ModelDetail
    {
        HAIR,
        EYES,
        TOP,
        BOTTOM,
        HAT,
        MASK,
        WINGS,
        HANDS
    }

    /*public GameObject ears;
    public GameObject eyebrows;
    public GameObject eyes;
    public GameObject handL;
    public GameObject handR;
    public GameObject head;
    public GameObject mask;
    public GameObject nose;
    public GameObject torso;*/

    // ColorID will be a different constant value on every local machine
    // so this value must be set and stored locally on each machine
    private static readonly int ColorID = Shader.PropertyToID("_BaseColor");

    #if UNITY_EDITOR
    [MenuItem("Assets/Create/CharacterCreatorSO")]
    public static void CreateAsset ()
    {
        ScriptableObjectUtility.CreateAsset<CharacterCreatorSO> ();
    }
    #endif
    
    #region Hair Properties
    
    [SerializeField] private GameObject[] hairModels;
    
    public Color _hairColor;
    private GameObject _activeHair;
    public int _hairIndex = 0;
    public bool _hair = true;
    public float hairYOffset = 60f;

    #endregion

    #region Top Properties

    [SerializeField] private GameObject[] topModels;

    public Color _topColor;
    private GameObject _activeTop;
    public int _topIndex = 0;
    public bool _top = true;

    #endregion
    
    #region Bottom Properties

    [SerializeField] private GameObject[] bottomModels;

    public Color _bottomColor;
    private GameObject _activeBottom;
    public int _bottomIndex = 0;
    public bool _bottom = true;

    #endregion

    #region Hat Properties

    [SerializeField] private GameObject[] hatModels;

    public Color _hatColor;
    private GameObject _activeHat;
    public int _hatIndex = 0;
    public bool _hat = true;

    #endregion

    #region Mask Properties

    [SerializeField] private GameObject[] maskModels;

    public Color _maskColor;
    private GameObject _activeMask;
    public int _maskIndex = 0;
    public bool _mask = true;

    #endregion

    #region Wings Properties

    [SerializeField] private GameObject[] wingsModels;

    public Color _wingsColor;
    private GameObject _activeWings;
    public int _wingsIndex = 0;
    public bool _wings = true;

    #endregion

    #region Hands Properties

    [SerializeField] private GameObject[] handsModels;

    public Color _handsColor;
    private GameObject _activeHands;
    public int _handsIndex = 0;
    public bool _hands = true;

    #endregion

    #region EyeColor Properties

    [SerializeField] private UnityEngine.UI.Image[] eyeTextures;

    public Color _eyeColor;
    private UnityEngine.UI.Image _activeEyes;
    public int _eyesIndex;
    public bool _eyes = true;

    #endregion
    
    #region Hair Methods

    public void HairModel_GetNext(Transform anchor)
    {
        if (_hairIndex < hairModels.Length - 1) _hairIndex++;
        else _hairIndex = 0;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAIR,_hair, _hairIndex,anchor);
        
    }

    public void HairModel_GetPrevious(Transform anchor)
    {
        if (_hairIndex > 0) _hairIndex--;
        else _hairIndex = hairModels.Length - 1;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAIR,_hair, _hairIndex,anchor);
    }

    #endregion

    #region Top Methods

    public void TopModel_GetNext(Transform anchor)
    { 
        if (_topIndex < topModels.Length - 1) _topIndex++;
        else _topIndex = 0;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.TOP,_top, _topIndex,anchor);
    }

    public void TopModel_GetPrevious(Transform anchor)
    {
        if (_topIndex > 0) _topIndex--;
        else _topIndex = topModels.Length - 1;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.TOP,_top, _topIndex,anchor);
    }
    
    #endregion
    
    #region Bottom Methods

    public void BottomModel_GetNext(Transform anchor)
    { 
        if (_bottomIndex < bottomModels.Length - 1) _bottomIndex++;
        else _bottomIndex = 0;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BOTTOM,_bottom, _bottomIndex,anchor);
    }

    public void BottomModel_GetPrevious(Transform anchor)
    {
        if (_bottomIndex > 0) _bottomIndex--;
        else _bottomIndex = bottomModels.Length - 1;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BOTTOM,_bottom, _bottomIndex,anchor);
    }

    #endregion

    #region Hat Methods

    public void HatModel_GetNext(Transform anchor)
    { 
        if (_hatIndex < hatModels.Length - 1) _hatIndex++;
        else _hatIndex = 0;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAT,_hat, _hatIndex,anchor);
    }

    public void HatModel_GetPrevious(Transform anchor)
    {
        if (_hatIndex > 0) _hatIndex--;
        else _hatIndex = hatModels.Length - 1;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAT,_hat, _hatIndex,anchor);
    }

    #endregion
    
    #region Wings Methods

    public void WingsModel_GetNext(Transform anchor)
    { 
        if (_wingsIndex < wingsModels.Length - 1) _wingsIndex++;
        else _wingsIndex = 0;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.WINGS,_wings, _wingsIndex,anchor);
    }

    public void WingsModel_GetPrevious(Transform anchor)
    {
        if (_wingsIndex > 0) _wingsIndex--;
        else _wingsIndex = wingsModels.Length - 1;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.WINGS,_wings, _wingsIndex,anchor);
    }

    #endregion

    #region EyeColor Methods

    public void EyeTexture_GetNext()
    { 
        if (_eyesIndex < eyeTextures.Length - 1) _eyesIndex++;
        else _eyesIndex = 0;
      //  ApplyColor(ColorDetail.EYE_COLOR, _eyesIndex, selectedColor);
    }

    public void EyeTexture_GetPrevious()
    {
        if (_eyesIndex > 0) _eyesIndex--;
        else _eyesIndex = eyeTextures.Length - 1;
      //  ApplyColor(ColorDetail.EYE_COLOR, _eyesIndex, selectedColor);
    }

    #endregion

    //Used to load character in the scene
    public void LoadCharacter(Transform anchor, bool isCreator = false)
    {
        Debug.Log("LoadCharacter");
        // Sam commented this out
        //if (isCreator) LoadDefaultData();

        Vector3 pos = anchor.position;
        Quaternion rot = anchor.rotation;
        /* load default character meshes
         * Torso offset = 0,0,0
         * Head offset = 0,.8,0
         * LHand offset = -.4,.2,.3
         * RHand offset = .4,.2,.3
         */
        //These values were doubled to fix match up with the new character size
        /*
         * Instantiate(ears, pos + new Vector3(0, 1.6f,0), rot, anchor);
        Instantiate(eyebrows, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(eyes, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(head, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(mask, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(nose, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(torso, pos, rot, anchor);
        */
        //Instantiate(handL, pos + new Vector3(-.4f, .2f, .3f), rot, anchor);
        //Instantiate(handR, pos + new Vector3(.4f, .2f, .3f), rot, anchor);

        //load custom meshes and colors
        ApplyModifier(CharacterCreatorSO.ModelDetail.HAIR,_hair,_hairIndex,anchor);
        ApplyModifier(CharacterCreatorSO.ModelDetail.TOP,_top,_topIndex,anchor);
        ApplyModifier(CharacterCreatorSO.ModelDetail.BOTTOM,_bottom,_bottomIndex,anchor);
        ApplyModifier(CharacterCreatorSO.ModelDetail.HAT,_hat,_hatIndex,anchor);
        //ApplyModifier(CharacterCreatorSO.ModelDetail.MASK,_mask,_maskIndex,anchor);
        ApplyModifier(CharacterCreatorSO.ModelDetail.WINGS,_wings,_wingsIndex,anchor);
        //ApplyModifier(CharacterCreatorSO.ModelDetail.HANDS,_hands,_handsIndex,anchor);
        
        //TODO: Create special method for eyes
    }

    private void LoadDefaultData()
    {
        //Set default colors
        _hairColor = Color.white;
        _maskColor = Color.white;
        _topColor = Color.white;
        _bottomColor = Color.white;
        _eyeColor = Color.white;
        _wingsColor = Color.white;
        _handsColor = Color.white;
        _hatColor = Color.white;

        //Set the default meshes
        _hairIndex = 0;
        _maskIndex = 0;
        _topIndex = 0;
        _bottomIndex = 0;
        _eyesIndex = 0;
        _wingsIndex = 0;
        _handsIndex = 0;
        _hatIndex = 0;

        //Turn off all extra meshes
        _hair = true;
        _mask = true;
        _top = true;
        _bottom = true;
        _eyes = true;
        _wings = true;
        _hands = true;
        _hat = true;
    }
    
    public void ApplyModifier(ModelDetail detail,bool load, int id,Transform anchor)
    {
        Debug.Log("ApplyModifierCharacter");
        Vector3 pos = anchor.position;
        Quaternion rot = anchor.rotation;
        switch (detail)
        {
            case ModelDetail.HAIR:
                if (_activeHair || !load) Destroy(_activeHair);
                if (load)
                {
                    _activeHair = Instantiate(hairModels[id], pos + new Vector3(0, hairYOffset, 0), rot, anchor);
                    
                    ApplyColor(0, _hairColor);
                }
                break;
            case ModelDetail.TOP:
                if (_activeTop || !load) Destroy(_activeTop);
                if (load)
                {
                    _activeTop = Instantiate(topModels[id], pos, rot, anchor);
                    ApplyColor(2, _topColor);
                }
                break;
            case ModelDetail.BOTTOM:
                if (_activeBottom || !load) Destroy(_activeBottom);
                if (load)
                {
                    _activeBottom = Instantiate(bottomModels[id], pos, rot, anchor);
                    ApplyColor(3, _bottomColor);
                }
                break;
            case ModelDetail.HAT:
                if (_activeHat || !load) Destroy(_activeHat);
                if (load)
                {
                    _activeHat = Instantiate(hatModels[id], pos + new Vector3(0, hairYOffset, 0), rot, anchor);
                    ApplyColor(4, _hatColor);
                }
                break;
            case ModelDetail.MASK:
                if (_activeMask || !load) Destroy(_activeMask);
                if (load)
                {
                    _activeMask = Instantiate(maskModels[id], pos + new Vector3(0, hairYOffset, 0), rot, anchor);
                    ApplyColor(5, _maskColor);
                }
                break;
            case ModelDetail.WINGS:
                if (_activeWings || !load) Destroy(_activeWings);
                if (load)
                {
                    _activeWings = Instantiate(wingsModels[id], pos, rot, anchor);
                    ApplyColor(6, _wingsColor);
                }
                break;
            case ModelDetail.HANDS:
                if (_activeHands || !load) Destroy(_activeHands);
                if (load)
                {
                    _activeHands = Instantiate(handsModels[id], pos, rot, anchor);
                    ApplyColor(7, _handsColor);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(detail), detail, null);
        }
    }

    public void LoadCharacterOnCreator(Transform anchor, bool isCreator = false)
    {
        //Debug.Log("LoadCharacter");
        // Sam did is
        //if (isCreator) LoadDefaultData();
        LoadDefaultData();

        Vector3 pos = anchor.position;
        Quaternion rot = anchor.rotation;
        /* load default character meshes
         * Torso offset = 0,0,0
         * Head offset = 0,.8,0
         * LHand offset = -.4,.2,.3
         * RHand offset = .4,.2,.3
         */
        //Doubled to match up with the scaled up character for the scenes
        /*Instantiate(ears, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(eyebrows, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(eyes, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(head, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(mask, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(nose, pos + new Vector3(0, 1.6f, 0), rot, anchor);
        Instantiate(torso, pos, rot, anchor);*/
        //Instantiate(handL, pos + new Vector3(-.4f, .2f, .3f), rot, anchor);
        //Instantiate(handR, pos + new Vector3(.4f, .2f, .3f), rot, anchor);

        //load custom meshes and colors
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAIR,_hair, _hairIndex, anchor);
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.TOP,_top, _topIndex, anchor);
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BOTTOM,_bottom, _bottomIndex, anchor);
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAT,_hat, _hatIndex, anchor);
        //ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.MASK,_mask,_maskIndex,anchor);
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.WINGS,_wings, _wingsIndex, anchor);
        //ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HANDS,_hands,_handsIndex,anchor);

        //TODO: Create special method for eyes
    }

    public void ApplyModifierOnCreator(ModelDetail detail, bool load, int id, Transform anchor)
    {
        float hairOffset = 85f;
        //Debug.Log("ApplyModifierCharacter on Creator");
        Vector3 pos = anchor.position;
        Quaternion rot = anchor.rotation;
        switch (detail)
        {
            case ModelDetail.HAIR:
                if (_activeHair || !load) Destroy(_activeHair);
                if (load)
                {
                    _activeHair = Instantiate(hairModels[id], pos + new Vector3(0, hairOffset, 0), rot, anchor);
                    ApplyColor(0, _hairColor);
                }
                break;
            case ModelDetail.TOP:
                if (_activeTop || !load) Destroy(_activeTop);
                if (load)
                {
                    _activeTop = Instantiate(topModels[id], pos, rot, anchor);
                    ApplyColor(2, _topColor);
                }
                break;
            case ModelDetail.BOTTOM:
                if (_activeBottom || !load) Destroy(_activeBottom);
                if (load)
                {
                    _activeBottom = Instantiate(bottomModels[id], pos, rot, anchor);
                    ApplyColor(3, _bottomColor);
                }
                break;
            case ModelDetail.HAT:
                if (_activeHat || !load) Destroy(_activeHat);
                if (load)
                {
                    _activeHat = Instantiate(hatModels[id], pos + new Vector3(0, hairOffset, 0), rot, anchor);
                    ApplyColor(4, _hatColor);
                }
                break;
            case ModelDetail.MASK:
                if (_activeMask || !load) Destroy(_activeMask);
                if (load)
                {
                    _activeMask = Instantiate(maskModels[id], pos + new Vector3(0, hairOffset, 0), rot, anchor);
                    ApplyColor(5, _maskColor);
                }
                break;
            case ModelDetail.WINGS:
                if (_activeWings || !load) Destroy(_activeWings);
                if (load)
                {
                    _activeWings = Instantiate(wingsModels[id], pos, rot, anchor);
                    ApplyColor(6, _wingsColor);
                }
                break;
            case ModelDetail.HANDS:
                if (_activeHands || !load) Destroy(_activeHands);
                if (load)
                {
                    _activeHands = Instantiate(handsModels[id], pos, rot, anchor);
                    ApplyColor(7, _handsColor);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(detail), detail, null);
        }
    }

    public void ApplyColor(int id, Color color)
    {
        switch (id)
        {
            case 0:
                _hairColor = color;
                if (_activeHair.transform.childCount == 0)
                {
                    _activeHair.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_hairColor);
                }
                else
                {
                    for (int i = 0; i < _activeHair.transform.childCount; i++)
                    {
                        _activeHair.transform.GetChild(i).GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_hairColor);
                    }
                }
                break;
            case 1:
                _eyeColor = color;
                if (_activeEyes.transform.childCount == 0)
                {
                    _activeEyes.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_eyeColor);
                }
                else
                {
                    for (int i = 0; i < _activeHair.transform.childCount; i++)
                    {
                        _activeEyes.transform.GetChild(i).GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_eyeColor);
                    }
                }
                break;
            case 2:
                _topColor = color;
                if (_activeTop.transform.childCount == 0)
                {
                    _activeTop.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_topColor);
                }
                else
                {
                    for (int i = 0; i < _activeTop.transform.childCount; i++)
                    {
                        _activeTop.transform.GetChild(i).GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_topColor);
                    }
                }
                break;
            case 3:
                _bottomColor = color;
                if (_activeBottom.transform.childCount == 0)
                {
                    _activeBottom.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_bottomColor);
                }
                else
                {
                    for (int i = 0; i < _activeBottom.transform.childCount; i++)
                    {
                        _activeBottom.transform.GetChild(i).GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_bottomColor);
                    }
                }
                break;
            case 4:
                _hatColor = color;
                if (_activeHat.transform.childCount == 0)
                {
                    _activeHat.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_hatColor);
                }
                else
                {
                    for (int i = 0; i < _activeHat.transform.childCount; i++)
                    {
                        _activeHat.transform.GetChild(i).GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_hatColor);
                    }
                }
                break;
            case 5:
                _maskColor = color;
                if (_activeMask.transform.childCount == 0)
                {
                    _activeMask.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_maskColor);
                }
                else
                {
                    for (int i = 0; i < _activeMask.transform.childCount; i++)
                    {
                        _activeMask.transform.GetChild(i).GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_maskColor);
                    }
                }
                break;
            case 6:
                _wingsColor = color;
                if (_activeWings.transform.childCount == 0)
                {
                    _activeWings.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_wingsColor);
                }
                else
                {
                    for (int i = 0; i < _activeWings.transform.childCount; i++)
                    {
                        _activeWings.transform.GetChild(i).GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_wingsColor);
                    }
                } 
                break;
            case 7:
                _handsColor = color;
                if (_activeWings.transform.childCount == 0)
                {
                    _activeHands.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_handsColor);
                }
                else
                {
                    for (int i = 0; i < _activeHands.transform.childCount; i++)
                    {
                        _activeHands.transform.GetChild(i).GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID,_handsColor);
                    }
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(id), id, null);
        }
    }

    public Color GetLastColor(int id)
    {
        switch (id)
        {
            case 0:
                return _hairColor;
                break;
            case 1:
                return _eyeColor;
                break;
            case 2:
                return _topColor;
                break;
            case 3:
                return _bottomColor;
                break;
            case 4:
                return _hatColor;
                break;
            case 5:
                return _maskColor;
                break;
            case 6:
                return _wingsColor;
                break;
            case 7:
                return _handsColor;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(id), id, null);
        }
    }
}