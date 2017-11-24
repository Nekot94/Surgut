using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    Rigidbody2D myBody;

    public float speed = 10;

    public int score;
    GameController gameController;

	void Start()
	{
        myBody = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	void Update()
	{
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        myBody.AddForce(new Vector2(horizontal, vertical));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem")
        {
            gameController.ChangeScore(++score);
            Destroy(collision.gameObject);
        }
    }

}
