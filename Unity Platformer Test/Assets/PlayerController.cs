using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : Health {
	
	// Player Handling
	/// <summary>
	/// The gravity.
	/// </summary>
	public float gravity = 20;
	/// <summary>
	/// The speed.
	/// </summary>
	public float speed = 8;
	/// <summary>
	/// The acceleration.
	/// </summary>
	public float acceleration = 30;
	/// <summary>
	/// The height of the jump.
	/// </summary>
	public float jumpHeight = 12;

	/// <summary>
	/// The current speed.
	/// </summary>
	public float currentSpeed;
	/// <summary>
	/// The target speed.
	/// </summary>
	public float targetSpeed;
	/// <summary>
	/// The amount to move.
	/// </summary>
	public Vector2 amountToMove;

	/// <summary>
	/// The shot Sound.
	/// </summary>
	public AudioSource ShotSD;
	/// <summary>
	/// The roll Sound.
	/// </summary>
	public AudioSource RollSD;
	/// <summary>
	/// The jump Sound.
	/// </summary>
	public AudioSource JumpSD;
	/// <summary>
	/// The death Sound.
	/// </summary>
	public AudioSource DeathSD;

	/// <summary>
	/// Gets player physics script.
	/// </summary>
	public PlayerPhysics playerPhysics;
	/// <summary>
	/// Gets player animator.
	/// </summary>
	public Animator Player;

	/// <summary>
	/// Variable to hold current health
	/// </summary>
	public float cHealth;

	/// <summary>
	/// Sets gameobject shot for prep
	/// </summary>
	public GameObject Shot;
	
	/// <summary>
	/// Gets player physics, animator and sets audio sources to listen
	/// </summary>
	public void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
		Player = GetComponent<Animator>();
		AudioSource[] audios = GetComponents<AudioSource>();
		ShotSD = audios[0];
		RollSD = audios[1];
		JumpSD = audios[2];
	}

	/// <summary>
	/// Update per frame. check if player is dead, sets player speed, checks for user input
	/// </summary>
	public void Update () {
		cHealth = this.GetComponent<Health>().currentHealth;
		CurrentHealth.cHealth = cHealth;
		if(this.GetComponent <Health>().isDead ()){
			Player.SetTrigger ("Death");
			Destroy (this.gameObject, 3);
			StartCoroutine (RestartLevel ());
		}
		// Reset acceleration upon collision
		if (playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}

		//If player is firing weapon
		if (Input.GetMouseButtonDown (1)){
			GameObject bullet = Instantiate (Resources.Load ("Shot")) as GameObject;
			Player.SetTrigger ("Shoot");
			ShotSD.Play ();
			bullet.transform.position = (this.transform.position + new Vector3(1.0f,1.3f,0.0f));
		}

		if (Input.GetMouseButtonDown (2)){
			Player.SetTrigger ("Roll");
			RollSD.Play ();
		}

		// If player is touching the ground
		if (playerPhysics.grounded) {
			amountToMove.y = 0;
			
			// Jump
			if (Input.GetMouseButtonDown(0)) {
				amountToMove.y = jumpHeight;
				Player.SetTrigger ("Jump");
				JumpSD.Play ();
			}
		}
		
		// Input
		targetSpeed =  speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed,acceleration);
		
		// Set amount to move
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);
	}

	/// <summary>
	/// Restarts the level after a 2 second delay after death.
	/// </summary>
	/// <returns>The current level.</returns>
	public IEnumerator RestartLevel () {
		yield return new WaitForSeconds(2);
		Application.LoadLevel(Application.loadedLevel);
	}

	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
		if (n == target) {
			return n;	
		}
		else {
			float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target; // if n has now passed target then return target, otherwise return n
		}
	}
}
