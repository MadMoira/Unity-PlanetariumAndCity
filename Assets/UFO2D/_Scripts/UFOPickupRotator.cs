using UnityEngine;
using System.Collections;

public class UFOPickupRotator : MonoBehaviour {

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
