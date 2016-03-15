using UnityEngine;
using System.Collections;

public class RotatePlanet : MonoBehaviour {

	public float speed = 0;
	public bool inverse;
	float offset = 0;
	// Use this for initialization
	void Start () {
		inverse = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (!inverse)	offset += speed*0.005f;
		else	offset -= speed*0.005f;
		if (Mathf.Abs (offset) >= 1) {
			offset = 0;
		}

		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
	}
}
