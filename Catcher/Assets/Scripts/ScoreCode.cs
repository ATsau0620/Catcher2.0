using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class ScoreCode : MonoBehaviour

{

    //宣告分數參數

    public static int Score;

    //宣告文字UI

    public Text ShowScore;

    void Start()
    {
        Score = 0;
    }

    void Update()

    {

        //讓UI文字與分數同步

        ShowScore.text = Score.ToString();

    }

}