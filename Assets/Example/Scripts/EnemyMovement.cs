using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 5;
    public Collider2D left;
    public Collider2D leftBottom;
    public Collider2D right;
    public Collider2D rightBottom;
    public Collider2D bottom;
    public ContactFilter2D filter;

    Rigidbody2D rigid;
    int direction = -1;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D[] results = new Collider2D[1];
        int contactsLeft = Physics2D.OverlapCollider(left, filter, results);
        int contactsRight = Physics2D.OverlapCollider(right, filter, results);
        int contactsLeftBottom = Physics2D.OverlapCollider(leftBottom, filter, results);
        int contactsRightBottom = Physics2D.OverlapCollider(rightBottom, filter, results);
        int contactsBottom = Physics2D.OverlapCollider(bottom, filter, results);

        if (contactsLeft > 0 || contactsLeftBottom == 0)
        {
            direction = 1;
        }
        if (contactsRight > 0 || contactsRightBottom == 0)
        {
            direction = -1;
        }

        if (contactsBottom > 0)
        {
            rigid.velocity = new Vector2(direction * speed, rigid.velocity.y);
        }
    }
}
