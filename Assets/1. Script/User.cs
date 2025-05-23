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

            // 생략가능?
            userData = new UserData();
        }

    }

    public void Start()
    {
        //데이터 로드 
        userData = SaveManager.LoadData<UserData>("userData");

        if (userData == null) 
        {
            userData = new UserData();


        }

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

[System.Serializable]
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