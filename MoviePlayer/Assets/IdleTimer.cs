using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleTimer : MonoBehaviour {

    public float idleTime;
    private float currTime;
    public Text textField;
    public GameObject c2d;
    public bool timed;
     
	// Use this for initialization
	void Start () {
        timed = true;
        textField.text = "Auto play in " + (int)currTime;
        ResetIdleTime();
        //c2d = GameObject.Find("Cover2D");
        //c2d = GameObject.FindGameObjectWithTag("cover");
    }
	
	// Update is called once per frame
	void Update () {
        if (timed)
        {
            currTime -= Time.deltaTime;

            if (currTime > 0)
            {
                textField.text = "Auto play in " + (int)currTime;
                Debug.Log("Auto play in: "+(int)currTime);
            }
            else
            {
                if (currTime < 0)
                {
                    c2d.GetComponent<CoverEvents>().gotoPlayVideoSceneAuto(0);
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
