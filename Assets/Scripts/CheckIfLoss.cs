using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckIfLoss : MonoBehaviour {

    public Oxygen OxygenBar;
	
	// Update is called once per frame
	void Update () {
		if (OxygenBar.isOut)
        {
            Lose();
        }
	}

    //This method will inculude the code for when the player losses the game
    void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
