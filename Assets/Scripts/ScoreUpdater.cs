﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUpdater : MonoBehaviour {

	public Text UIText;
	private ScoreManager scoreManager;

	void Start () {
		if(!UIText) UIText = this.GetComponent<Text>();
		scoreManager = GameManager.instance.GetComponent<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		UIText.text = scoreManager.TimeSpent;
	}
}
