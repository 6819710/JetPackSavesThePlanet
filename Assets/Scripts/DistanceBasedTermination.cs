using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DistanceBasedTermination: TerminatingCondition {

	[SerializeField] public float distance = 0;
	[SerializeField] public Transform distanceOf;

	public override bool shouldTerminate(){
		return (distanceOf.position).magnitude > distance;
	}

}
