using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "ground")
		{
			//print("colidiu");
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		//print("enter");
	}

	void OnTriggerExit2D(Collider2D col) {
		//print("exit");
	}
}
