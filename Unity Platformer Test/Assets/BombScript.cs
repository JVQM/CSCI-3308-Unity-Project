using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
	/// <summary>
	/// The bomb enemy.
	/// </summary>
	public Animator BombEnemy;
	/// <summary>
	/// The explosion S.
	/// </summary>
	public AudioSource ExplosionSD;
	/// <summary>
	/// The enemy speed.
	/// </summary>
	public float EnemySpeed = 0.1f;
	/// <summary>
	/// Value for destroying a bomb
	/// </summary>
	public int scoreValue = 10;
	// Use this for initialization
	/// <summary>
	/// Stuff to do at the start, gets attached animator and audio source
	/// </summary>
	public void Start () {
		BombEnemy = GetComponent<Animator>();
		AudioSource Explosion = GetComponent<AudioSource>();
		ExplosionSD = Explosion;
	}
	
	// Update is called once per frame
	/// <summary>
	/// Updates per frame, moves object left per frame, checks if dead, if true, starts death animation& sound then destroys object
	/// </summary>
	public void Update () {
		this.transform.position += new Vector3(-EnemySpeed*Time.deltaTime,0.0f,0.0f);
		if(this.GetComponent <Health>().isDead ()){
			BombEnemy.SetTrigger ("Explode");
			Destroy (this.gameObject,0.5f);
			}

	
	}/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="col">Col collision parameter to detect collisions</param>
	/// <param name="return">  Tag "Player" collision causes Health call, Dmg received & object destruct</param>
	public void OnTriggerEnter(Collider col){
		if(col != null){
			if(col.gameObject.tag == "Player"){
				BombEnemy.SetTrigger ("Explode");
				Destroy(this.gameObject,0.5f);
                ExplosionSD.Play();
				col.GetComponent<Health>().ReceiveDmg (5);
			}
			if(col.gameObject.tag == "Bullet"){
				ScoreManager.score += scoreValue;
			}
			}
		}
}
