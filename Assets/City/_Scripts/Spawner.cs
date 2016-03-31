using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject carro;
	public float timeForSpawn;
	private float windowTime;

	void Start () 
	{
		windowTime = 0f;
		//StartCoroutine(CreateCar(timeForSpawn));
	}

	//IEnumerator CreateCar(float timeForSpawn)
	//{
	//	for (;;) {
	//		Instantiate (carro, gameObject.transform.position, Quaternion.identity);	
	//		yield return new WaitForSeconds (timeForSpawn);
	//	}
	//}
	
	void Update () 
	{
		if (Time.time > windowTime) {
			windowTime = Time.time + timeForSpawn;
			Instantiate (carro, gameObject.transform.position, transform.rotation);
		}
	}
}
