using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public static User Instance;
    public int curStageLevel;
    
    public UserData userData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // ��������?
            userData = new UserData();
        }

    }

    public void Start()
    {
        //������ �ε� 
        userData = SaveManager.LoadData<UserData>("userData");

        if (userData == null) 
        {
            userData = new UserData();


        }

    }


    //Ŭ���� �� ���� �������� ���� + �� ������ �� UserData�� �����Ű��. 
    // ���� �������� ������ GameManager.Instance.curStage.stageLevel
    //curStageLevel;
    public void SaveClearStage(int stageLv, int starCount, bool clear)
    {
        if (clear == false)
        {
            return;
        }

        //�����? (���� ������ ��Ȳ �ľ� ��)

        UserStage stage = new UserStage();

        stage.stageLevel = stageLv;
        stage.starCount = starCount;
        
        userData.userStages.Add(stage);

        SaveManager.SaveData<UserData>("userData", userData);

        //���� �������� ���� +�� ����
        //UserStage ��ü�� ��Ƽ�
        //UserData ��ü�� UserStages ����Ʈ�� ��Ƽ�
        //SaveManager�� �����Ű��.

    }

}

[System.Serializable]
public class UserData
{
    // 1. ������ � ������������ Ŭ���� �ߴ°�
    // 2. Ŭ������ ������������ ���� ��� �޾Ҵ°�

    public List<UserStage> userStages = new List<UserStage>();
}

[System.Serializable]
public class UserStage
{
    public int stageLevel;
    public int starCount;
}