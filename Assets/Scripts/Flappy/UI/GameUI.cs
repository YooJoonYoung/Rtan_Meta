using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


    //GameUI는 BaseUI를 상속받아 게임 화면 UI를 처리하는 클래스
    public class GameUI : BaseUI
    {
        TextMeshProUGUI scoreText;
        TextMeshProUGUI highscoreText;

        
        protected override UIState GetUIState() // 현재 UI 상태가 "Game" 상태임을 반환하는 메서드

        {
            return UIState.Game; // 현재 UI 상태가 'Game'임을 반환
        }

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);
            scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            highscoreText = transform.Find("HighScoreText").GetComponent<TextMeshProUGUI>();

        }


        public void SetUI(int score, int highscore)
        {
            scoreText.text = score.ToString();
            highscoreText.text = highscore.ToString();

        }
    }
