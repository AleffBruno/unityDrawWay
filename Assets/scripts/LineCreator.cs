using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineCreator : MonoBehaviour {

	public GameObject linePrefab;

	Line activeLine;

	//public Image inkImage;
	public InkController inkController;
	//private float maxInk;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(inkController.CanDraw()) {
			if (Input.GetMouseButtonDown(0)) {
			GameObject lineGO = Instantiate(linePrefab);
			activeLine = lineGO.GetComponent<Line>();
			}

			if (activeLine != null) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			activeLine.UpdateLine(mousePos);
			inkController.UseInk();
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			activeLine = null;
		}


	}

	// bool CanDraw () {
	// 	if(inkImage.fillAmount > 0){
	// 		return true;
	// 	} else {
	// 		return false;
	// 	}
	// }

	// void UseInk() {
	// 	inkImage.fillAmount = inkImage.fillAmount - 0.1f *Time.deltaTime;
	// }

	// public void ReloadInk(float quantity = 1) {
	// 	inkImage.fillAmount = inkImage.fillAmount + quantity;
	// }
}
