using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRayCast : MonoBehaviour {

	// Use this for initialization

	private bool rayTouchUp = false;
	public Vector2 initialRaycastUpPos;
	public Vector2 RaycastUpTarget;
	private int numberOfRotations;

	void Start () {
		RaycastUpTarget = Vector2.up;
	}
	
	void Update () {
		WatchRotations();
	}

	void WatchRotations() {
		initialRaycastUpPos = new Vector2(transform.position.x,transform.position.y+0.7f);
		RaycastHit2D hitUp = Physics2D.Raycast(initialRaycastUpPos,RaycastUpTarget,1);

		if (hitUp.collider != null && rayTouchUp == false)
		{
			if(hitUp.collider.name == "triggerCountRotation" || hitUp.collider.name == "triggerCountRotation2"){
				//Debug.Log("UP Name is: "+hitUp.collider.name);
				rayTouchUp = true;
				print(numberOfRotations++);
			}
		}

		if(hitUp.collider == null) {
			rayTouchUp = false;
			//print("toca nada");
		}
	}
}
