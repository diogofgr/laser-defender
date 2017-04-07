using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {

	private float damage = 100f;

	public float GetDamage(){
		return damage;
	}

	public void DestroyLaserShot(){
		Destroy (gameObject);
	}
}
