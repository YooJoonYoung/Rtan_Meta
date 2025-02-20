using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


    //GameUI�� BaseUI�� ��ӹ޾� ���� ȭ�� UI�� ó���ϴ� Ŭ����
    public class GameUI : BaseUI
    {
        TextMeshProUGUI scoreText;
        TextMeshProUGUI highscoreText;

        
        protected override UIState GetUIState() // ���� UI ���°� "Game" �������� ��ȯ�ϴ� �޼���

        {
            return UIState.Game; // ���� UI ���°� 'Game'���� ��ȯ
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
