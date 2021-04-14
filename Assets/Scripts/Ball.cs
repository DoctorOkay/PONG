using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed = 10f;
    [SerializeField] Paddle playerPaddle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // just move it to the left to start
        Vector2 newBallPos = new Vector2();

        float scaledBallSpeed = ballSpeed * Time.deltaTime;

        newBallPos.x = transform.position.x - scaledBallSpeed;
        newBallPos.y = transform.position.y;

        /* for collision all of these need to be true
         * ballLeft > paddleRight
         * ballRight < paddleLeft
         * ballTop > paddleBottom
         * ballBottom < paddleTop
         */


        transform.position = newBallPos;
    }
}
