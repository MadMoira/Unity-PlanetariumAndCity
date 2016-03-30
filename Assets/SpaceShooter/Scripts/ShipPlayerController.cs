using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax;
	public float zMin, zMax;
}

public class ShipPlayerController : MonoBehaviour 
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	public bool mobile;

	public GameObject shot;
	public Transform shotspawn;
	public float fireRate;
	private float nextFire = 0.0F;
    private Rigidbody rb;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

	void Update() {

		if (mobile)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotspawn.position, shotspawn.rotation); // as shot;
                audioSource.Play ();
			}
		}

		else {
			if (Input.GetButton("Fire1") && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotspawn.position, shotspawn.rotation); // as shot;
                audioSource.Play ();
			}
		}
	}

	void FixedUpdate(){

		float moveHorizontal;
		float moveVertical;

		if (mobile)
		{
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y;
		}
		else 
		{
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		}
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;
        rb.position = new Vector3
		(
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}

}