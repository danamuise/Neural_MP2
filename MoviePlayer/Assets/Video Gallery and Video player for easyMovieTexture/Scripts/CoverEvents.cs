using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoverEvents : MonoBehaviour {

	// Use this for initialization
	// max rotations where rotY can be
	[Range(-60,60)]
	public float imposedRotation=60;
	// this is the cover number
	public int covNum;
	// this is the image of the cover
	public Image coverIm,coverShadow;
	// this is the cover manager inside the scene
	CoverManager coverManager;
	// public description used to show the time, the place etc...
	public GameObject description;
	// text references;
	public Text titleTX,descTX,timeTX;
	//this is the buton gameObject that can be enabled or disabled when focusing
	public GameObject butonPlay;
    public GameObject black;

	void Start ()
	{
		transform.rotation= Quaternion.Euler(0,0,0);
		coverManager=GameObject.FindGameObjectWithTag("coverManager").GetComponent<CoverManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.rotation= Quaternion.Lerp( transform.rotation,Quaternion.Euler(0,imposedRotation,0),0.1f);
	}

	public void OnCardboardEnter ()
	{
		coverManager.actualCover=covNum;
		coverManager.ResetPositions();		
	}

    public void gotoPlayVideoSceneAuto(int mov)
    {
        Invoke("disableBlack", 3.0F);
        Debug.Log("FADE OUT");
        CameraFade.StartAlphaFade(Color.black, false, 2f, 0f, () =>
        {
            coverManager.goToVideoScene(mov);
        });
    }

    public void gotoPlayVideoScene()
	{
        Invoke("disableBlack", 3.0F);
        //fade out
        CameraFade.StartAlphaFade(Color.black, false, 2f, 0f, () => {
            coverManager.goToVideoScene(covNum);
        });

        //fade in
        //CameraFade.StartAlphaFade(Color.black, true, 2f, 0f, () => {

        //});
        // Make your calls here
        

	}

    public void gotoPlayVideoScene1()
    {
        Invoke("disableBlack", 3.0F);
        //fade out
        CameraFade.StartAlphaFade(Color.black, false, 2f, 0f, () => {
            coverManager.goToVideoScene(1);
        });
        // Make your calls here
        

    }

    public void gotoPlayVideoScene2()
    {
        Invoke("disableBlack", 3.0F);
        //fade out
        CameraFade.StartAlphaFade(Color.black, false, 2f, 0f, () => {
            coverManager.goToVideoScene(2);
        });
        // Make your calls here
        

    }

    public void gotoPlayVideoScene3()
    {
        Invoke("disableBlack", 3.0F);
        //fade out
        CameraFade.StartAlphaFade(Color.black, false, 2f, 0f, () => {
            coverManager.goToVideoScene(3);
        });
        // Make your calls here
        

    }

    public void gotoPlayVideoScene4()
    {
        Invoke("disableBlack", 3.0F);
        //fade out
        CameraFade.StartAlphaFade(Color.black, false, 2f, 0f, () => {
            coverManager.goToVideoScene(4);
        });
        // Make your calls here
        

    }

    public void showDescritpion ()
	{
		description.SetActive(true);
		butonPlay.SetActive(true);
		
	}

	public void hideDescription ()
	{
		description.SetActive (false);
		butonPlay.SetActive(false);

	}


	public void updateDescription (string title, string desc, string tm)
	{
		titleTX.text=title;
		descTX.text=desc;
		timeTX.text=tm;
	}

	public void setSprite (Sprite sprite)
	{
		coverIm.sprite=sprite;
		coverShadow.sprite=sprite;
	}

    void disableBlack()
    {

        black.SetActive(false);
    }

}
