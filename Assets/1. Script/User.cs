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
        //데이터 로드 
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

    //클리어 시 현재 스테이지 레벨 + 별 개수를 얻어서 UserData에 저장시키기. 
    // 현재 스테이지 레벨은 GameManager.Instance.curStage.stageLevel
    //curStageLevel;
    public void SaveClearStage(int stageLv, int starCount, bool clear)
    {
        if (clear == false)
        {
            return;
        }

        //덮어쓰기? (기존 데이터 상황 파악 후)
        //1. 리스트 중에 같은 스테이지 레벨이 있는지 찾기
        //2. 같은 스테이지 레벨을 찾았으면, 그 리스트의 스타카운트 값을 비교해서 더 높은 값으로 저장.
        
        // 기존에 리스트에 무언가 담겨 있을 경우
        for (int i = 0; i < userData.userStages.Count; i++) 
        { 
            if (userData.userStages[i].stageLevel == stageLv)
            {
                if (userData.userStages[i].starCount < starCount)
                {

                    userData.userStages[i].starCount = starCount;
                    
                    SaveManager.SaveData<UserData>("userData", userData);
                }

                //함수를 즉시 종료
                return;


            }
            
        
        }

        // 리스트에 해당 레벨이 담겨 있지 않을 때



        UserStage stage = new UserStage();

        stage.stageLevel = stageLv;
        stage.starCount = starCount;
        
        userData.userStages.Add(stage);

        SaveManager.SaveData<UserData>("userData", userData);

        //현재 스테이지 레벨 +별 개수
        //UserStage 객체에 담아서
        //UserData 객체의 UserStages 리스트에 담아서
        //SaveManager로 저장시키기.

    }

}

[System.Serializable] //직렬화(객체) + 이 클래스로 만들어진 객체를 인스펙터 창에 표현해 줌.
public class UserData
{
    // 1. 유저가 어떤 스테이지까지 클리어 했는가
    // 2. 클리어한 스테이지에서 별을 몇개나 받았는가

    public List<UserStage> userStages = new List<UserStage>();
}

[System.Serializable]
public class UserStage
{
    public int stageLevel;
    public int starCount;
}