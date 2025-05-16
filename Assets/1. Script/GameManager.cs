using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Stage[] stages;
    public Stage curStage;
    public Stage nextStage;

    public float timer = 0f;
    public Image timerBar;

    


    public bool onGaming = false;

    public bool allCleared = false;

    public void Start()
    {
        stages = GetComponentsInChildren<Stage>();

        //유저가 가지고 있는 curStage 변수의 값을 활용해서 켠다!!
        int index = User.Instance.curStageLevel;

        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].gameObject.SetActive(false);

            if (index == stages[i].stageLevel)
            {
                // 몇번째 스테이지를 켜는지 알게됨. 
                stages[i].gameObject.SetActive(true);

                curStage = stages[i];

                // 해당 스테이지에 있는 시그널 정보들을 실행시켜야함.
                stages[i].SpawnSignals();
                
            }
        }
        // 게임 진행 시작
        onGaming = true;
    }



    public void Update()
    {
        if (onGaming == true)
        {
            // 시간의 흐름
            timer += Time.deltaTime;

            timerBar.fillAmount = (curStage.stageData.timeLimit - timer) / curStage.stageData.timeLimit;



            // 현재 생성된 모든 시그널큐브들의 clear 상태가 true일때,
            // 이말인 즉슨 Stage에 있는 cubeLists 에 담겨 있는 모든 시그널큐브들의 clear 상태가 true 일때

            if (timer >= curStage.stageData.timeLimit)
            {
                GameOver();

                onGaming = false;
            }
        }
    }

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    // 다음 스테이지로 넘어가게끔 만들어야함.
    public void StageClear()
    {
        Debug.Log("스테이지 클리어 성공");

        ResultCanvas.Instance.ShowResult(true);

        //현재 스테이지 비활성화
        curStage.gameObject.SetActive(false);

        //타이머 리셋
        timer = 0f;
        timerBar.fillAmount = 1f;

        

    }


    // 미션 실패 시 게임오버 - 로비로 갈것인가 재도전인가
    public void GameOver()
    {
        Debug.Log("클리어 실패");
        ResultCanvas.Instance.ShowResult(false);
        onGaming = false;
    }

    public void GoNextStage()
    {
        //다음 스테이지 찾기
        int nextLevel = curStage.stageLevel + 1;

        for (int i = 0; i < stages.Length; i++)
        {
            if (stages[i].stageLevel == nextLevel)
            {
                nextStage = stages[i];

            }
        }

        //다음 스테이지 실행
        if (nextStage != null)
        {
            curStage = nextStage;
            curStage.gameObject.SetActive(true);
            curStage.SpawnSignals();

            onGaming = true;

            allCleared = false;
        }
    }

    public void CheckClear()
    {
        allCleared = true;

        for (int i = 0; i < curStage.cubeLists.Count; i++)
        {
            if (curStage.cubeLists[i].clear == false)
            {
                allCleared = false;
                break;
            }

        }


        if (allCleared == true)
        {
            StageClear();
        }
    }


}
