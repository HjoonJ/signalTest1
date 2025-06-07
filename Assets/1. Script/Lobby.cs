using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Lobby : MonoBehaviour
{
    int endStageLevel;

    //클리어한 스테이지만 담겨있음
    //User.Instance.userData.userStages

    //로비 화면에 화살표와 클리어한 스테이지 띄우기 + 클리어한 스테이지 다음 거도 같이 띄우기 

    public TMP_Text stageLevelText;
    public Button leftBtn;
    public Button rightBtn;

    private void Start()
    {

        
        endStageLevel = StageManager.Instance.stageDatas[StageManager.Instance.stageDatas.Length-1].stageLevel;

        UpdateLobby();
    }

    // 레벨 1일때 오른쪽 버튼만 남기기.
    void UpdateLobby()
    {
        leftBtn.gameObject.SetActive(true);
        rightBtn.gameObject.SetActive(true);
        
        if (User.Instance.curStageLevel == 1)
        {
            leftBtn.gameObject.SetActive(false);
        }
        if (User.Instance.curStageLevel == User.Instance.GetLastStage())
        {
            rightBtn.gameObject.SetActive(false);
        }

        stageLevelText.text = User.Instance.curStageLevel.ToString();
    }

    public void OnClickedLeftBtn()
    {
        User.Instance.curStageLevel--;
        UpdateLobby();

    }

    public void OnClickedRightBtn()
    {
        User.Instance.curStageLevel++;
        UpdateLobby();

    }

    public void OnClickedBtn()
    {
        SceneManager.LoadScene("InGame");

    }


}
