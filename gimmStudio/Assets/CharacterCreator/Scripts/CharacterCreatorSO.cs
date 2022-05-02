using System;
using UnityEditor;
using UnityEngine;
using Photon.Pun;
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
        BASE,
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
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<CharacterCreatorSO>();
    }
#endif

    #region Hair Properties

    [SerializeField] private GameObject[] hairModels;

    public Color _hairColor;
    private GameObject _activeHair;
    private GameObject _activeVisableHair;
    public int _hairIndex = 0;
    public bool _hair = true;

    #endregion

    #region Top Properties

    [SerializeField] private GameObject[] topModels;

    public Color _topColor;
    private GameObject _activeTop;
    private GameObject _activeVisableTop;
    public int _topIndex = 0;
    public bool _top = true;

    #endregion

    #region Bottom Properties

    [SerializeField] private GameObject[] bottomModels;

    public Color _bottomColor;
    private GameObject _activeBottom;
    private GameObject _activeVisableBottom;
    public int _bottomIndex = 0;
    public bool _bottom = true;

    #endregion

    #region Hat Properties

    [SerializeField] private GameObject[] hatModels;

    public Color _hatColor;
    private GameObject _activeHat;
    private GameObject _activeVisableHat;
    public int _hatIndex = 0;
    public bool _hat = true;

    #endregion

    #region Mask Properties

    [SerializeField] private GameObject[] maskModels;

    public Color _maskColor;
    private GameObject _activeMask;
    private GameObject _activeVisableMask;
    public int _maskIndex = 0;
    public bool _mask = true;

    #endregion

    #region Base Properties

    [SerializeField] private GameObject[] baseModels;

    public Color _baseColor;
    private GameObject _activeBase;
    private GameObject _activeVisableBase;
    public int _baseIndex = 0;
    public bool _base = true;

    #endregion

    #region Hands Properties

    [SerializeField] private GameObject[] handsModels;

    public Color _handsColor;
    private GameObject _activeHands;
    private GameObject _activeVisableHands;
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
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAIR, _hair, _hairIndex, anchor);

    }

    public void HairModel_GetPrevious(Transform anchor)
    {
        if (_hairIndex > 0) _hairIndex--;
        else _hairIndex = hairModels.Length - 1;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAIR, _hair, _hairIndex, anchor);
    }

    #endregion

    #region Top Methods

    public void TopModel_GetNext(Transform anchor)
    {
        if (_topIndex < topModels.Length - 1) _topIndex++;
        else _topIndex = 0;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.TOP, _top, _topIndex, anchor);
    }

    public void TopModel_GetPrevious(Transform anchor)
    {
        if (_topIndex > 0) _topIndex--;
        else _topIndex = topModels.Length - 1;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.TOP, _top, _topIndex, anchor);
    }

    #endregion

    #region Bottom Methods

    public void BottomModel_GetNext(Transform anchor)
    {
        if (_bottomIndex < bottomModels.Length - 1) _bottomIndex++;
        else _bottomIndex = 0;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BOTTOM, _bottom, _bottomIndex, anchor);
    }

    public void BottomModel_GetPrevious(Transform anchor)
    {
        if (_bottomIndex > 0) _bottomIndex--;
        else _bottomIndex = bottomModels.Length - 1;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BOTTOM, _bottom, _bottomIndex, anchor);
    }

    #endregion

    #region Hat Methods

    public void HatModel_GetNext(Transform anchor)
    {
        if (_hatIndex < hatModels.Length - 1) _hatIndex++;
        else _hatIndex = 0;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAT, _hat, _hatIndex, anchor);
    }

    public void HatModel_GetPrevious(Transform anchor)
    {
        if (_hatIndex > 0) _hatIndex--;
        else _hatIndex = hatModels.Length - 1;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAT, _hat, _hatIndex, anchor);
    }

    #endregion

    #region Base Methods

    public void BaseModel_GetNext(Transform anchor)
    {
        if (_baseIndex < baseModels.Length - 1) _baseIndex++;
        else _baseIndex = 0;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BASE, _base, _baseIndex, anchor);
    }

    public void BaseModel_GetPrevious(Transform anchor)
    {
        if (_baseIndex > 0) _baseIndex--;
        else _baseIndex = baseModels.Length - 1;
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BASE, _base, _baseIndex, anchor);
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

        //load custom meshes and colors
        ApplyModifier(CharacterCreatorSO.ModelDetail.HAIR, _hair, _hairIndex, anchor);
        ApplyModifier(CharacterCreatorSO.ModelDetail.TOP, _top, _topIndex, anchor);
        ApplyModifier(CharacterCreatorSO.ModelDetail.BOTTOM, _bottom, _bottomIndex, anchor);
        ApplyModifier(CharacterCreatorSO.ModelDetail.HAT, _hat, _hatIndex, anchor);
        ApplyModifier(CharacterCreatorSO.ModelDetail.BASE, _base, _baseIndex, anchor);

    }

    private void LoadDefaultData()
    {
        //Set default colors
        _hairColor = Color.white;
        _maskColor = Color.white;
        _topColor = Color.white;
        _bottomColor = Color.white;
        _eyeColor = Color.white;
        _baseColor = Color.white;
        _handsColor = Color.white;
        _hatColor = Color.white;

        //Set the default meshes
        _hairIndex = 0;
        _maskIndex = 0;
        _topIndex = 0;
        _bottomIndex = 0;
        _eyesIndex = 0;
        _baseIndex = 0;
        _handsIndex = 0;
        _hatIndex = 0;

        //Turn off all extra meshes
        _hair = true;
        _mask = true;
        _top = true;
        _bottom = true;
        _eyes = true;
        _base = true;
        _hands = true;
        _hat = true;
    }

    public void ApplyModifier(ModelDetail detail, bool load, int id, Transform anchor)
    {
        Debug.Log("ApplyModifierCharacter");
        Vector3 pos = anchor.position;
        Quaternion rot = anchor.rotation;
        switch (detail)
        {
            case ModelDetail.HAIR:
                if (_activeHair || !load) Destroy(_activeHair);
                if (_activeVisableHair || !load) Destroy(_activeVisableHair);
                if (load)
                {
                    _activeHair = Instantiate(hairModels[id], pos, rot, anchor);
                    //_activeVisableHair = Instantiate(hairModels[id], pos, rot, visableAnchor);

                    ApplyColor(0, _hairColor);
                }
                break;
            case ModelDetail.TOP:
                if (_activeTop || !load) Destroy(_activeTop);
                if (load)
                {
                    _activeTop = Instantiate(topModels[id], pos, rot, anchor);
                    //_activeVisableTop = Instantiate(topModels[id], pos, rot, visableAnchor);

                    ApplyColor(2, _topColor);
                }
                break;
            case ModelDetail.BOTTOM:
                if (_activeBottom || !load) Destroy(_activeBottom);
                if (load)
                {
                    _activeBottom = Instantiate(bottomModels[id], pos, rot, anchor);
                    //_activeVisableBottom = Instantiate(bottomModels[id], pos, rot, visableAnchor);

                    ApplyColor(3, _bottomColor);
                }
                break;
            case ModelDetail.HAT:
                if (_activeHat || !load) Destroy(_activeHat);
                if (load)
                {
                    _activeHat = Instantiate(hatModels[id], pos, rot, anchor);
                    //_activeVisableHat = Instantiate(hatModels[id], pos, rot, visableAnchor);

                    ApplyColor(4, _hatColor);
                }
                break;
            case ModelDetail.MASK:
                if (_activeMask || !load) Destroy(_activeMask);
                if (load)
                {
                    _activeMask = Instantiate(maskModels[id], pos, rot, anchor);
                    //_activeVisableMask = Instantiate(maskModels[id], pos, rot, visableAnchor);

                    ApplyColor(5, _maskColor);
                }
                break;
            case ModelDetail.BASE:
                if (_activeBase || !load) Destroy(_activeBase);
                if (load)
                {
                    _activeBase = Instantiate(baseModels[id], pos, rot, anchor);
                    //_activeVisableBase = Instantiate(baseModels[id], pos, rot, visableAnchor);

                    ApplyColor(6, _baseColor);
                }
                break;
            case ModelDetail.HANDS:
                if (_activeHands || !load) Destroy(_activeHands);
                if (load)
                {
                    _activeHands = Instantiate(handsModels[id], pos, rot, anchor);
                    //_activeVisableHands = Instantiate(handsModels[id], pos, rot, visableAnchor);

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

        //load custom meshes and colors
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAIR, _hair, _hairIndex, anchor);
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.TOP, _top, _topIndex, anchor);
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BOTTOM, _bottom, _bottomIndex, anchor);
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.HAT, _hat, _hatIndex, anchor);
        ApplyModifierOnCreator(CharacterCreatorSO.ModelDetail.BASE, _base, _baseIndex, anchor);

    }

    public void ApplyModifierOnCreator(ModelDetail detail, bool load, int id, Transform anchor)
    {
        //Debug.Log("ApplyModifierCharacter on Creator");
        Vector3 pos = anchor.position;
        Quaternion rot = anchor.rotation;

        Transform visableAnchor = anchor.parent.parent.parent.GetChild(2).GetChild(2).transform;
        //This is janky as hell, but it will work for now and doing it the same way we import the other
        //anchor messes with way too many other things in this file.
        //Debug.Log(visableAnchor);

        Vector3 visPos = visableAnchor.position;
        Quaternion visRot = visableAnchor.rotation;

        switch (detail)
        {
            case ModelDetail.HAIR:
                if (_activeHair || !load) Destroy(_activeHair);
                if (_activeVisableHair || !load) Destroy(_activeVisableHair);
                if (load)
                {
                    _activeHair = Instantiate(hairModels[id], pos, rot, anchor);
                    _activeHair.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

                    Vector3 posWithOffset = new Vector3(visPos.x, visPos.y+2.6f, visPos.z);
                    _activeVisableHair = Instantiate(hairModels[id], posWithOffset, visRot, visableAnchor);

                    ApplyColor(0, _hairColor);
                }
                break;
            case ModelDetail.TOP:
                if (_activeTop || !load) Destroy(_activeTop);
                if (_activeVisableTop || !load) Destroy(_activeVisableTop);
                if (load)
                {
                    Vector3 posWithOffset = new Vector3(pos.x, pos.y-10.0f, pos.z);
                    Debug.Log(posWithOffset);
                    _activeTop = Instantiate(topModels[id], posWithOffset, rot, anchor);
                    _activeTop.transform.localScale = new Vector3(0.87f, 0.87f, 0.87f);

                    Vector3 visPosWithOffset = new Vector3(visPos.y-0.993f, visPos.z);
                    _activeVisableTop = Instantiate(topModels[id], visPosWithOffset, visRot, visableAnchor);

                    ApplyColor(2, _topColor);
                }
                break;
            case ModelDetail.BOTTOM:
                if (_activeBottom || !load) Destroy(_activeBottom);
                if (_activeVisableBottom || !load) Destroy(_activeVisableBottom);
                if (load)
                {
                    _activeBottom = Instantiate(bottomModels[id], pos, rot, anchor);

                    _activeVisableBottom = Instantiate(bottomModels[id], visPos, visRot, visableAnchor);

                    ApplyColor(3, _bottomColor);
                }
                break;
            case ModelDetail.HAT:
                if (_activeHat || !load) Destroy(_activeHat);
                if (_activeVisableHat || !load) Destroy(_activeVisableHat);
                if (load)
                {
                    _activeHat = Instantiate(hatModels[id], pos, rot, anchor);
                    _activeHat.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

                    Vector3 posWithOffset = new Vector3(visPos.x, visPos.y+2.7f ,visPos.z);
                    _activeVisableHat = Instantiate(hatModels[id], posWithOffset, visRot, visableAnchor);
                    //_activeVisableHat.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                    ApplyColor(4, _hatColor);
                }
                break;
            case ModelDetail.MASK:
                if (_activeMask || !load) Destroy(_activeMask);
                if (_activeVisableMask || !load) Destroy(_activeVisableMask);
                if (load)
                {
                    _activeMask = Instantiate(maskModels[id], pos, rot, anchor);

                    _activeVisableMask = Instantiate(maskModels[id], visPos, visRot, visableAnchor);

                    ApplyColor(5, _maskColor);
                }
                break;
            case ModelDetail.BASE:
                if (_activeBase || !load) Destroy(_activeBase);
                if (_activeVisableBase || !load) Destroy(_activeVisableBase);
                if (load)
                {
                    _activeBase = Instantiate(baseModels[id], pos, rot, anchor);
                    _activeBase.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);

                    _activeVisableBase = Instantiate(baseModels[id], visPos, visRot, visableAnchor);
                    _activeVisableBase.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                    ApplyColor(6, _baseColor);
                }
                break;
            case ModelDetail.HANDS:
                if (_activeHands || !load) Destroy(_activeHands);
                if (_activeVisableHands || !load) Destroy(_activeVisableHands);
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
                    _activeHair.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _hairColor);
                }
                else
                {
                    for (int i = 0; i < _activeHair.transform.childCount; i++)
                    {
                        _activeHair.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _hairColor);
                    }
                }

                if (_activeVisableHair.transform.childCount == 0)
                {
                    _activeVisableHair.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _hairColor);
                }
                else
                {
                    for (int i = 0; i < _activeVisableHair.transform.childCount; i++)
                    {
                        _activeVisableHair.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _hairColor);
                    }
                }
                break;
            case 1:
                _eyeColor = color;
                if (_activeEyes.transform.childCount == 0)
                {
                    _activeEyes.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _eyeColor);
                }
                else
                {
                    for (int i = 0; i < _activeHair.transform.childCount; i++)
                    {
                        _activeEyes.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _eyeColor);
                    }
                }
                break;
            case 2:
                _topColor = color;
                if (_activeTop.transform.childCount == 0)
                {
                    _activeTop.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _topColor);
                }
                else
                {
                    for (int i = 0; i < _activeTop.transform.childCount; i++)
                    {
                        _activeTop.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _topColor);
                    }
                }

                if (_activeVisableTop.transform.childCount == 0)
                {
                    _activeVisableTop.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _topColor);
                }
                else
                {
                    for (int i = 0; i < _activeVisableTop.transform.childCount; i++)
                    {
                        _activeVisableTop.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _topColor);
                    }
                }
                break;
            case 3:
                _bottomColor = color;
                if (_activeBottom.transform.childCount == 0)
                {
                    _activeBottom.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _bottomColor);
                }
                else
                {
                    for (int i = 0; i < _activeBottom.transform.childCount; i++)
                    {
                        _activeBottom.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _bottomColor);
                    }
                }

                if (_activeVisableBottom.transform.childCount == 0)
                {
                    _activeVisableBottom.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _bottomColor);
                }
                else
                {
                    for (int i = 0; i < _activeVisableBottom.transform.childCount; i++)
                    {
                        _activeVisableBottom.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _bottomColor);
                    }
                }
                break;
            case 4:
                _hatColor = color;
                if (_activeHat.transform.childCount == 0)
                {
                    _activeHat.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _hatColor);
                }
                else
                {
                    for (int i = 0; i < _activeHat.transform.childCount; i++)
                    {
                        _activeHat.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _hatColor);
                    }
                }

                if (_activeVisableHat.transform.childCount == 0)
                {
                    _activeVisableHat.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _hatColor);
                }
                else
                {
                    for (int i = 0; i < _activeVisableHat.transform.childCount; i++)
                    {
                        _activeVisableHat.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _hatColor);
                    }
                }
                break;
                break;
            case 5:
                _maskColor = color;
                if (_activeMask.transform.childCount == 0)
                {
                    _activeMask.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _maskColor);
                }
                else
                {
                    for (int i = 0; i < _activeMask.transform.childCount; i++)
                    {
                        _activeMask.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _maskColor);
                    }
                }
                break;
            case 6:
                _baseColor = color;
                if (_activeBase.transform.childCount == 0)
                {
                    _activeBase.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _baseColor);
                }
                else
                {
                    for (int i = 0; i < _activeBase.transform.childCount; i++)
                    {
                        _activeBase.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _baseColor);
                    }
                }

                if (_activeVisableBase.transform.childCount == 0)
                {
                    _activeVisableBase.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _baseColor);
                }
                else
                {
                    for (int i = 0; i < _activeVisableBase.transform.childCount; i++)
                    {
                        _activeVisableBase.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _baseColor);
                    }
                }
                break;
            case 7:
                _handsColor = color;
                if (_activeBase.transform.childCount == 0)
                {
                    _activeHands.GetComponent<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _handsColor);
                }
                else
                {
                    for (int i = 0; i < _activeHands.transform.childCount; i++)
                    {
                        _activeHands.transform.GetChild(i).GetComponentInChildren<Renderer>().material.SetColor(CharacterCreatorSO.ColorID, _handsColor);
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
                return _baseColor;
                break;
            case 7:
                return _handsColor;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(id), id, null);
        }
    }
}