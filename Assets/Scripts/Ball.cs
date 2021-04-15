using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed = 10f;

    Vector2 ballVel;
    Vector3 screenMin;
    Vector3 screenMax;

    // Start is called before the first frame update
    void Start()
    {
        ballVel = new Vector2();
        ballVel.x = Random.Range((ballSpeed / 2), ballSpeed);
        ballVel.y = Random.Range((ballSpeed / 2), ballSpeed);

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
        // step 1: move the ball
        Vector2 newBallPos = new Vector2();

        newBallPos.x = transform.position.x + (ballVel.x * Time.deltaTime);
        newBallPos.y = transform.position.y + (ballVel.y * Time.deltaTime);

        float ballWidth = GetComponent<SpriteRenderer>().size.x / 2;
        float ballHeight = GetComponent<SpriteRenderer>().size.y;

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
