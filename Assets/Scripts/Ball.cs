using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Vector2 initialVelocity;
    [SerializeField] Paddle[] paddles;
    [SerializeField] float scaleY;

    bool isLaunched;
    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLaunched)
        {
            MoveBall();
        }
        if (!isLaunched)
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = initialVelocity;
            isLaunched = true;
        }
    }

    void StopBall()
    {
        isLaunched = false;
        velocity = Vector2.zero;
    }

    void MoveBall()
    {
        // calculate the future position of the ball
        Vector2 scaledVelocity = velocity * Time.deltaTime;
        Vector2 newBallPos = (Vector2)transform.position + scaledVelocity;

        Vector3 bottomScreenCorner = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 topScreenCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        Bounds collisionBox = GetComponent<SpriteRenderer>().bounds;

        // check for screen edge collisions
        if (newBallPos.x + collisionBox.extents.x < bottomScreenCorner.x)
        {
            Paddle scoringPaddle = GetFarthestPaddle(paddles[0], paddles[1]);
            StopBall();
            Game.ScorePoint(scoringPaddle, this);
        }
        if (newBallPos.x + collisionBox.extents.x > topScreenCorner.x)
        {
            Paddle scoringPaddle = GetFarthestPaddle(paddles[0], paddles[1]);
            StopBall();
            Game.ScorePoint(scoringPaddle, this);
        }
        if (newBallPos.y - collisionBox.extents.y < bottomScreenCorner.y)
        {         
            velocity.y = -velocity.y;
            transform.position = new Vector2(transform.position.x, (bottomScreenCorner.y + collisionBox.extents.y));
        }
        if (newBallPos.y + collisionBox.extents.y > topScreenCorner.y)
        {         
            velocity.y = -velocity.y;
            transform.position = new Vector2(transform.position.x, (topScreenCorner.y - collisionBox.extents.y));
        }

        // check for paddle collisions
        for (int i = 0; i < paddles.Length; i++)
        {
            Bounds paddleBounds = paddles[i].GetComponent<SpriteRenderer>().bounds;

            // check for ball/paddle collision
            bool colliding = collisionBox.min.x < paddleBounds.max.x &&
                             collisionBox.max.x > paddleBounds.min.x &&
                             collisionBox.min.y < paddleBounds.max.y &&
                             collisionBox.max.y > paddleBounds.min.y;

            if (colliding)
            {
                velocity.x = -velocity.x;
                velocity.y = (collisionBox.center.y - paddleBounds.center.y) * scaleY;
            }
        }

        // move the ball
        scaledVelocity = velocity * Time.deltaTime;
        transform.Translate(new Vector3(scaledVelocity.x, scaledVelocity.y));
    }

    Paddle GetFarthestPaddle(Paddle paddle1, Paddle paddle2)
    {
        float distance1 = Vector3.Distance(transform.position, paddle1.transform.position);
        float distance2 = Vector3.Distance(transform.position, paddle2.transform.position);

        if (distance1 > distance2)
        {
            return paddle1;
        }
        else
        {
            return paddle2;
        }
    }

}
