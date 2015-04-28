using UnityEngine;
using System.Collections;

public class LoadingGameScene : MonoBehaviour
{

    private WWW www_loadingGame;

    public UIProgressBar progressbar;

    private bool sw_loadingGame;

    // Use this for initialization
    void Start () {
        
        www_loadingGame = null;
        progressbar.value = 0.0f;

        sw_loadingGame = false;

        StartCoroutine(LoadingGame());
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (sw_loadingGame)
        {

            if (www_loadingGame != null)
            {

                if (progressbar.value < www_loadingGame.progress)
                {

                    progressbar.value += 0.1f * Time.deltaTime;
                }
            }
            else
            {

                progressbar.value += 0.1f * Time.deltaTime;
            }

            if (progressbar.value >= 1.0f)
            {

                sw_loadingGame = false;

                print(ABManager.assetbundle_Game.name);

                Application.LoadLevel(LoadingGameManager.ab_scenename);
            }
        }
    }

    IEnumerator LoadingGame()
    {
        string patah = Application.persistentDataPath + "/AssetBundles";

        print(patah);

        if (ABManager.assetbundle_Game != null)
            ABManager.assetbundle_Game.Unload(true);

        if (ABCaching.IsVersionCached(LoadingGameManager.ab_URL,LoadingGameManager.ab_Version))
        {

            string path = ABCaching.getPath(LoadingGameManager.ab_URL, LoadingGameManager.ab_Version);

            using (www_loadingGame = new WWW(path))
            {

                sw_loadingGame = true;

                yield return www_loadingGame;

                if (www_loadingGame.error != null)
                {

                    Debug.LogError("LoadingGame had an error : " + www_loadingGame.error);
                }
                else
                {

                    ABManager.assetbundle_Game = www_loadingGame.assetBundle;

                    //www_loadingGame.assetBundle.Unload(false);
                    www_loadingGame = null;
                }
            }
        }
        else
        {
            yield return null;
            Debug.LogError("LoadingGame Error !");
        }
    }

    
}
