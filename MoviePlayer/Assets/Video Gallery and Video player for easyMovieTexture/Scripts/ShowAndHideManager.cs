using UnityEngine;
using System.Collections;

public class ShowAndHideManager : MonoBehaviour {

	// Use this for initialization
	// set the time to make the canvas dissapear
	private float hideTime=50;
	//this is the canvas that will be hidded
	public Canvas hidShowCanvas;
	public float elapsed;
    public bool hidePlayMenu;

	void Start () {
        
        hidShowCanvas.enabled = false;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		if (Input.GetMouseButtonDown(0)) {
			elapsed = 0;
		} 

		elapsed += Time.fixedDeltaTime;

		if (elapsed > hideTime) {
			hidShowCanvas.enabled = false;
		} else 
		{
			hidShowCanvas.enabled=true;
		}
	}

    public void ResetElapsed()
    {
        elapsed = 0.0f;

    }
    public void maxOutElapse()
    {
        elapsed = hideTime + elapsed + 1.0f;
    }
}

