using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroy : MonoBehaviour {

	void Destroy () {
		Destroy (this.gameObject);
	}

}
