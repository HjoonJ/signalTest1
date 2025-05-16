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

        //������ ������ �ִ� curStage ������ ���� Ȱ���ؼ� �Ҵ�!!
        int index = User.Instance.curStageLevel;

        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].gameObject.SetActive(false);

            if (index == stages[i].stageLevel)
            {
                // ���° ���������� �Ѵ��� �˰Ե�. 
                stages[i].gameObject.SetActive(true);

                curStage = stages[i];

                // �ش� ���������� �ִ� �ñ׳� �������� ������Ѿ���.
                stages[i].SpawnSignals();
                
            }
        }
        // ���� ���� ����
        onGaming = true;
    }



    public void Update()
    {
        if (onGaming == true)
        {
            // �ð��� �帧
            timer += Time.deltaTime;

            timerBar.fillAmount = (curStage.stageData.timeLimit - timer) / curStage.stageData.timeLimit;



            // ���� ������ ��� �ñ׳�ť����� clear ���°� true�϶�,
            // �̸��� �ｼ Stage�� �ִ� cubeLists �� ��� �ִ� ��� �ñ׳�ť����� clear ���°� true �϶�

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


    // ���� ���������� �Ѿ�Բ� ��������.
    public void StageClear()
    {
        Debug.Log("�������� Ŭ���� ����");

        ResultCanvas.Instance.ShowResult(true);

        //���� �������� ��Ȱ��ȭ
        curStage.gameObject.SetActive(false);

        //Ÿ�̸� ����
        timer = 0f;
        timerBar.fillAmount = 1f;

        

    }


    // �̼� ���� �� ���ӿ��� - �κ�� �����ΰ� �絵���ΰ�
    public void GameOver()
    {
        Debug.Log("Ŭ���� ����");
        ResultCanvas.Instance.ShowResult(false);
        onGaming = false;
    }

    public void GoNextStage()
    {
        //���� �������� ã��
        int nextLevel = curStage.stageLevel + 1;

        for (int i = 0; i < stages.Length; i++)
        {
            if (stages[i].stageLevel == nextLevel)
            {
                nextStage = stages[i];

            }
        }

        //���� �������� ����
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
