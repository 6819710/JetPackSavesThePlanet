using System;

[System.Serializable]
public abstract class TerminatingCondition: System.Object
{
	public virtual bool shouldTerminate() { return true; }
}
