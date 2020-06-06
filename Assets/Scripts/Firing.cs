using UnityEngine;

public class Firing : MonoBehaviour {
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Velocity = 100;
    public ParticleSystem sparks;
    public ParticleSystem smoke;
    Rigidbody CannonBody;
    public float turnRatio = 1;

    // Use this for initialization
    void Start() {
        CannonBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space")) {
            HandleShotiing();
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 rotationThisFrame = Vector3.back * turnRatio * 200 * Time.deltaTime;
            CannonBody.transform.Rotate(rotationThisFrame);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 rotationThisFrame = Vector3.forward * turnRatio * 200 * Time.deltaTime;
            CannonBody.transform.Rotate(rotationThisFrame);
        }
    }

    private void HandleShotiing() {
        sparks.Play();
        smoke.Play();
        GameObject Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.velocity = transform.up * Bullet_Velocity;
        Destroy(Temporary_Bullet_Handler, 10.0f);
    }
}