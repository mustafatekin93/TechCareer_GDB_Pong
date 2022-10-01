using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rbBall;
    public ParticleSystem explotionEffect;
    public SpriteRenderer ballSprite;
    public Collider2D ballCollider;
    public TrailRenderer ballTrail;
    public float speed;

    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        Launch();
    }

    void Launch()
    {
        transform.position = Vector2.zero;

        float x;
        float y;

        if (Random.Range(0, 2) == 0)
            x = 1;
        else
            x = -1;

        if (Random.Range(0, 2) == 0)
            y = 1;
        else
            y = -1;

        rbBall.velocity = new Vector2(x * speed, y * speed);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "PlayerCollider")
        {
            rbBall.velocity = Vector2.zero;
            ballTrail.enabled = false;
            ballCollider.enabled = false;
            ballSprite.enabled = false;
            explotionEffect.Play(true);
            StartCoroutine(LaunchAgain());
        }

    }

    IEnumerator LaunchAgain()
    {
        yield return new WaitForSeconds(2);
        ballCollider.enabled = true;
        ballSprite.enabled = true;
        ballTrail.enabled = true;
        Launch();
    }

}
