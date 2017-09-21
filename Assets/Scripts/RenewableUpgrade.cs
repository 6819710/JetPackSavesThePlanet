using System;
using UnityEngine;

public abstract class RenewableUpgrade : Upgrade
{
	public RenewableUpgrade (String name) : base(name)
	{
	}

	public abstract bool isRenewable { get; }
	 
	public override void Activate ()
	{
		if(isRenewable){
			base.Activate ();
		}
	}

}