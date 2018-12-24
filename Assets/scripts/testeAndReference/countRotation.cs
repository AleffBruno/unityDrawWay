using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countRotation : MonoBehaviour {

	public float X = 0.0f;

	private float T = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.Rotate (0, 0, X);
		if(X<0){
			T = T + (transform.rotation.z*-1);
		} else {
			T += transform.rotation.z;
		}


		Debug.Log ("Rotations: " + (int)(T / 360.0));
	}
}
