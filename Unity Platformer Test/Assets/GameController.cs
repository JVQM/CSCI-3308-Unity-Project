using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	/// <summary>
	/// 1st Placement for gameObject spawning. 
	/// </summary>
	public GameObject Object1;
	/// <summary>
	/// 2nd Placement for gameObject spawning.
	/// </summary>
	public GameObject Object2;
	/// <summary>
	/// 3rd Placement for gameObject spawning.
	/// </summary>
	public GameObject Object3;
	/// <summary>
	/// 4th Placement for gameObject spawning.
	/// </summary>
	public GameObject Object4;
	/// <summary>
	/// 5th Placement for gameObject spawning.	
	/// </summary>
	public GameObject Object5;
	/// <summary>
	/// 6th Placement for gameObject spawning.
	/// </summary>
	public GameObject Object6;
	/// <summary>
	/// Hazard spot for randomizing between 3 objects.
	/// </summary>
	public GameObject hazard;
	/// <summary>
	/// The spawn values.
	/// </summary>
	public Vector3 spawnValues;
	/// <summary>
	/// The hazard count.
	/// </summary>
	public int hazardCount;
	/// <summary>
	/// The spawn wait.
	/// </summary>
	public float spawnWait;
	/// <summary>
	/// The start wait.
	/// </summary>
	public float startWait;
	/// <summary>
	/// The wave wait.
	/// </summary>
	public float waveWait;
	/// <summary>
	/// Float Randomizer for objects
	/// summary>
	public int choice;

	/// <summary>
	/// Update per frame, randomizer for spawning between objects
	/// </summary>
	public void Update(){
		spawnWait = Random.Range (1.0f,3.0f);
		choice = Random.Range (1,7);
		switch (choice)
		{
		case 1: hazard = Object1;
			break;
		case 2: hazard = Object2;
			break;
		case 3: hazard = Object3;
			break;
		case 4: hazard = Object4;
			break;
		case 5: hazard = Object5;
			break;
		case 6: hazard = Object6;
			break;
		}
		if(Input.GetKeyDown(KeyCode.Escape) == true)
		{
			Application.Quit();
		}
	}
	/// <summary>
	/// initializer to start time for waves, sets hazards to spawn, spawn time, wave time and position to spawn
	/// </summary>
	public void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	public IEnumerator SpawnWaves ()
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
