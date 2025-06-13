using UnityEngine;
using System.Linq;
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    
    // 각 스테이지들을 만들기 편하게! 정보를 제공하는 데이터들이 각 스테이지 별로 담겨 있는 배열 
    public StageData[] stageDatas; // 현재 스테이지가 몇개 있는지도 알수 있음
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        // 리소시스 폴더 안 스테이지 데이터를 자동으로 참조 및 스테이지 레벨에 따른 배열하기. 
        stageDatas = Resources.LoadAll<StageData>("StageData");
        stageDatas = stageDatas.OrderBy(e =>e.stageLevel).ToArray();
        DontDestroyOnLoad(gameObject);

    }

    public StageData GetStageData(int stageLevel)
    {
        return stageDatas.Where(e => e.stageLevel == stageLevel).FirstOrDefault();
    }
}
