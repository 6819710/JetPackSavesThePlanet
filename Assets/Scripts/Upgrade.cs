using System;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
	private GameObject _owner;
	private String _name;

	public GameObject Owner {
		get {
			return _owner;
		}
		set {
			_owner = value;
		}
	}

	public String Name {
		get {
			return name;
		}
		set {
			_name = value;
		}
	}

	public Upgrade(String name){
		_name = name;
	}

	public abstract void Effect ();

	public virtual void Activate ()
	{
		Effect ();
	}
}

