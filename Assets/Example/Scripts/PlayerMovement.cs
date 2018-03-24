using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float acceleration = 1000;
    public float maxSpeed = 5;
    public Collider2D left;
    public Collider2D right;
    public ContactFilter2D filter;

    Rigidbody2D rigid;

    // Use this for initialization
    void Start () {
        rigid = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D[] results = new Collider2D[1];
        int contactsLeft = Physics2D.OverlapCollider(left, filter, results);
        int contactsRight = Physics2D.OverlapCollider(right, filter, results);
        if (contactsLeft == 0 && Input.GetAxis("Horizontal") < 0 || contactsRight == 0 && Input.GetAxis("Horizontal") > 0)
        {
            float horizontal = Input.GetAxis("Horizontal") * acceleration * Time.deltaTime;
            rigid.AddForce(new Vector2(horizontal, 0));
            if (Mathf.Abs(rigid.velocity.x) > maxSpeed)
            {
                rigid.velocity = new Vector2(Mathf.Sign(rigid.velocity.x) * maxSpeed, rigid.velocity.y);
            }
        }

	}
}
