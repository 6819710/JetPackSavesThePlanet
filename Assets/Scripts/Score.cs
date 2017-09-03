using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public GameObject ThePlayer;
    public float UnitsPerPoint = 1;

    private float UnitsTraveled = 0;

	// Use this for initialization
	void Start () {
        //If the player has not been added then it will find the player
		if (ThePlayer == null)
        {
            ThePlayer = GameObject.Find("Player");
        }
	}
	
	// Update is called once per frame
	void Update () {
        //Updates the units traveled if the player has moved further than the saved distance
        float CurrentUnits = ThePlayer.transform.position.y;
		if (UnitsTraveled <= CurrentUnits)
        {
            UnitsTraveled = CurrentUnits;
        }
	}

    //Returns the scrore
    public float CurrentScore
    {
        get
        {
            return UnitsTraveled / UnitsPerPoint;
        }
    }
}
