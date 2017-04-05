using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float speed = 10f;
	private float maxDisplacement = 6f;

	// Use this for initialization
	void Start () {
		
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
	}

}
