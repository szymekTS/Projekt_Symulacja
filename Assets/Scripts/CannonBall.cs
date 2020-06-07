using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CannonBall : MonoBehaviour {
	bool alive = true;
	Rigidbody rb;
	public float start;
	public float stop;
	public float time;
	public float velocity;
	public GameObject Sign;
	public ParticleSystem smoke;

	StringBuilder csvContent;
	// Use this for initialization
	void Start () {
		csvContent = new StringBuilder();
		smoke.Play();
		rb = GetComponent<Rigidbody>();
		start = Time.time;
		Invoke("getspeed", 0.1f);
	}
	void OnCollisionEnter(Collision collision) {
		if (!alive) { return; }
		switch (collision.gameObject.tag) {
			case "Finish":
				alive = false;
				stop = Time.time;
				time = start - stop;
				StartEndSequence();
				break;
			default:
				break;
		}
	}

	void FixedUpdate() {
		if (alive) {
			time = Time.time - start;
			string line = Math.Round(rb.transform.position.x,4) + "," + Math.Round(rb.transform.position.y,4) + "," + Math.Round(time,4);
			csvContent.AppendLine(line);
		}

	}

	private void getspeed() {
		velocity = rb.velocity.magnitude;
	}
	private void StartEndSequence() {
		smoke.Stop();
		GameObject Sign_Handler = Instantiate(Sign, new Vector3(transform.position.x, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
		GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
		cam.GetComponent<Follower>().Target = Sign_Handler.transform;
		Invoke("StopAfterHit", 3f);
		writeCSVFile();
	}

	private void StopAfterHit() {
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Follower>().stopFollow();
		rb.constraints = RigidbodyConstraints.FreezeAll;
	}

	private void writeCSVFile() {
		StreamWriter outStream = File.CreateText(getPath());
		outStream.WriteLine(csvContent);
		outStream.Close();
	}

	private string getPath() {
		string path = Path.GetDirectoryName(Application.dataPath) + "/shot" + "_" + System.DateTime.Now.Day+"-" + System.DateTime.Now.Month+"-" + System.DateTime.Now.Year + "_" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + "-" + System.DateTime.Now.Second + ".csv";
		return path;
	}
}
