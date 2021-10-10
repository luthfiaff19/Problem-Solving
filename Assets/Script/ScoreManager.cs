using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text text;
    int score;

    // Akan dipanggil sebelum pembaruan bingkai pertama dimulai
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Ketika titik box di sentuh maka box mengeluarkan score
    public void ChangeScore(int boxValue)
    {
        score += boxValue;
        text.text = "Box = " + score.ToString();
    }
}
