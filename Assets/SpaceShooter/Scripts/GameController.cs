using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValue;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text ScoreText;
	public Text RestartText;
	public Text GameoverText;

	public bool gameOver;
	private bool restart;
	private int Score;

	void Start () {
		Score = 0;
		gameOver = false;
		restart = false;
		RestartText.text = "";
		GameoverText.text = "";
		updateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)){
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
		    Application.Quit (); 
		}
	}

	IEnumerator SpawnWaves () 
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				RestartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void addScore (int newScoreValue){
		Score += newScoreValue;
		updateScore ();
	}

	void updateScore () {
		ScoreText.text = "Score: " + Score;
	}

	public void GameOver () {
		GameoverText.text = "Game Over";
		gameOver = true;
	}

}