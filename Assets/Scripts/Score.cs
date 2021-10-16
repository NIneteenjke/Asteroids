using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int score;

    public Text text;

    public Color color = new Color (1,1,1,1);

    void Start()
    {
        score = PlayerPrefs.GetInt("score");
    }

    void Update()
    {
        text.text = "Score:" + score;
    }
}
