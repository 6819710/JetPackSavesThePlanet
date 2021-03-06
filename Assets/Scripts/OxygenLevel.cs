﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenLevel : MonoBehaviour {

    public Oxygen theOxygen;
    public Image context;

    private float fillAmount;

    private float maxOxygen;
    private float currentOxygen;

	public Animator animator;

	// Use this for initialization
	void Start () {
        if (theOxygen == null)
        {
            theOxygen = GameObject.Find("Player").GetComponent<Oxygen>();
        }
        maxOxygen = theOxygen.maxOxygen;
        currentOxygen = theOxygen.oxygen;
    }
	
	// Update is called once per frame
	void Update () {
		if(theOxygen.oxygen != currentOxygen) // only process if current oxygen has changed
        {
            currentOxygen = theOxygen.oxygen;
            fillAmount = 1.0f * ((float)currentOxygen / (float)maxOxygen);
            context.fillAmount = fillAmount;

			if (theOxygen.isCritical) {
				animator.SetTrigger ("Critical");
			}else if (theOxygen.isLow) {
				animator.SetTrigger ("Low");
			} else { 
				animator.SetTrigger ("Full");
			}
        }
	}
}
