using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrail : MonoBehaviour {

	private RaycastHit hit;
	// Use this for initialization
	void Start () {
		//tenho que colidir com a linha e me adaptar a rotação do ponto de colisao
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawLine(transform.position,new Vector3(0,0,0));
		// if(Physics.Linecast(transform.position,new Vector3(0,0,0),out hit)){
		// 	Debug.DrawLine(transform.position,hit.point,Color.red);
		// }
	}
}
