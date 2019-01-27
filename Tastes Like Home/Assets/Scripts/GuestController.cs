using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestController : MonoBehaviour
{	
	// Amount that the guest moves per frame
	public float MoveSpeed;

	public int race;

	public int color;

	public Vector2 exit;

	// Position that the guest is currently headed to
	private Vector2 dest;

	// Detour position that the guest heads toward when the path is blocked
	private Vector2 roundabout;

	private int personality;

	private int typeOfGuest;

	private Animator animator;

	public bool served;

	public bool leave;

	private bool leftChair;

    // Start is called before the first frame update
    void Start()
    {
		dest = GameObject.Find("Bar").transform.position;
		animator = GetComponent<Animator>();
		animator.SetInteger("Race", race);
		animator.SetInteger("Color", color);
		animator.SetBool("AtChair", false);
		animator.SetBool("ChairOnLeft", true);
		animator.SetInteger("MovementDirection_X", 1);
		animator.SetInteger("MovementDirection_Y", 0);
		served = false;
    }

	// Update is called once per frame
	void Update () 
	{
		// Guest's current position
		Vector2 posn = transform.position;

		if (leave) {
			dest = exit;
			if (posn == exit) {
				Destroy(gameObject);
			}
		}

		// Distance between the guest's current position and destination
		Vector2 dist = dest - posn;

		RaycastHit2D hit = Physics2D.Raycast(posn, dist, MoveSpeed);

		if (hit)
		{
			// If the roundabout was set in a previous loop, head towards there instead of searching for a new one.
			if (roundabout == Vector2.zero || roundabout == posn) {
				gameObject.transform.position = calculateDetour(posn, dist);
			} else {
				gameObject.transform.position = Vector2.MoveTowards(posn, roundabout, MoveSpeed);
			}
		} else {
			// If path is unblocked, move straight toward destination
			gameObject.transform.position = Vector2.MoveTowards(posn, dest, MoveSpeed);
			roundabout = Vector2.zero;
		}

		/* If bar is reached, go to a random chair
		 * This a placeholder and should be replaced with code that keeps the 
		 * guest in place at the bar until they are served tea, then before heading to a
		 * random chair, make sure that the chair has not already been taken by another guest.
		 * 
		 * After this, there needs to be some code to make the guest head to the door and despawn
		 * once their job is done.
		 * */
		if (posn.x == GameObject.Find("Bar").transform.position.x && served) {
			int rando = (int)(Random.value*5);

			switch(rando)
			{
				case 0:
					dest = new Vector2(-8.5f, -1.8f);
					leftChair = true;
					break;
				case 1:
					dest = new Vector2(-5.5f, -1.8f);
					leftChair = false;
					break;
				case 2:
					dest = new Vector2(-4.5f, 1.45f);
					leftChair = true;
					break;
				case 3:
					dest = new Vector2(-1.5f, 1.45f);
					leftChair = false;
					break;
				case 4:
					dest = new Vector2(-2.5f, -3.21f);
					leftChair = true;
					break;
				case 5:
					dest = new Vector2(0.5f, -3.21f);
					leftChair = false;
					break;
				default:
					dest = new Vector2(0f,0f);
					print("ERROR: Error finding chair");
					break;
			}
		}

		if(dest.x > transform.position.x) {
			animator.SetInteger("MovementDirection_X", 1);
			GetComponent<SpriteRenderer>().flipX = true;
		} else if(dest.x < transform.position.x) {
			animator.SetInteger("MovementDirection_X", -1);
			GetComponent<SpriteRenderer>().flipX = false;
		} else {
			animator.SetInteger("MovementDirection_X", 0);
		}

		if(served && dist == Vector2.zero && transform.position != GameObject.Find("Bar").transform.position) {
			animator.SetBool("AtChair", true);
			animator.SetInteger("MovementDirection_X", 0);
			GetComponent<SpriteRenderer>().flipX = leftChair;
		} else {
			animator.SetBool("AtChair", false);
		}
	}

	// Calculates a detour for the guest to take when their path is blocked
	private Vector2 calculateDetour(Vector2 posn, Vector2 dist) {
		// List for distances to destination
		List<float> dlist = new List<float>();

		Vector2 v1 = posn + new Vector2(-MoveSpeed, 0);
		float d1 = Mathf.Abs(Vector2.Distance(dest, v1));
		if(!Physics2D.Raycast(posn, v1 - posn, MoveSpeed*20f)) {
			dlist.Add(d1);
		}

		Vector2 v2 = posn + new Vector2(-MoveSpeed*0.7f, MoveSpeed*0.7f);
		float d2 = Mathf.Abs(Vector2.Distance(dest, v2));
		if(!Physics2D.Raycast(posn, v2 - posn, MoveSpeed*14f)) {
			dlist.Add(d2);
		}

		Vector2 v3 = posn + new Vector2(-MoveSpeed*0.7f, -MoveSpeed*0.7f);
		float d3 = Mathf.Abs(Vector2.Distance(dest, v3));
		if(!Physics2D.Raycast(posn, v3 - posn, MoveSpeed*14f)) {
			dlist.Add(d3);
		}

		Vector2 v4 = posn + new Vector2(0, MoveSpeed);
		float d4 = Mathf.Abs(Vector2.Distance(dest, v4));
		if(!Physics2D.Raycast(posn, v4 - posn, MoveSpeed*20f)) {
			dlist.Add(d4);
		}

		Vector2 v5 = posn + new Vector2(0, -MoveSpeed);
		float d5 = Mathf.Abs(Vector2.Distance(dest, v5));
		if(!Physics2D.Raycast(posn, v5 - posn, MoveSpeed*20f)) {
			dlist.Add(d5);
		}

		// Find shortest distance
		float min = Mathf.Min(dlist.ToArray());

		// Set the roundabout determined by shortest distance
		if (min == d1) {
			roundabout = posn + new Vector2(-MoveSpeed*20f,0f);
			return Vector2.MoveTowards(posn, v1, MoveSpeed);
		} else if (min == d2) {
			roundabout = posn + new Vector2(-MoveSpeed*14f,MoveSpeed*14f);
			return Vector2.MoveTowards(posn, v2, MoveSpeed);
		} else if (min == d3) {
			roundabout = posn + new Vector2(-MoveSpeed*14f,MoveSpeed*14f);
			return Vector2.MoveTowards(posn, v3, MoveSpeed);
		} else if (min == d4) {
			roundabout = posn + new Vector2(0,MoveSpeed*20f);
			return Vector2.MoveTowards(posn, v4, MoveSpeed);
		} else if (min == d5) {
			roundabout = posn + new Vector2(0,-MoveSpeed*20f);
			return Vector2.MoveTowards(posn, v5, MoveSpeed);
		} else {
			print("ERROR: Detour finding failure");
			return Vector2.zero;
		}

	}
}
