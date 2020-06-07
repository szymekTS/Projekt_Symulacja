using System;
using UnityEngine;

public class Drag : MonoBehaviour {
	public Rigidbody rb;
	public float AirDensity;
	public float WindSpeed;
	float DragCoefficient = 0.47f;
	Vector3 dragForce;
	Vector3 windForce;
	Vector3 force;
	float area;
	float ADA; //Air * DragCo * Area 

	void Start () {
		rb = GetComponent<Rigidbody>();
		area = Convert.ToSingle( Math.PI * Math.Pow(rb.transform.localScale.x/2,2));
		ADA = AirDensity * DragCoefficient * area;
	}

	private void CalculateForce() {
		float dragForceMagnitude = CalculateDragMagnitude(rb.velocity.magnitude);
		dragForce = -rb.velocity.normalized * dragForceMagnitude;
		float windForcwMagnitude = CalculateDragMagnitude(WindSpeed);
		if(WindSpeed>0)
			windForce = Vector3.right * windForcwMagnitude;
		else
			windForce = Vector3.left * windForcwMagnitude;
		force = dragForce + windForce;
	}

	private float CalculateDragMagnitude(float speed) {
		return 0.5f * (float)Math.Pow(speed,2) * ADA;
	}

	void FixedUpdate () {
		CalculateForce();
		rb.AddForce(force);
	}
}
