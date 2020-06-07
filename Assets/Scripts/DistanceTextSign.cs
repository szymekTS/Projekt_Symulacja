using System;
using UnityEngine;

public class DistanceTextSign : MonoBehaviour {

	TextMesh tm;
	void Start () {
		tm = GetComponent<TextMesh>();
		
		float value = transform.position.x;
		tm.text = "" + System.Math.Round(value * 2, 1, MidpointRounding.AwayFromZero) / 2 + "m";
	}
}
