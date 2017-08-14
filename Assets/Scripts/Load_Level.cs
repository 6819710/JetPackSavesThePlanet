using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Level : MonoBehaviour {

    public string SceneName;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (SceneName != null)
        {
            SceneManager.LoadScene(SceneName);
        }  
    }
}
