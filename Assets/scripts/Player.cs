using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//30:35
	//public Rigidbody2D rb;
	public LineCreator lineCreator;
	private bool rayTouchUp = false;
	private Vector2 initialRaycastUpPos;
	private int numberOfRotations;

	void Start () {

	}
	void Update () {
		WatchRotations();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "ink"){
			Destroy(col.gameObject);
			lineCreator.ReloadInk(1);
		}	
	}

	void OnTriggerExit2D(Collider2D col) {
		//print("exit");
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "ground")
		{
			Destroy(gameObject,0.5f);
			print("GAME OVER");
		}
	}

	void WatchRotations() {
		initialRaycastUpPos = new Vector2(transform.position.x,transform.position.y+0.7f);
		RaycastHit2D hitUp = Physics2D.Raycast(initialRaycastUpPos,Vector2.up,1);

		if (hitUp.collider != null && rayTouchUp == false)
		{
			if(hitUp.collider.name == "triggerCountRotation" || hitUp.collider.name == "triggerCountRotation2"){
				//Debug.Log("UP Name is: "+hitUp.collider.name);
				rayTouchUp = true;
				lineCreator.ReloadInk(0.01f);
				//print(numberOfRotations++);
			}
		}

		if(hitUp.collider == null) {
			rayTouchUp = false;
			//print("toca nada");
		}
	}
		
}
