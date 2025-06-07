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

        }
        //������ �ε� 
        userData = SaveManager.LoadData<UserData>("userData");

        if (userData == null)
        {
            userData = new UserData();

        }
        curStageLevel = GetLastStage();
    }


    public int GetLastStage()
    {

        int stageLevel = 1;

        for (int i = 0; i < userData.userStages.Count; i++)
        {
            if (userData.userStages[i].starCount > 0)
            {
                stageLevel++;
            }
        }
        return stageLevel;
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
        //1. ����Ʈ �߿� ���� �������� ������ �ִ��� ã��
        //2. ���� �������� ������ ã������, �� ����Ʈ�� ��Ÿī��Ʈ ���� ���ؼ� �� ���� ������ ����.
        
        // ������ ����Ʈ�� ���� ��� ���� ���
        for (int i = 0; i < userData.userStages.Count; i++) 
        { 
            if (userData.userStages[i].stageLevel == stageLv)
            {
                if (userData.userStages[i].starCount < starCount)
                {

                    userData.userStages[i].starCount = starCount;
                    
                    SaveManager.SaveData<UserData>("userData", userData);
                }

                //�Լ��� ��� ����
                return;


            }
            
        
        }

        // ����Ʈ�� �ش� ������ ��� ���� ���� ��



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

[System.Serializable] //����ȭ(��ü) + �� Ŭ������ ������� ��ü�� �ν����� â�� ǥ���� ��.
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