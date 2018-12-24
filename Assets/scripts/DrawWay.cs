using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class DrawWay : MonoBehaviour {

	public SpriteShapeController spriteShapeController;
	private Spline spline;

	// Use this for initialization
	void Start () {
		
		spline = spriteShapeController.spline;
		//spline.InsertPointAt(2,new Vector3(10,0,0));
		//spline.InsertPointAt(3,new Vector3(15,0,0));
		//spline.SetTangentMode(spline.GetPointCount()-1,ShapeTangentMode.Continuous);


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0)) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Vector2.Distance(spline.GetPosition(spline.GetPointCount()-1),mousePos) > .5f) {
				spline.InsertPointAt(spline.GetPointCount(),new Vector3(mousePos.x,mousePos.y,0));
				spline.SetTangentMode(spline.GetPointCount()-1,ShapeTangentMode.Continuous);
			}
		}
			
	}
}
