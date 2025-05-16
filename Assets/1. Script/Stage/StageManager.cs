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

        // ���ҽý� ���� �� �������� �����͸� �ڵ����� ���� �� �������� ������ ���� �迭�ϱ�. 
        stageDatas = Resources.LoadAll<StageData>("StageData");
        stageDatas = stageDatas.OrderBy(e =>e.stageLevel).ToArray();
        DontDestroyOnLoad(gameObject);

    }
}
