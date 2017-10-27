using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTrigger : MonoBehaviour {

    private Oxygen oxygen;
	private GameObject musicPlayer;

    private int wormCount = 0;

    public float longtermTime = 15.0f;

    [SerializeField]
    private float deltaTime;

    bool flag;

	// Use this for initialization
	void Start () {
		oxygen = gameObject.GetComponent<Oxygen>();
		musicPlayer = GameObject.Find ("Music");
        deltaTime = longtermTime;
        flag = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (wormCount == 0)
        {
            if (oxygen.isCritical)
            {
                musicPlayer.SendMessage("toStressBeat");
                deltaTime = longtermTime;
                flag = true;
            }
            else if (oxygen.isLow)
            {
                musicPlayer.SendMessage("toStress");
                deltaTime = longtermTime;
                flag = true;
            }
            else if (deltaTime <= 0.0f && flag)
            {
                musicPlayer.SendMessage("toCalmBeat");
                flag = false;
            }
            else if (deltaTime > 0.0f)
            {
                musicPlayer.SendMessage("toCalm");
                deltaTime -= Time.deltaTime;
            }
        }
        else
        {
            deltaTime = longtermTime;
        }
    }

    public void Add()
    {
        wormCount++;
    }

    public void Remove()
    {
        wormCount--;
        if (wormCount < 0)
            wormCount = 0;
    }
}
