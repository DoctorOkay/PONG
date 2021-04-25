using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{

    private static int winningScore = 5;

    public static void ScorePoint (Paddle paddle, Ball ball)
    {
        paddle.score++;
        Debug.Log(paddle.ToString() + " score: " + paddle.score.ToString());

        if (paddle.score >= Game.winningScore)
        {
            Debug.Log(paddle.ToString() + " won!");
        }

        ResetBall(ball);
    }

    public static void ResetBall(Ball ball)
    {
        ball.transform.position = Vector3.zero;
    }
}
