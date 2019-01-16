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
		if(Input.GetKeyDown("r")) {
			Application.LoadLevel("cena1");
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		if(target){
			transform.position = new Vector3(target.position.x+20,Mathf.Clamp(target.position.y,0,30),target.position.z-10);
		}
		//transform.position = new Vector3(target.position.x+20,Mathf.Clamp(target.position.y,-30,1),target.position.z-10);
	}
}
