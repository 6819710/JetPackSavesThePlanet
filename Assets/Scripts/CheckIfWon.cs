using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckIfWon : MonoBehaviour {
	
    //When the player collides with the goal, win the game
	void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            //Currently reloads the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
