using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	/// <summary>
	/// Gameobject spot to place player.
	/// </summary>
	public GameObject player;
	/// <summary>
	/// Gameobject camera.
	/// </summary>
	public GameCamera cam;
	
	/// <summary>
	/// At start, get attached gameobject and spawn player
	/// </summary>
	public void Start () {
		cam = GetComponent<GameCamera>();
		SpawnPlayer();
	}
	
	// Spawn player
	/// <summary>
	/// Spawns the player and sets camera on player
	/// </summary>
	public void SpawnPlayer() {
		cam.SetTarget((Instantiate(player,Vector3.zero,Quaternion.identity) as GameObject).transform);
	}
}
