using System;
using UnityEngine;

public class RenewableUpgrade : Upgrade
{
	public RenewableUpgrade (String name) : base(name)
	{
	}

	public abstract double isRenewable { get; }
	 
	public override void Activate ()
	{
		if(isRenewable){
			base.Activate ();
		}
	}

}