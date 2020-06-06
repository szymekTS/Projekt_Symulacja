using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class distance : MonoBehaviour {

	TextMesh textMesh;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
		textMesh.text = "" + transform.position.x/2 + "m";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
