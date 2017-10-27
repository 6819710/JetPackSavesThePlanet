using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WormMusicTrigger : MonoBehaviour {
    private OxygenTrigger oxygenTrigger;
    private Health heath;
    private GameObject musicController;
    private GameObject sfxController;
	private Transform player;

    private Renderer renderer;
    private bool flag = false;

    public float distance;

	public float DistanceToPlayer
	{
		get {
			return Vector3.Distance (this.gameObject.transform.position, player.position);
		}
	}
	// Use this for initialization
	void Start () {
        musicController = GameObject.Find("Music");
        sfxController = GameObject.Find("SFX");
        player = gameObject.GetComponent<WormHead> ().Target;
        oxygenTrigger = player.GetComponent<OxygenTrigger>();
        heath = player.GetComponent<Health>();
        renderer = this.GetComponentInChildren<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (renderer.isVisible && !flag && !heath.isDead)
        {
            oxygenTrigger.Add();
            musicController.SendMessage("toPanic");
            sfxController.SendMessage("playEnemyFound");
            flag = true;
			GameManager.instance.GetComponent<TutorialManager> ().SetTrigger (TutorialManager.TutorialTriggers.WormSpawned);
        }
        else if (!renderer.isVisible && flag && !heath.isDead)
        {
            oxygenTrigger.Remove();
			flag = false;
			GameManager.instance.GetComponent<TutorialManager> ().SetTrigger (TutorialManager.TutorialTriggers.WormDespawned);
        }
		else if (renderer.isVisible && DistanceToPlayer < distance && !heath.isDead)
        {
            musicController.SendMessage("toPanicBeat");
        }
    }


}
