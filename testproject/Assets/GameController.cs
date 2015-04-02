using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private int choice;

	void Update(){
		spawnWait = Random.Range (1.0f,3.0f);
		choice = Random.Range (1,3);
		switch (choice)
		{
		case 1: hazard = Enemy1;
			break;
		case 2: hazard = Enemy2;
			break;
		}
	}
	
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}