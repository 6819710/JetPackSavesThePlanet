using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAsteroid : Asteroid {

	// Use this for initialization
	new void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

	public override void Split (Vector2 normal)
	{
		base.Split (normal);
		GameManager.instance.gameObject.GetComponent<ScoreManager> ().IceAsteroidsDestroyed++;
	}
}
