using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    public float force = 1000;
    public Collider2D feet;
    public ContactFilter2D filter;

    Rigidbody2D rigid;
    bool onGround = false;
	// Use this for initialization
	void Start () {
        rigid = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D[] results = new Collider2D[1];
        int contacts = Physics2D.OverlapCollider(feet, filter, results);
        if(contacts > 0)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
        if (Input.GetButtonDown("Vertical") && onGround)
        {
            rigid.AddForce(new Vector2(0, force));
            onGround = false;
        }
	}
}
