using UnityEngine;
using System.Collections;


public class GF_ButtonObject : MonoBehaviour {

    private LuaManager_new luamanager;

    public string[] Name_CallLuaFunciton;

    public bool bClickDisable;

    public UIButton uibutton;

    void Awake()
    {

        luamanager = GameObject.Find("LuaManager").GetComponent<LuaManager_new>();
        if (luamanager == null)
            Debug.LogError("can't found luamanager !");
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetActive(bool sw)
    {

        gameObject.SetActive(sw);

        if (sw)
            SetState("Normal");
    }

    public void SetState(string state)
    {
        switch (state)
        {
            case "Normal":
                uibutton.enabled = true;
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
                uibutton.SetState(UIButtonColor.State.Disabled, false);
                break;
        }
    }

    public void OnClick()
    {

        if (uibutton.state != UIButtonColor.State.Disabled)
        {
            print("OnClick name is " + name);

            foreach (string str in Name_CallLuaFunciton)
                luamanager.CallLuaFuction(str);

            if (bClickDisable)
                SetState("Disabled");
        }
    }
}
