using System;

public abstract class ConsumableUpgrade : Upgrade
{
	private int uses = 1;

	public int Uses {
		get {
			return uses;
		}
		set {
			uses = value;
		}
	}

	public bool isUsedUp{
		get { return (uses <= 0); } 
	}

	public ConsumableUpgrade (String name): base(name)
	{
	}

	public override void Activate ()
	{
		if (!isUsedUp) {
			Uses--;
			base.Activate ();
		}
	}
}
