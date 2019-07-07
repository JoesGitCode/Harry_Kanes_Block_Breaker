using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print(paddleToBallVector.y);
        AudioSource bounce = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) { 
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                print("mouse clicked");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.4f), Random.Range(0f, 0.4f));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
        }

        this.GetComponent<Rigidbody2D>().velocity += tweak;
    }
}
