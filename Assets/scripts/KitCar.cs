using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitCar : MonoBehaviour {

	private Rigidbody2D rb;
	public float velocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("r")) {
			Application.LoadLevel("cena1");
		}
	}

	void FixedUpdate()
	{
		//rb.velocity = new Vector3(1, 0, 0);
		rb.AddForce(new Vector3(velocity*Time.deltaTime, 0, 0));
		print("rodando");
	}
}
