using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {
	
	private float health = 100f;

	public GameObject laserPrefab;
	private float delay;
	private float firingRate = 1f;
	private float laserSpeed = 3f;

	void Start(){
		delay = Random.Range(1f,2.5f);
		firingRate += Random.Range(0, 0.3f);
		InvokeRepeating ("ShootLaser", delay, firingRate);		
	}

	void Update(){
		if (health <= 0){
			Destroy (gameObject, 0.05f);
		}
	}

	void OnTriggerEnter2D( Collider2D other){
		float damage = 0;
		LaserShot laserShot = other.GetComponent<LaserShot> ();

		if (laserShot){
			damage = laserShot.GetDamage();
			health -= damage;
			laserShot.DestroyLaserShot();
		}
	}


	void ShootLaser(){
		Vector3 laserSpawnPosition = this.transform.position + new Vector3(0, -0.3f, 0);
		GameObject laser = Instantiate (laserPrefab, laserSpawnPosition, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -laserSpeed);
	}
}
