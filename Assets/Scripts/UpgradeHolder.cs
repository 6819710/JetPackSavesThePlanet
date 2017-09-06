using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeHolder : MonoBehaviour {

	public Upgrade upgrade;

	private Button button;
	private Image image;

	public Upgrade Upgrade {
		get {
			return upgrade;
		}
		set {
			upgrade = value;
		}
	}

	public Image Image {
		get {
			return image;
		}
		set {
			image = value;
		}
	}


	void Start () {
		button = this.gameObject.GetComponent<Button> ();
		foreach(Image i in this.gameObject.GetComponentsInChildren<Image> ()){
			if(i.gameObject != this.gameObject){
				image = i;
				break;
			}
		}
		initialiseUI ();
	}

	void initialiseUI(){
		if(upgrade!=null){
			image.sprite = upgrade.Image;
			button.onClick.AddListener(() => { 
				upgrade.Activate(); 
				if(upgrade is ITimable){
					ITimable timable = upgrade as ITimable;
					if(timable is ISpammable){
						ISpammable spamable = upgrade as ISpammable;
						if(spamable.isSpammable){
							Enable(false);
						}
					}
				}
			});
		}
	}

	void Enable(bool isTrue){
		button.interactable = isTrue;
	}
	
	// Update is called once per frame
	void Update () {
		Enable(!Upgrade.Active);
	}
}
