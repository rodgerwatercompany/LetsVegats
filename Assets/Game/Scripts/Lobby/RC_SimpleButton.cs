using UnityEngine;

public class RC_SimpleButton : MonoBehaviour {


    public RC_ScrollIcon scrollicon;

    public UIPlayTween uiplaytween;
    public UIButton uibutton;

    // OnPress
    private bool haveDone;   // 防止長按之後，進行短按。
    private bool bpressing;  // 防止短按之後，進行長按。
    private float fpresstime_first;
	
	// Update is called once per frame
	void Update ()
    {

        if (bpressing && !haveDone)
        {
            // 長按
            if (Time.time - fpresstime_first > 1.0f)
            {
                haveDone = true;
                SetState("Disabled");
                scrollicon.OnClick_ShowDeleteWindow();
            }
        }
    }

    public void SetState(string state)
    {
        switch (state)
        {
            case "Normal":
                uibutton.enabled = true;
                uiplaytween.enabled = true;
                haveDone = false;

                uibutton.SetState(UIButtonColor.State.Normal, false);
                break;
            case "Hover":
                uibutton.SetState(UIButtonColor.State.Hover, false);
                break;
            case "Pressed":
                uibutton.SetState(UIButtonColor.State.Pressed, false);
                break;
            case "Disabled":
                uibutton.enabled = false;
                uiplaytween.enabled = false;
                uibutton.SetState(UIButtonColor.State.Disabled, false);
                break;
        }
    }

    public void OnClick()
    {
        // 短按
        if (uibutton.state != UIButtonColor.State.Disabled && uibutton.enabled && !haveDone)
        {
            SetState("Disabled");

            scrollicon.OnClick_StartGame();
        }
    }

    public void OnPress()
    {
        if (bpressing)
        {
            bpressing = false;
        }
        else
        {
            bpressing = true;

            fpresstime_first = Time.time;
        }
    }
}
