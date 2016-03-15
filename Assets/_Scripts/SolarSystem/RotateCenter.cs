using UnityEngine;
using System.Collections;

public class RotateCenter : MonoBehaviour {

    public float speed;

    void Update()
    {
        transform.Rotate(Vector3.down, speed * Time.deltaTime);
    }
}
