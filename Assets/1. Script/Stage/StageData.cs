using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Scriptable Objects/StageData")]
public class StageData : ScriptableObject
{
    public int stageLevel;
    public float timeLimit;

    public StageSignalInfo[] signalInfos; 

    public Vector3 minPosition;
    public Vector3 maxPosition;
}
