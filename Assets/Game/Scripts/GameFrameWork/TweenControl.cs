using UnityEngine;
using System.Collections;

public class TweenControl : MonoBehaviour {


    public UIPlayTween uiplaytween;

    public void ChangeDirection()
    {

        if (uiplaytween.playDirection == AnimationOrTween.Direction.Forward)
            uiplaytween.playDirection = AnimationOrTween.Direction.Reverse;
        else
            uiplaytween.playDirection = AnimationOrTween.Direction.Forward;
    }
}
