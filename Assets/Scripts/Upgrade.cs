using System;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
	private GameObject _owner;
	private String _name;
	private Sprite _image;

	public GameObject Owner {
		get {
			return _owner;
		}
		set {
			_owner = value;
		}
	}

	public Sprite Image {
		get {
			return _image;
		}
		set {
			_image = value;
		}
	}

	public String Name {
		get {
			return _name;
		}
		set {
			_name = value;
		}
	}

	public Upgrade(String name){
		_name = name;
	}

	public Upgrade(String name, Sprite image){
		_name = name;
		_image = image;
	}

	public abstract void Effect ();

	public virtual void Activate ()
	{
		Effect ();
	}
}

