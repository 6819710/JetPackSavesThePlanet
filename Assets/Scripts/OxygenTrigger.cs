using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTrigger : MonoBehaviour {

    private Oxygen oxygen;

    public float low;

    private int triggerLow;

	// Use this for initialization
	void Start () {
		oxygen = gameObject.GetComponent<Oxygen>();
        triggerLow = (int)(oxygen.maxOxygen * low); //Sets low oxygen threshold
    }
	
	// Update is called once per frame
	void Update () {
		if(oxygen.oxygen < triggerLow)
        {
            GameObject.Find("Music").SendMessage("toStress");
        }
        else if (oxygen.oxygen > triggerLow)
        {
            GameObject.Find("Music").SendMessage("toCalm");
        }
    }
}
