using UnityEngine;
using System.Collections;

public class ShowFPS : MonoBehaviour
{

    public UILabel uilabel;

    public int cnt_fps;
    public float cnt_time;

    // Use this for initialization
    void Start()
    {

        cnt_fps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cnt_fps++;
        cnt_time += Time.deltaTime;
        if (cnt_time >= 1.0f)
        {

            uilabel.text = "FPS : " + (1.0f / Time.deltaTime).ToString() + " " + cnt_fps;
            cnt_fps = 0;
            cnt_time = 0.0f;
        }
    }
}
