using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkController : MonoBehaviour {

	public Image inkImage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool CanDraw () {
		if(inkImage.fillAmount > 0){
			return true;
		} else {
			return false;
		}
	}

	public void UseInk() {
		inkImage.fillAmount = inkImage.fillAmount - 0.1f *Time.deltaTime;
	}

	public void ReloadInk(float quantity = 1) {
		inkImage.fillAmount = inkImage.fillAmount + quantity;
	}
}
