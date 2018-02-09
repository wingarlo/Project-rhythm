using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// it goes to (0,-5,0)
public class W_Note : MonoBehaviour {
	public float BPM = 120f; //120 default
	Vector3 Dest = new Vector3(0,-5,0);
	float speed;
	public Collider2D me;
	public Collider2D innr;
	public Collider2D midl;
	public Collider2D outr;
	public Collider2D miss;
	// Use this for initialization
	void Start () {
		me = GameObject.FindGameObjectWithTag("www").GetComponent<CircleCollider2D>();
		innr = GameObject.FindGameObjectWithTag("Innerbox").GetComponent<CircleCollider2D>();
		midl = GameObject.FindGameObjectWithTag("Midbox").GetComponent<CircleCollider2D>();
		outr = GameObject.FindGameObjectWithTag("Outerbox").GetComponent<CircleCollider2D>();
		miss = GameObject.FindGameObjectWithTag("Misbox").GetComponent<CircleCollider2D>();
		//Assign BMP here
		//
		//---------------
		speed = (BPM / 50);
	}

	// Update is called once per frame
	void Update () {
		Vector3 dir = Dest - transform.position;

		float move = speed * Time.deltaTime;
		dir = dir.normalized;

		transform.Translate( dir * move);


	}
}
