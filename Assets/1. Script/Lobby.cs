using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Lobby : MonoBehaviour
{
    int endStageLevel;

    //Ŭ������ ���������� �������
    //User.Instance.userData.userStages

    //�κ� ȭ�鿡 ȭ��ǥ�� Ŭ������ �������� ���� + Ŭ������ �������� ���� �ŵ� ���� ���� 

    public TMP_Text stageLevelText;
    public Button leftBtn;
    public Button rightBtn;

    private void Start()
    {

        
        endStageLevel = StageManager.Instance.stageDatas[StageManager.Instance.stageDatas.Length-1].stageLevel;

        UpdateLobby();
    }

    // ���� 1�϶� ������ ��ư�� �����.
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
