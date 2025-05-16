using UnityEngine;
using System.Linq;
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    public StageData[] stageDatas;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        // 리소시스 폴더 안 스테이지 데이터를 자동으로 참조 및 스테이지 레벨에 따른 배열하기. 
        stageDatas = Resources.LoadAll<StageData>("StageData");
        stageDatas = stageDatas.OrderBy(e =>e.stageLevel).ToArray();
        DontDestroyOnLoad(gameObject);

    }
}
