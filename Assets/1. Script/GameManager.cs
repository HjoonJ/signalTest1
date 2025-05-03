using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Stage[] stages;

    public void Start()
    {
        stages = GetComponentsInChildren<Stage>();

        //유저가 가지고 있는 curStage 변수의 값을 활용해서 켠다!!
        int index = User.Instance.curStage;

        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].gameObject.SetActive(false);

            if (index == stages[i].stageLevel)
            {
                // 몇번째 스테이지를 켜는지 알게됨. 
                stages[i].gameObject.SetActive(true);

                // 해당 스테이지에 있는 시그널 정보들을 실행시켜야함.
                stages[i].SpawnSignals();
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

    }


    // 미션 실패 시 게임오버 - 로비로 갈것인가 재도전인가
    public void GameOver()
    {

    }


}
