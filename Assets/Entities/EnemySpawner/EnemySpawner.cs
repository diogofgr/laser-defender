using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 6f;
	public float height = 3f;

	private float speed = 4f;
	private float maxDisplacement = 5f;
	private bool goLeft = false;
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform){
			Vector3 spawnPosition = child.transform.position;
			GameObject enemy = Instantiate (enemyPrefab, spawnPosition, Quaternion.identity) as GameObject;

			//reparenting the instantiated gameObject:
			enemy.transform.parent = child;
		}
	}

	// Update is called once per frame
	void Update () {
		Vector2 spawnerPos = this.transform.position;
		bool goRight = !goLeft;

		if (goRight){
			spawnerPos.x += speed * Time.deltaTime;
			spawnerPos.x = Mathf.Clamp (spawnerPos.x, -maxDisplacement, maxDisplacement);
			this.transform.position = spawnerPos;
			if (spawnerPos.x == maxDisplacement){
				goLeft = true;
			}

		}	
		if (goLeft){
			spawnerPos.x -= speed * Time.deltaTime;
			spawnerPos.x = Mathf.Clamp (spawnerPos.x, -maxDisplacement, maxDisplacement);
			this.transform.position = spawnerPos;
			if (spawnerPos.x == -maxDisplacement){
				goLeft = false;
			}
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (this.transform.position, new Vector3(width, height));
	}
		
}
