using UnityEngine;
using System.Collections;

public class CrateScript : MonoBehaviour {
	/// <summary>
	/// The crate object animation.
	/// </summary>
	public Animator CrateObject;
	/// <summary>
	/// The explosion sound effect.
	/// </summary>
	public AudioSource ExplosionSFX;
	/// <summary>
	/// Speed of GameObject.
	/// </summary>
	public float EnemySpeed = 0.1f;
	/// <summary>
	/// Points for destroying the nearly indestructable box
	/// </summary>
	public int BoxScore = 10;
	// Use this for initialization
	/// <summary>
	/// Sets attached animations and audio sources.
	/// </summary>
	public void Start () {
		CrateObject = GetComponent<Animator>();
		AudioSource Explosion = GetComponent<AudioSource>();
		ExplosionSFX = Explosion;
	}
	
	// Update is called once per frame
	/// <summary>
	/// Updates every frame. Moves object, checks isDead. If true, destroys object, plays animation.
	/// </summary>
	public void Update () {
		this.transform.position += new Vector3(-EnemySpeed*Time.deltaTime,0.0f,0.0f);
		if(this.GetComponent <Health>().isDead ()){
			ScoreManager.score += BoxScore;
			CrateObject.SetTrigger ("Explode");
			Destroy (this.gameObject,0.5f);}
	}
	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="col">Col collision parameter to detect collisions.</param>
	/// <param name="return">  Tag "Player" collision causes Health call, Dmg received & object destruct</param>
	public void OnTriggerEnter(Collider col){
		if(col != null){
			if(col.gameObject.tag == "Player"){
				CrateObject.SetTrigger ("Explode");
				Destroy(this.gameObject,0.5f);
				ExplosionSFX.Play ();
				col.GetComponent<Health>().ReceiveDmg (5);
			}
		}
	}
}
