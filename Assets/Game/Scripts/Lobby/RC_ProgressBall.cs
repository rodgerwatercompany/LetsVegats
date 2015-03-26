using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class RC_ProgressBall : MonoBehaviour {

    public UISprite sprite_front;
    public UILabel label_value;

    [Range(0f, 1f)]
    public float value;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        sprite_front.fillAmount = this.value;
        string tempStr = Regex.Replace((this.value * 100).ToString(), @"(\d+)(\.\d+)?", "$1");
        this.label_value.text = tempStr;
	}


}
