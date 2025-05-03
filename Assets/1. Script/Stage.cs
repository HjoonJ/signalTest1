using UnityEngine;

public class Stage : MonoBehaviour
{
    public int stageLevel;
    public float timeLimit;
    public StageSignalInfo[] signalInfos; //스테이지 별 포함해야할 시그널들 정보

    public GameObject[] signalPrefabs; // 4개의 시그널 프리펩이 있을 예정

    public Vector3 minPosition;
    public Vector3 maxPosition;

    // 이미 i 번째 스테이지가 게임매니저 start 함수에서 실행 중
    // 
    public void SpawnSignals()
    {
        for (int i = 0; i < signalInfos.Length; i++)
        {
            
            // 여러개의 signalInfos 중 하나 선택하기
            StageSignalInfo info = signalInfos[i];

            for (int j = 0; j < signalPrefabs.Length; j++)
            {
                
                
                Signal signalPreb = signalPrefabs[j].GetComponent<Signal>();

                // 어떤 프리펩을 생성시킬지 key 를 통해 찾기
                if (signalPreb.key == info.signalKey)
                {

                    // count 수만큼 생성
                    for (int k = 0; k < info.count; k++)
                    {
                        Vector3 spawnPos = new Vector3(
                            Random.Range(minPosition.x, maxPosition.x),
                            Random.Range(minPosition.y, maxPosition.y),
                            Random.Range(minPosition.z, maxPosition.z)
                        );


                        Instantiate(signalPrefabs[j], spawnPos, Quaternion.identity);
                    }
                    


                }
            }
            

           


        }
    }

}
[System.Serializable]
public class StageSignalInfo
{
    public string signalKey;
    public int count;
    
}
