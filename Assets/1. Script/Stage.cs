using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int stageLevel;
    public float timeLimit;

    public StageSignalInfo[] signalInfos; //�������� �� �����ؾ��� �ñ׳ε� ����

    public GameObject[] signalPrefabs; // 4���� �ñ׳� �������� ���� ����

    public List<Signal> cubeLists;

    public Vector3 minPosition;
    public Vector3 maxPosition;

    private void Awake()
    {
        cubeLists = new List<Signal>();
    }


    public void SpawnSignals()
    {
        // �Ź� ������ �� ���� �����ʹ� Ŭ�����ϱ�
        cubeLists.Clear();

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

                        // ���� �� signalCube�� ���.
                        GameObject signalCube = Instantiate(signalPrefabs[j]);

                        //cubeLists ������ ������ ť��� ���. 

                        Signal spawnedSignal = signalCube.GetComponent<Signal>();
                        
                        if (spawnedSignal != null)
                        {
                            cubeLists.Add(spawnedSignal);

                        }

                        signalCube.transform.position = spawnPos;

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
