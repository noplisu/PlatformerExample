using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Rigidbody2D rigid = coll.gameObject.GetComponent<Rigidbody2D>();
            if(rigid.velocity.y < 0)
            {
                Destroy(gameObject);
            } else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
