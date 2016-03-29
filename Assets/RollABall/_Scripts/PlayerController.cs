using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody sphereRigidBody;
    private int count;

    public float speed;
    public Text countText;
    public Text winText;

    void Start()
    {
        count = 0;
        sphereRigidBody = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

        sphereRigidBody.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 11)
        {
            winText.text = "You Win!!";
        }
    }

}
