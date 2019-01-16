using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//30:35
	//public Rigidbody2D rb;
	public LineCreator lineCreator;
	private bool rayTouchUp = false;
	private Vector2 initialRaycastUpPos;
	enum ExplosionType {GiantExplosion,GrayExplosion};
	public allEffects allEffects;


	void Start () {

	}
	void Update () {
		WatchRotations();
		if(transform.position.y < -21){
			explodeMyself(ExplosionType.GiantExplosion);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "ink"){
			Destroy(col.gameObject);
			lineCreator.ReloadInk(1);
		}	


	}

	void OnTriggerExit2D(Collider2D col) {

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "ground")
		{
			explodeMyself(ExplosionType.GrayExplosion);
			print("GAME OVER");
		}
	}

	void explodeMyself(ExplosionType explosionType = ExplosionType.GrayExplosion){
			//Destroy(gameObject,0.5f);
			//Destroy(gameObject);
			switch(explosionType){
				case ExplosionType.GiantExplosion:
					Instantiate(allEffects.GiantExplosion,
								new Vector2(transform.position.x,transform.position.y+9f),
								Quaternion.identity);
					//GameObject explosion = Instantiate(allEffects.GiantExplosion);
					//explosion.transform.position = new Vector2(transform.position.x,transform.position.y+7.2f);
				break;
				case ExplosionType.GrayExplosion:
					GameObject grayExplosion = Instantiate(allEffects.GrayExplosion);
					grayExplosion.transform.position = new Vector2(transform.position.x,transform.position.y);
					break;
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
			}
		}

		if(hitUp.collider == null) {
			rayTouchUp = false;
			//print("toca nada");
		}
	}
		
}
