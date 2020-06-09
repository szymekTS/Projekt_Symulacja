using UnityEngine;
using UnityEngine.UI;

public class Firing : MonoBehaviour {
    public GameObject BulletEmitter;
    public GameObject Bullet;
    public float BulletVelocity = 10;
    public float BulletMass = 10;
    public float BulletGravity = 9.81f;
    public float AirDensity = 1.2f;
    public float WindMagnitude = 0f;
    public ParticleSystem sparks;
    public ParticleSystem smoke;
    public Text angleText;
    public Text velocityText;
    public Text massText;
    public Text airDensityText;
    public Text gravityText;
    public Text windText;
    Rigidbody CannonBody;
    public AudioSource boom;
    float angletmp;

    // Use this for initialization
    void Start() {
        CannonBody = GetComponent<Rigidbody>();
    }

    public void AdjustAngle(float angle) {
        float tmpAngle = angle - 90;
        angletmp = tmpAngle + 90;
        CannonBody.transform.rotation = Quaternion.Euler(0, 0, tmpAngle);
        if (angleText != null)
            angleText.text = "" + "Kąt: " + angle + " stopni";
    }

    public void AdjustVelocity(float velocity) {
        BulletVelocity = velocity;
        if (velocityText != null)
            velocityText.text = "" + "Prędkość początkowa: " + velocity + " m/s";
    }

    public void AdjustMass(float mass) {
        BulletMass = mass;
        if (massText != null)
            massText.text = "" + "Masa: " + BulletMass + " kg";
    }
    public void AdjustAirDensity(float airDensity) {
        AirDensity = airDensity;
        if (airDensityText != null)
            airDensityText.text = "Gęstość powietrza: " + AirDensity + " kg/m3";
    }

    public void AdjustGravity(float gravity) {
        BulletGravity = gravity;
        if (gravityText != null)
            gravityText.text = "g: " + BulletGravity + "m/s^2";
    }

    public void AdjustWind(float wind) {
        WindMagnitude = wind;
        if (windText != null)
            windText.text = "Prędkość wiatru: " + WindMagnitude + "m/s";
    }

    public void HandleShotiing() {
        DoBooom();
        DoShot();
    }

    private void DoShot() {
        GameObject Temporary_Bullet_Handler = Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;
        Rigidbody Temporary_RigidBody;
        Temporary_Bullet_Handler.GetComponent<CannonBall>().dane = "V:" + BulletVelocity +",M:"+ BulletMass+",Angle:" + angletmp + ",g:" + BulletGravity+",p:"+ AirDensity + ",W:" + WindMagnitude;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.mass = BulletMass;
        Temporary_Bullet_Handler.GetComponent<Drag>().AirDensity = AirDensity;
        Temporary_Bullet_Handler.GetComponent<Drag>().WindSpeed = WindMagnitude;
        Temporary_Bullet_Handler.GetComponent<Gravity>().GravitationalAcceleration = BulletGravity;
        Temporary_RigidBody.velocity = transform.up * BulletVelocity;
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.GetComponent<Follower>().Target = Temporary_Bullet_Handler.transform;
        cam.GetComponent<Follower>().startFollow();
    }

    private void DoBooom() {
        sparks.Play();
        smoke.Play();
        boom.Play();
    }
}