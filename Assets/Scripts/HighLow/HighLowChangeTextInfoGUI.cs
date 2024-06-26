using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace KazukiTrumpGame.HighLow
{
    /// <summary>
    /// 勝敗の判定を表示させるクラス
    /// </summary>
    public class HighLowChangeTextInfoGUI : MonoBehaviour
    {
        HighLowSceneDirector sceneDirector;

        [SerializeField]
        TextMeshProUGUI textInfo;

        void Start()
        {
            sceneDirector = GameObject.FindGameObjectWithTag("GameDirector").GetComponent<HighLowSceneDirector>();
            
            //登録
            sceneDirector.OnJudgeTypeChanged += HandleJudgeTypeChanged;
        }

        private void OnDestroy()
        {
            //解除
            sceneDirector.OnJudgeTypeChanged -= HandleJudgeTypeChanged;
        }

        //登録するメソッド
        void HandleJudgeTypeChanged(JudgeType newJudge)
        {
            switch (newJudge)//判定により処理を変える
            {
                case JudgeType.WIN://勝ち
                    TextAnimation.ResultTextAnimation(textInfo,CardsDirector.Instance.WIN_COLOR, "YOU WIN!!");
                    break;
                case JudgeType.LOSE://負け
                    TextAnimation.ResultTextAnimation(textInfo, CardsDirector.Instance.LOSE_COLOR, "YOU LOSE...");
                    break;
                case JudgeType.DRAW://引き分け
                    TextAnimation.ResultTextAnimation(textInfo, CardsDirector.Instance.DRAW_COLOR, "DRAW");
                    break;
                case JudgeType.INITIAL://初期
                    textInfo.text = "";
                    break;
            }
        }
    }
}
