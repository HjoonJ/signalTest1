using UnityEngine;
using UnityEngine.SceneManagement;
public class Lobby : MonoBehaviour
{
    int curStageLevel;
    int endStageLevel;

    //Ŭ������ ���������� �������
    //User.Instance.userData.userStages

    //�κ� ȭ�鿡 ȭ��ǥ�� Ŭ������ �������� ���� + Ŭ������ �������� ���� �ŵ� ���� ���� 

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
