using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    int score;
    public TMP_Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "0";
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ball")
        {
            score++;
            ScoreText.text = score.ToString();
        }
    }
}
