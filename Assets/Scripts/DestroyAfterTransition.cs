using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTransition : MonoBehaviour {

	public void DestroyAfter(){
		Destroy(this.gameObject);
	}
}
