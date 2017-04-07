using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private LevelManager levelManager;

	private float speed = 10f;
	private float maxDisplacement = 6f;

	public GameObject laserPrefab;
	private float laserSpeed = 6f;
	private float firingRate = 0.2f;
	// Use this for initialization
	void Start () {
		levelManager = Object.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 playerPos = this.transform.position;

		if (Input.GetKey(KeyCode.RightArrow)){
			playerPos.x += speed * Time.deltaTime;
			playerPos.x = Mathf.Clamp (playerPos.x, -maxDisplacement, maxDisplacement);
			this.transform.position = playerPos;

		}	
		if (Input.GetKey(KeyCode.LeftArrow)){
			playerPos.x -= speed * Time.deltaTime;
			playerPos.x = Mathf.Clamp (playerPos.x, -maxDisplacement, maxDisplacement);
			this.transform.position = playerPos;
		}
		if (Input.GetKeyDown(KeyCode.A)){
			InvokeRepeating ("ShootLaser", 0.000001f, firingRate);
		}	
		if (Input.GetKeyUp(KeyCode.A)){
			CancelInvoke ("ShootLaser");
		}	
	}

	void OnTriggerEnter2D( Collider2D other){
		LaserShot laserShot = other.GetComponent<LaserShot> ();
		// destroy player if hit by a laser (also destroy laser shot):
		if (laserShot){
			print ("you are hit");
			laserShot.DestroyLaserShot();
			Destroy (gameObject);
			levelManager.LoadLevel ("Lose");
		}
	}

	void ShootLaser(){
		Vector3 laserSpawnPosition = this.transform.position + new Vector3(0, 1f, 0);
		GameObject laser = Instantiate (laserPrefab, laserSpawnPosition, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, laserSpeed);
	}

}
