using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTrigger : MonoBehaviour {

    private Oxygen oxygen;
	private GameObject musicPlayer;

	// Use this for initialization
	void Start () {
		oxygen = gameObject.GetComponent<Oxygen>();
		musicPlayer = GameObject.Find ("Music");
    }
	
	// Update is called once per frame
	void Update () {
		if (oxygen.isCritical)
        {
			musicPlayer.SendMessage("toStressBeat");
        }
		else if(oxygen.isLow)
        {
			musicPlayer.SendMessage("toStress");
        }
        else
        {
			musicPlayer.SendMessage("toCalm");
        }
    }
}
