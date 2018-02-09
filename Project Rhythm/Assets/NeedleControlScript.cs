using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedleControlScript : MonoBehaviour {
	public float sensitivity = 1f;
	float rotationZ = 0f;
	int score = 0;
	public GameObject[] q, w, e, r;
	GameObject closestq, closestw, closeste,closestr;
	public Collider2D innr;
	public Collider2D midl;
	public Collider2D mid2;
	public Collider2D outr;
	public Collider2D miss;
	// Use this for initialization
	void Start () {
		innr = GameObject.FindGameObjectWithTag("Innerbox").GetComponent<CircleCollider2D>();
		midl = GameObject.FindGameObjectWithTag("Midbox").GetComponent<CircleCollider2D>();
		mid2 = GameObject.FindGameObjectWithTag("Mid2").GetComponent<CircleCollider2D>();
		outr = GameObject.FindGameObjectWithTag("Outerbox").GetComponent<CircleCollider2D>();
		miss = GameObject.FindGameObjectWithTag("Misbox").GetComponent<CircleCollider2D>();
	}

	public GameObject FindClosest(GameObject[] notes){
		GameObject closest = null;
		float dist = Mathf.Infinity;
		Vector3 pos = new Vector3(0f,-5f,0f);
		foreach(GameObject note in notes){
			Vector3 diff = note.transform.position - pos;
			float curDist = diff.sqrMagnitude;
			if(curDist < dist){
				closest = note;
				dist = curDist;
			}
		}
		return closest;

	}
	
	// Update is called once per frame
	void Update () {
		q = GameObject.FindGameObjectsWithTag ("qqq");
		w = GameObject.FindGameObjectsWithTag ("www");
		e = GameObject.FindGameObjectsWithTag ("eee");
		r = GameObject.FindGameObjectsWithTag ("rrr");
		Scoring.scoreVal = score;
		rotationZ += Input.GetAxis("Mouse X") * sensitivity;
		rotationZ = Mathf.Clamp (rotationZ, -90, 90);

		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);


		/*****************************************
		 * 			SCORING
		 * ***************************************/


		/******Q******/
		closestq = FindClosest(q);
		if (closestq != null) {
			if (outr.IsTouching (closestq.GetComponent<CircleCollider2D> ())) {//just outer = miss
				if (midl.IsTouching (closestq.GetComponent<CircleCollider2D> ())) {//outer+mid = bad
					if (mid2.IsTouching (closestq.GetComponent<CircleCollider2D> ())) {//outer+mid+mid2 = good
						if (innr.IsTouching (closestq.GetComponent<CircleCollider2D> ())) {//outer+mid+inner = perf
							if (Input.GetKey (KeyCode.Q)) {
								if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.R)) {
									Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
									return;
								}
								score += 100;
								Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("Q_Host")));
								return;
							}
						}
						if (Input.GetKey (KeyCode.Q)) {
							if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.R)) {
								Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
								return;
							}
							score += 50;
							Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("Q_Host")));
							return;
						}
					}
					if (Input.GetKey (KeyCode.Q)) {
						if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.R)) {
							Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
							return;
						}
						score += 25;
						Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("Q_Host")));
						return;
					}
				}
				if (Input.GetKey (KeyCode.Q)) {
					Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("Q_Host")));
					return;
				}
			}
			if (miss.IsTouching (closestq.GetComponent<CircleCollider2D> ())) {
				Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("Q_Host")));
			}
		}

		/******W******/
		closestw = FindClosest(w);
		if (closestw != null) {
			if (outr.IsTouching (closestw.GetComponent<CircleCollider2D> ())) {//just outer = miss
				if (midl.IsTouching (closestw.GetComponent<CircleCollider2D> ())) {//outer+mid = bad
					if (mid2.IsTouching (closestw.GetComponent<CircleCollider2D> ())) {//outer+mid+mid2 = good
						if (innr.IsTouching (closestw.GetComponent<CircleCollider2D> ())) {//outer+mid+inner = perf
							if (Input.GetKey (KeyCode.W)) {
								if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.R)) {
									Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
									return;
								}
								score += 100;
								Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("W_Host")));
								return;
							}
						}
						if (Input.GetKey (KeyCode.W)) {
							if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.R)) {
								Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
								return;
							}
							score += 50;
							Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("W_Host")));
							return;
						}
					}
					if (Input.GetKey (KeyCode.W)) {
						if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.R)) {
							Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
							return;
						}
						score += 25;
						Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("W_Host")));
						return;
					}
				}
				if (Input.GetKey (KeyCode.W)) {
					Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("W_Host")));
					return;
				}
			}
			if (miss.IsTouching (closestw.GetComponent<CircleCollider2D> ())) {
				Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("W_Host")));
			}
		}


		/******E******/
		closeste = FindClosest(e);
		if (closeste != null) {
			if (outr.IsTouching (closeste.GetComponent<CircleCollider2D> ())) {//just outer = miss
				if (midl.IsTouching (closeste.GetComponent<CircleCollider2D> ())) {//outer+mid = bad
					if (mid2.IsTouching (closeste.GetComponent<CircleCollider2D> ())) {//outer+mid+mid2 = good
						if (innr.IsTouching (closeste.GetComponent<CircleCollider2D> ())) {//outer+mid+inner = perf
							if (Input.GetKey (KeyCode.E)) {
								if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.R)) {
									Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
									return;
								}
								score += 100;
								Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("E_Host")));
								return;
							}
						}
						if (Input.GetKey (KeyCode.E)) {
							if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.R)) {
								Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
								return;
							}
							score += 50;
							Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("E_Host")));
							return;
						}
					}
					if (Input.GetKey (KeyCode.E)) {
						if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.R)) {
							Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
							return;
						}
						score += 25;
						Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("E_Host")));
						return;
					}
				}
				if (Input.GetKey (KeyCode.E)) {
					Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("E_Host")));
					return;
				}
			}
			if (miss.IsTouching (closeste.GetComponent<CircleCollider2D> ())) {
				Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("E_Host")));
			}
		}

		/******R******/
		closestr = FindClosest(r);
		if (closestr != null) {
			if (outr.IsTouching (closestr.GetComponent<CircleCollider2D> ())) {//just outer = miss
				if (midl.IsTouching (closestr.GetComponent<CircleCollider2D> ())) {//outer+mid = bad
					if (mid2.IsTouching (closestr.GetComponent<CircleCollider2D> ())) {//outer+mid+mid2 = good
						if (innr.IsTouching (closestr.GetComponent<CircleCollider2D> ())) {//outer+mid+inner = perf
							if (Input.GetKey (KeyCode.R)) {
								if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.E)) {
									Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
									return;
								}
								score += 100;
								Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
								return;
							}
						}
						if (Input.GetKey (KeyCode.R)) {
							if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.E)) {
								Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
								return;
							}
							score += 50;
							Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
							return;
						}
					}
					if (Input.GetKey (KeyCode.R)) {
						if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.E)) {
							Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
							return;
						}
						score += 25;
						Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
						return;
					}
				}
				if (Input.GetKey (KeyCode.R)) {
					Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
					return;
				}
			}
			if (miss.IsTouching (closestr.GetComponent<CircleCollider2D> ())) {
				Destroy (FindClosest (GameObject.FindGameObjectsWithTag ("R_Host")));
			}
		}	
	}
}
