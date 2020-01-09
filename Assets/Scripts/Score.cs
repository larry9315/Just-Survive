using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static float score = 0f;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = "Score: " + ((int) score).ToString();
    }

    public static void incrementKill()
    {
        score += 100f;
    }

    public static float getScore()
    {
        return score;
    }
}
