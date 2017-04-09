using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoToGallery : MonoBehaviour {

	// Use this for initialization
	public GameObject deaScene, actScene;

    //Reference to the video that is playing
    public MediaPlayerCtrl videoScript;

    // this is necesary to be able to seek the video position
    bool pointerEnter = false;

    //variables that show the video time
    private float duration, videoTime;

    public GameObject black;
    public bool blackActive;

    void Start () {
        blackActive = false;
	}
	
	// Update is called once per frame
	void Update () {


    }

	public void back()

	{


        //deaScene.GetComponent<ShowAndHideManager>().ResetElapsed();
        //GetComponent<AudioSource>().Play();
        deaScene.SetActive(false);

        actScene.SetActive(true);
        /*
        //fade out
        CameraFade.StartAlphaFade(Color.black, false, 2f, 0f, () => {
           Debug.Log("deactivate Scene");
           deaScene.SetActive(false);
       });

        //fade in

        CameraFade.StartAlphaFade(Color.black, true, 2f, 0f, () => {
            Debug.Log("activate Scene");
            actScene.SetActive(true);
        });
        */
	}

    public void blackBlock()
    {
        if (!blackActive)
        {
            Debug.Log("ACTIVATE BLACK BOX");
            black.SetActive(true);
            blackActive = true;
        } else
        {
            Debug.Log("DE-ACTIVATE BLACK BOX");
            black.SetActive(false);
            blackActive = false;
        }

    }
}
