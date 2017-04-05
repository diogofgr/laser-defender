using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
		SpawnEnemy ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy(){
		Vector3 spawnPosition = new Vector3 (Random.Range(-5f, 5f), 3f, 0f);
		GameObject enemy = Instantiate (enemyPrefab, spawnPosition, Quaternion.identity) as GameObject;
		enemy.transform.parent = this.transform;
	}
}
