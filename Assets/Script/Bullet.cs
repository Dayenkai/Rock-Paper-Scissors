using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
	public int damage = 20;
	public string type;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        Vector2 direction = gameObject.transform.position - Camera.main.ScreenToWorldPoint( Input.mousePosition );
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		PlayerController enemy = hitInfo.GetComponent<PlayerController>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage,type);
		}

		if(hitInfo.gameObject.layer != 9) Destroy(gameObject);
	}
}
