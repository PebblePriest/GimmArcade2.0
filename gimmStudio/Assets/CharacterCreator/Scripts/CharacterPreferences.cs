using System;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class CharacterPreferences
{
    public int hairModel;
    public float hairR;
    public float hairG;
    public float hairB;

    public int eyeModel;
    public float eyeR;
    public float eyeG;
    public float eyeB;

    public int topModel;
    public float topR;
    public float topG;
    public float topB;

    public int bottomModel;
    public float bottomR;
    public float bottomG;
    public float bottomB;

    public int hatModel;
    public float hatR;
    public float hatG;
    public float hatB;

    public int maskModel;
    public float maskR;
    public float maskG;
    public float maskB;

    public int wingsModel;
    public float wingsR;
    public float wingsG;
    public float wingsB;

    public int handsModel;
    public float handsR;
    public float handsG;
    public float handsB;

    public Color HairColor()
    {
        return new Color(hairR, hairG, hairB, 1);
    }

    public Color EyeColor()
    {
        return new Color(eyeR, eyeG, eyeB, 1);
    }

    public Color TopColor()
    {
        return new Color(topR, topG, topB, 1);
    }

    public Color BottomColor()
    {
        return new Color(bottomR, bottomG, bottomB, 1);
    }

    public Color HatColor()
    {
        return new Color(hatR, hatG, hatB, 1);
    }

    public Color MaskColor()
    {
        return new Color(maskR, maskG, maskB, 1);
    }

    public Color WingsColor()
    {
        return new Color(wingsR, wingsG, wingsB, 1);
    }

    public Color HandsColor()
    {
        return new Color(handsR, handsG, handsB, 1);
    }

    public CharacterPreferences(
        int hairM, Color hairC,
        int eyeM, Color eyeC,
        int topM, Color topC,
        int bottomM, Color bottomC,
        int hatM, Color hatC,
        int maskM, Color maskC,
        int wingsM, Color wingsC,
        int handsM, Color handsC
    )
    {
        hairModel = hairM;
        hairR = hairC.r;
        hairG = hairC.g;
        hairB = hairC.b;

        eyeModel = eyeM;
        eyeR = eyeC.r;
        eyeG = eyeC.g;
        eyeB = eyeC.b;

        topModel = topM;
        topR = topC.r;
        topG = topC.g;
        topB = topC.b;

        bottomModel = bottomM;
        bottomR = bottomC.r;
        bottomG = bottomC.g;
        bottomB = bottomC.b;

        hatModel = hatM;
        hatR = hatC.r;
        hatG = hatC.g;
        hatB = hatC.b;

        maskModel = maskM;
        maskR = maskC.r;
        maskG = maskC.g;
        maskB = maskC.b;

        wingsModel = wingsM;
        wingsR = wingsC.r;
        wingsG = wingsC.g;
        wingsB = wingsC.b;

        handsModel = handsM;
        handsR = handsC.r;
        handsG = handsC.g;
        handsB = handsC.b;
    }
}
