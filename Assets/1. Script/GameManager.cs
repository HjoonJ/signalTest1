using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Stage[] stages;

    public void Start()
    {
        stages = GetComponentsInChildren<Stage>();

        //������ ������ �ִ� curStage ������ ���� Ȱ���ؼ� �Ҵ�!!
        int index = User.Instance.curStage;

        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].gameObject.SetActive(false);

            if (index == stages[i].stageLevel)
            {
                // ���° ���������� �Ѵ��� �˰Ե�. 
                stages[i].gameObject.SetActive(true);

                // �ش� ���������� �ִ� �ñ׳� �������� ������Ѿ���.
                stages[i].SpawnSignals();
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

    }


    // �̼� ���� �� ���ӿ��� - �κ�� �����ΰ� �絵���ΰ�
    public void GameOver()
    {

    }


}
