using UnityEngine;
using System.Collections;

public class BingoLineObject : MonoBehaviour
{

    private UISprite uisprite;

    void Awake()
    {
        uisprite = gameObject.GetComponent<UISprite>();
        if (uisprite == null)
            Debug.Log("Null !");
    }

	// Use this for initialization
	void Start () 
    {

        Close();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Open()
    {
        uisprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void Close()
    {
        uisprite.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

}
