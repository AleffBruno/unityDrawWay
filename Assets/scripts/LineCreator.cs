using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineCreator : MonoBehaviour {

	public GameObject linePrefab;

	Line activeLine;

	public Image inkImage;
	//private float maxInk;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && CanDraw()) {
			GameObject lineGO = Instantiate(linePrefab);
			activeLine = lineGO.GetComponent<Line>();
		}

		if (Input.GetMouseButtonUp(0)) {
			activeLine = null;
		}

		if (activeLine != null && CanDraw()) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			activeLine.UpdateLine(mousePos);
			UseInk();
		}

	}

	bool CanDraw () {
		if(inkImage.fillAmount > 0){
			return true;
		} else {
			return false;
		}
	}

	void UseInk() {
		inkImage.fillAmount = inkImage.fillAmount - 0.1f *Time.deltaTime;
	}

	public void ReloadInk(float quantity = 1) {
		inkImage.fillAmount = inkImage.fillAmount + quantity;
	}
}
