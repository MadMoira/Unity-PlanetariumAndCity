using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Select : MonoBehaviour {

    public Text NameText;
    public String PlanetName;
    private Vector3 OriginalScale;
    public float SelectedScale;

    void Start()
    {
        OriginalScale = gameObject.transform.localScale;
    }

	void OnMouseEnter()
    {
        gameObject.transform.localScale = OriginalScale * SelectedScale;
        NameText.text = PlanetName;
    }

    void OnMouseExit()
    {
        gameObject.transform.localScale = OriginalScale;
        NameText.text = "";
    }

}