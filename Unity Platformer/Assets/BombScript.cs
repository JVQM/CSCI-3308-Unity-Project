using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
	private Animator BombEnemy;
	private AudioSource ExplosionSD;
	public float EnemySpeed = 0.1f;
	// Use this for initialization
	void Start () {
		BombEnemy = GetComponent<Animator>();
		AudioSource Explosion = GetComponent<AudioSource>();
		ExplosionSD = Explosion;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(-EnemySpeed*Time.deltaTime,0.0f,0.0f);
		if(this.GetComponent <Health>().isDead ()){
			BombEnemy.SetTrigger ("Explode");
			Destroy (this.gameObject,0.5f);}
			ExplosionSD.Play ();
		Destroy (this.gameObject,10f);

	
	}
	void OnTriggerEnter(Collider col){
		if(col != null){
			if(col.gameObject.tag == "Player"){
				BombEnemy.SetTrigger ("Explode");
				Destroy(this.gameObject,0.5f);
				ExplosionSD.Play ();
				col.GetComponent<Health>().ReceiveDmg (5);
			}
		}
	}
}
