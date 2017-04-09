using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class idleCounter : MonoBehaviour {

    public float idleTime;
    private float currTime;
    public Text textField;
    public bool timed;
    private int movieNum;


    // Use this for initialization
    void Start () {

        textField.text = "Auto play in " + (int)currTime;
        ResetIdleTime();
        timed = true;
        movieNum = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (timed) { 
            currTime -= Time.deltaTime;
            Debug.Log("TIME: "+currTime);
            if (currTime > 0)
            {
                textField.text = "Auto play movie " + movieNum + " in " +(int)currTime;
            }
            else
            {
                Debug.Log("**TIME UP");
                //goToVideoScene(movieNum - 1);
                ResetIdleTime();
                timed = false;
                if (movieNum < 4) movieNum++;
                else movieNum = 1;
            }
         }
    }

    public void ResetIdleTime()
    {
        currTime = idleTime;
    }


}
