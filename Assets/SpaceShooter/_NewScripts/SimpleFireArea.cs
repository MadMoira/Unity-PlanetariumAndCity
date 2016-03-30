using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SimpleFireArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	private bool canFire;
	private bool touched;
	private int pointerID;

	void Awake () {
		touched = false;
		canFire = false;
	}

	public void OnPointerDown (PointerEventData data){
		// Set if pad is Touched
		if (!touched) {
			touched = true;
			pointerID = data.pointerId;
			canFire = true;
		}		
	}
	
	public void OnPointerUp(PointerEventData data){
		// Reset Everything
		if (data.pointerId == pointerID) {
			canFire = false;
			touched = false;
		}
	}
	
	public bool getCanFire(){
		return canFire;
	}

	
}
