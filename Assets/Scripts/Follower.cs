using UnityEngine;

public class Follower : MonoBehaviour {
    public bool doit = false;
    public Transform Target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    public void startFollow() {
        doit = true;
    }
    public void stopFollow() {
        doit = false;
    }
    void FixedUpdate() {
        if (doit) {
            Vector3 desiredPosition = Target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(Target);
        }
    }
}
