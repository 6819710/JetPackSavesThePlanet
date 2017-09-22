using System;
using UnityEngine;

[System.Serializable]
public abstract class Upgrade : ScriptableObject
{
	private GameObject _owner;
	[SerializeField]
	private String _name;
	[SerializeField]
	private Sprite _image;

	private bool active;

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

	public bool Active {
		get {
			return active;
		}
		set {
			active = value;
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

	public virtual void Restore () {
		Active = false;
	}

	public virtual void Activate ()
	{
		Active = true;
		Effect ();
	}

	public static bool operator ==(Upgrade lhs, Upgrade rhs) 
	{
		if (object.ReferenceEquals(rhs, null)) return object.ReferenceEquals(lhs, null);
		return (lhs.GetType () == rhs.GetType ()) && (lhs.Name == rhs.Name); 
	}

	public static bool operator !=(Upgrade lhs, Upgrade rhs) 
	{
		return !(lhs==rhs); 
	}
}

