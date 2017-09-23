using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Level : MonoBehaviour {

    public string SceneName;

    //When colliding, it will load the given level
    //NOTE: When loading a level, the scene must be added to the build settings
    //      this can be done by going into file/Build Settings
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (SceneName != null && coll.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName);
        }  
    }
}
