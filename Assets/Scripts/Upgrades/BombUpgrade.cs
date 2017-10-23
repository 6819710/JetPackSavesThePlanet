using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu]
public class BombUpgrade : ConsumableUpgrade {
	
	public GameObject bombPrefab;
	public float damageRadius = 1;
	private float spawnMinRadius = 2;
	private float spawnMaxRadius = 3;

	public BombUpgrade (string name): base(name)
	{
	}

	public override void Effect ()
	{
		Spawn ();
		Restore ();
	}

	private void Spawn(){
		float angle = Random.Range(0f, 360f);
		float dist  = Random.Range(spawnMinRadius,spawnMaxRadius);
		GameObject bomb = Instantiate (bombPrefab, Owner.transform.position, new Quaternion());
		bomb.transform.Rotate(new Vector3(0, angle, 0));
		bomb.transform.Translate(new Vector3(dist, 0, dist));
	}
}
