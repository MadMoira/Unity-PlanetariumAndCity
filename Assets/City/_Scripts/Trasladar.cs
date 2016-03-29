using UnityEngine;
using System.Collections;

public class Trasladar : MonoBehaviour {

	public float velocidad;

	void Start () {
	
	}
	
	void Update () {
		gameObject.transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
	}
}
