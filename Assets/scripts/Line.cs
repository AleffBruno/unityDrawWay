using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCol;

	List<Vector2> points; 

	void Start() {
		
		//print(v2);
	}

	void Update() {


	}


	public void UpdateLine (Vector2 mousePos) {
		if (points == null) {
			points = new List<Vector2>();
			SetPoints(mousePos);
			return;
		}

		if (Vector2.Distance(points.Last(),mousePos) > .1f) {
			SetPoints(mousePos);
		}
	}

	public void SetPoints (Vector2 point) {
		points.Add(point);

		lineRenderer.numPositions = points.Count;
		//lineRenderer.positionCount = points.Count; //the above is obsolete, this is the current
		lineRenderer.SetPosition(points.Count -1,point);

		if (points.Count > 1) {
			edgeCol.points = points.ToArray();
		}
	}
}
