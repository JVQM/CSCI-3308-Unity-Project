using UnityEngine;
using System.Collections;

public class SpawnFloor : MonoBehaviour
{
	/// <summary>
	/// The GameObject that acts as the main floor of the game.
	/// </summary>
	public GameObject floor;
	/// <summary>
	/// The spawn position values.
	/// </summary>
	public Vector3 spawnValues;
	/// <summary>
	/// The delay between object spawn times.
	/// </summary>
	public float spawnWait;
	/// <summary>
	/// The delay between the start of the game and the start of the floor spawning.
	/// </summary>
	public float startWait;

	/// <summary>
	/// Update per frame
	/// </summary>
	void Update(){

	}

	/// <summary>
	/// Initialize to start time for waves. Sets Spawn position and spawns based on spawnWait	/// </summary>
	public void Start ()
	{
		StartCoroutine (Spawnfloor ());
	}
	
	public IEnumerator Spawnfloor ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (floor, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
		}
	}
}