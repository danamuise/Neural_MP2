using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public float idleTime;
	private float currTime;
	public GameObject LoadObject;

	public bool timed;

	// Use this for initialization
	void Start () {
		timed = true;
		//textField.text = "Auto play in " + (int)currTime;
		ResetIdleTime();

	}

	// Update is called once per frame
	void Update () {
		if (timed)
		{
			currTime -= Time.deltaTime;

			if (currTime > 0)
			{
				//textField.text = "Auto play in " + (int)currTime;
				Debug.Log("Auto play in: "+(int)currTime);
			}
			else
			{
				if (currTime < 0)
				{
					Debug.Log ("GO TO SCENE");
					LoadScene ls = LoadObject.GetComponent<LoadScene> ();
					ls.GoToScene (0);
				}
				else
				{
					Debug.Log("Cant find object");
				}
				timed = false;
			}
		}
	}

	public void ResetIdleTime()
	{
		currTime = idleTime;
	}


}
