using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultCanvas : MonoBehaviour
{
    // 비활성화 되어 있는 게임오브젝트의 싱글톤 가져오기

    // 1. 몇 스테이지인가 - StageManager.Instance.stageDatas[i]
    // 2. 총 타임리밋(스테이지데이터) - StageManager.Instance.stageDatas[i].timeLimit
    // 3. 타임스텝 배열 (배열0 번째, 1번째를 인식)
    // 4. 현재 흐른 시간 timer
    // 5. 스타 이미지 표시 

    private static ResultCanvas instance; //변수
    public static ResultCanvas Instance //속성 = 변수 + 함수
    {
        get 
        {
            if (instance == null)
                instance = FindFirstObjectByType<ResultCanvas>(FindObjectsInactive.Include);
            
            return instance;
        } 
    }

    public TMP_Text resultText;
    public Button nextBtn;
    public Button retryBtn;

    public int starCount;

    public Image[] starImages;

 

    public void ShowResult(bool clear)
    {
        //현재 스테이지데이터
        StageData curStageData = StageManager.Instance.GetStageData(User.Instance.curStageLevel);
        //현재 흐른 시간
        float curTimer = GameManager.Instance.timer;

        //1.배열을 통해서 starCount 변수 결정하기
        //2.스테이지의 클리어 시 획득한 별 개수 저장하기


        //***이부분에서 에러 발생!!

        gameObject.SetActive(true);

        for (int i = 0; starImages.Length > 0; i++)
        {
            starImages[i].gameObject.SetActive(false);
        }


        starCount = 1;
        for (int i = 0; i < curStageData.timeStep.Length; i++)
        { 
            if (curStageData.timeStep[i] >= curTimer)
            {
                //starCount = 3 - i;
                // 별 3개
                if (i == 0)
                {
                    starCount = 3;
                }
                // 별 2개
                else if (i == 1)
                {
                    starCount = 2;
                
                }


                break;

            }
        
        }

        //starCount 값에 따라서 스타 이미지 표시 UI 처리하기.

        //gameObject.SetActive(true);

        if (clear == true)
        {
            resultText.text = "Clear!";

            // for 문으로 짜보기.
            //for (int i = 0; i < starCount; i++)
            //{
            //    starImages[i].gameObject.SetActive(true);
            //}

            if (starCount == 3) 
            {
                starImages[0].gameObject.SetActive(true);
                starImages[1].gameObject.SetActive(true);
                starImages[2].gameObject.SetActive(true);
            }
            else if (starCount == 2)
            {
                starImages[0].gameObject.SetActive(true);
                starImages[1].gameObject.SetActive(true);
            }
            else if (starCount == 1)
            {
                starImages[0].gameObject.SetActive(true);
            }

            nextBtn.gameObject.SetActive(true);
            retryBtn.gameObject.SetActive(false);
        }
        else
        {
            resultText.text = "Fail!";
            retryBtn.gameObject.SetActive(true);
            nextBtn.gameObject.SetActive(false);
        }

        // 유저데이터 저장하기.
        User.Instance.SaveClearStage(curStageData.stageLevel, starCount, clear);

    }

    public void OnClickedLobby()
    {
        SceneManager.LoadScene("Lobby");

        gameObject.SetActive(false);
    }

    public void OnClickedNext()
    {
        User.Instance.curStageLevel++;
        SceneManager.LoadScene("InGame");

     

        //GameManager.Instance.GoNextStage();
        //gameObject.SetActive(false);

    }

    public void OnClickedRetry()
    {
        SceneManager.LoadScene("InGame");

        for (int i = 0; starImages.Length > 0; i++)
        {
            starImages[i].gameObject.SetActive(false);

        }
    }

   

}
