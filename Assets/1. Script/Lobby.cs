using UnityEngine;
using UnityEngine.SceneManagement;
public class Lobby : MonoBehaviour
{
    int curStageLevel;
    int endStageLevel;

    private void Start()
    {
        curStageLevel = 1;

        endStageLevel = StageManager.Instance.stageDatas[StageManager.Instance.stageDatas.Length-1].stageLevel;

    }
    public void OnClickedBtn()
    {
        SceneManager.LoadScene("InGame");

    }


}
