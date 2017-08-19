using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenLevel : MonoBehaviour {

    public Oxygen oxygen;
    public Image context;

    private float fillAmount;

    private int maxOxygen;
    private int currentOxygen;

	// Use this for initialization
	void Start () {
        maxOxygen = oxygen.maxOxygen;
        currentOxygen = oxygen.oxygen;
    }
	
	// Update is called once per frame
	void Update () {
		if(oxygen.oxygen != currentOxygen) // only process if current oxygen has changed
        {
            currentOxygen = oxygen.oxygen;
            fillAmount = 1.0f * ((float)currentOxygen / (float)maxOxygen);
            context.fillAmount = fillAmount;
            context.color = new Color(1.0f - fillAmount, fillAmount, 0.0f);
        }
	}
}
