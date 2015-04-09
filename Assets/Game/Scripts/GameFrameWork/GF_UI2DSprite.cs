using UnityEngine;
using System;
using System.Collections;

public class GF_UI2DSprite : MonoBehaviour {

    public Sprite[] sprites;

    public UI2DSprite ui2dsprite;
    
    public void ChangeSprite(string idx)
    {
        ui2dsprite.sprite2D = sprites[Convert.ToInt32(idx)];
    }

}
