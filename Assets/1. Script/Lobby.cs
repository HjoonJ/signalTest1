using UnityEngine;
using UnityEngine.SceneManagement;
public class Lobby : MonoBehaviour
{
    int curStageLevel;
    int endStageLevel;

    //클리어한 스테이지만 담겨있음
    //User.Instance.userData.userStages

    //로비 화면에 화살표와 클리어한 스테이지 띄우기 + 클리어한 스테이지 다음 거도 같이 띄우기 

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
