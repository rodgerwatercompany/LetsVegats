using UnityEngine;
using System.Collections;

public class GF_Window : MonoBehaviour {

    public UILabel label_context;
    public UIWidget uiwidth;

    public void SetContext(string str)
    {
        label_context.text = str;
    }

    public void DestroyWindow()
    {
        Destroy(gameObject);
    }

}
