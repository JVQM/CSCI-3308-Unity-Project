using UnityEngine;
using System.Collections;

public class SpawnFloor : MonoBehaviour
{
	public GameObject floor;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	
	void Update(){

	}
	
	void Start ()
	{
		StartCoroutine (Spawnfloor ());
	}
	
	IEnumerator Spawnfloor ()
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