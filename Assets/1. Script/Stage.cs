using UnityEngine;

public class Stage : MonoBehaviour
{
    public int stageLevel;
    public float timeLimit;
    public StageSignalInfo[] signalInfos; //�������� �� �����ؾ��� �ñ׳ε� ����

    public GameObject[] signalPrefabs; // 4���� �ñ׳� �������� ���� ����

    public Vector3 minPosition;
    public Vector3 maxPosition;

    // �̹� i ��° ���������� ���ӸŴ��� start �Լ����� ���� ��
    // 
    public void SpawnSignals()
    {
        for (int i = 0; i < signalInfos.Length; i++)
        {
            
            // �������� signalInfos �� �ϳ� �����ϱ�
            StageSignalInfo info = signalInfos[i];

            for (int j = 0; j < signalPrefabs.Length; j++)
            {
                
                
                Signal signalPreb = signalPrefabs[j].GetComponent<Signal>();

                // � �������� ������ų�� key �� ���� ã��
                if (signalPreb.key == info.signalKey)
                {

                    // count ����ŭ ����
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
