using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTrigger : MonoBehaviour {

    private Oxygen oxygen;

    public float low;
    public float critical;

    private int triggerLow;
    private int triggerCritical;

	// Use this for initialization
	void Start () {
		oxygen = gameObject.GetComponent<Oxygen>();
        triggerLow = (int)(oxygen.maxOxygen * low); //Sets low oxygen threshold
        triggerCritical = (int)(oxygen.maxOxygen * critical);
    }
	
	// Update is called once per frame
	void Update () {
        if (oxygen.oxygen < triggerCritical)
        {
            GameObject.Find("Music").SendMessage("toStressBeat");
        }
        else if(oxygen.oxygen < triggerLow && oxygen.oxygen >= critical)
        {
            GameObject.Find("Music").SendMessage("toStress");
        }
        else if (oxygen.oxygen > triggerLow)
        {
            GameObject.Find("Music").SendMessage("toCalm");
        }
    }
}
