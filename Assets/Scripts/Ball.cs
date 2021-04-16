using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 10f;
    [SerializeField] private Paddle playerPaddle;

    Vector2 ballVel;
    Vector3 screenMin;
    Vector3 screenMax;

    // Start is called before the first frame update
    void Start()
    {
        ballVel = new Vector2();
        ballVel.x = Random.Range(-ballSpeed, ballSpeed);
        ballVel.y = Random.Range(-ballSpeed, ballSpeed);

        screenMin = Camera.main.ScreenToWorldPoint(Vector3.zero);
        screenMax = new Vector3(Screen.width, Screen.height, 0);
        screenMax = Camera.main.ScreenToWorldPoint(screenMax);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        
        Vector2 newBallPos = new Vector2();
        Vector2 playerPaddlePos = playerPaddle.transform.position;

        // step 1: move the ball
        newBallPos.x = transform.position.x + (ballVel.x * Time.deltaTime);
        newBallPos.y = transform.position.y + (ballVel.y * Time.deltaTime);

        float ballWidth = GetComponent<SpriteRenderer>().size.x / 2;
        float ballHeight = GetComponent<SpriteRenderer>().size.y / 2;

        float playerPaddleWidth = playerPaddle.GetComponent<SpriteRenderer>().size.x / 2;
        float playerPaddleHeight = playerPaddle.GetComponent<SpriteRenderer>().size.y / 2;

        Vector2 playerPaddleMin = new Vector2();
        Vector2 playerPaddleMax = new Vector2();

        playerPaddleMin.x = playerPaddle.transform.position.x - playerPaddleWidth;
        playerPaddleMin.y = playerPaddle.transform.position.y - playerPaddleHeight;

        playerPaddleMax.x = playerPaddle.transform.position.x + playerPaddleWidth;
        playerPaddleMax.y = playerPaddle.transform.position.y + playerPaddleHeight;

        // step 2: check for potential player paddle collision and adjust ball position
        if (newBallPos.x > playerPaddleMin.x && newBallPos.x < playerPaddleMax.x)
        {
            if (newBallPos.y > playerPaddleMin.y && newBallPos.y < playerPaddleMax.y)
            {
                newBallPos.x = playerPaddlePos.x + ballWidth;
                ballVel.x = -ballVel.x;
            }
        }


        // step 2: bounce ball around the screen
        if (newBallPos.x < screenMin.x)
        {
            // place the ball on the screen edge and reverse the velocity
            newBallPos.x = screenMin.x + ballWidth;
            ballVel.x = -ballVel.x;
        }
        if (newBallPos.x > screenMax.x)
        {
            // place the ball on the screen edge and reverse the velocity
            newBallPos.x = screenMax.x - ballWidth;
            ballVel.x = -ballVel.x;
        }
        if (newBallPos.y < screenMin.y)
        {
            // place the ball on the screen edge and reverse the velocity
            newBallPos.y = screenMin.y + ballHeight;
            ballVel.y = -ballVel.y;
        }
        if (newBallPos.y > screenMax.y)
        {
            // place the ball on the screen edge and reverse the velocity
            newBallPos.y = screenMax.y - ballHeight;
            ballVel.y = -ballVel.y;
        }

        newBallPos.x = transform.position.x + (ballVel.x * Time.deltaTime);
        newBallPos.y = transform.position.y + (ballVel.y * Time.deltaTime);
        transform.position = newBallPos;
    }
}
