//This is the ball script
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    public float speed = 5;
    public Text scorerightText;
	public Text scoreleftText;
	int scoreRight;
	int scoreLeft;
    Vector2 startPos = new Vector2(0f, -1.08f);

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
    // ascii art:
    // ||  1 <- at the top of the racket
    // ||
    // ||  0 <- at the middle of the racket
    // ||
    // || -1 <- at the bottom of the racket
    return (ballPos.y - racketPos.y) / racketHeight;
}

    void Start() {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }

    void OnCollisionEnter2D(Collision2D col) {
  
  
    // Note: 'col' holds the collision information. If the
    // Ball collided with a racket, then:
    //   col.gameObject is the racket
    //   col.transform.position is the racket's position
    //   col.collider is the racket's collider

    // Hit the left Racket?
    if (col.gameObject.name == "player1") 
	{
        speed = speed + 0.5f;
        // Calculate hit Factor
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    // Hit the right Racket?
    if (col.gameObject.name == "player2") {
        // Calculate hit Factor
        speed = speed + 0.5f;
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(-1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
    if (col.gameObject.name == "wallRight") {

            speed = 5f;
			//this line will just add 1 point to the score
			scoreLeft ++;
			//this line will convert the int score variable to a string variable
			scoreleftText.text = scoreLeft.ToString();
            transform.position = startPos;
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

	}
    if (col.gameObject.name == "wallLeft") {
            speed = 5f;
			scoreRight ++;
			scorerightText.text = scoreRight.ToString();
            transform.position = startPos;
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;


	}
}
}
