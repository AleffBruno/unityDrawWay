using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {

	public Transform target;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}

	void Update() {
		//transform.position.y = 
	}

	// Update is called once per frame
	void LateUpdate () {
		//transform.position = new Vector3(target.position.x+20,Mathf.Clamp(target.position.y,-30,1),target.position.z-10);
		transform.position = new Vector3(target.position.x+20,Mathf.Clamp(target.position.y,-30,1),target.position.z-10);
	}
}
