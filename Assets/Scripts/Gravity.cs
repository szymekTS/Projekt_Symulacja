using UnityEngine;
using UnityEngine.UI;

public class Gravity : MonoBehaviour {
	public Rigidbody rb;
	public float GravitationalAcceleration = 9.81f;
	Vector3 force;

	void Start () {
		CalculateForce();
	}

	private void CalculateForce() {
		float forceMagnitude = rb.mass * GravitationalAcceleration;
		force = Vector3.down * forceMagnitude;
	}

	void FixedUpdate () {
		rb.AddForce(force);
	}
}
