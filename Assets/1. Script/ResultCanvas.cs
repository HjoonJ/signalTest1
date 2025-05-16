using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultCanvas : MonoBehaviour
{
    // ��Ȱ��ȭ �Ǿ� �ִ� ���ӿ�����Ʈ�� �̱��� ��������

    private static ResultCanvas instance; //����
    public static ResultCanvas Instance //�Ӽ� = ���� + �Լ�
    {
        get 
        {
            if (instance == null)
                instance = FindFirstObjectByType<ResultCanvas>(FindObjectsInactive.Include);
            
            return instance;
        } 
    }

    public TMP_Text resultText;
    public Button nextBtn;
    public Button retryBtn;

  
    public void ShowResult(bool clear)
    {
        gameObject.SetActive(true);

        if (clear == true)
        {
            resultText.text = "Clear!";

            nextBtn.gameObject.SetActive(true);
            retryBtn.gameObject.SetActive(false);
        }
        else
        {
            resultText.text = "Fail!";
            retryBtn.gameObject.SetActive(true);
            nextBtn.gameObject.SetActive(false);
        }


    }

    public void OnClickedLobby()
    {
        SceneManager.LoadScene("Lobby");

        gameObject.SetActive(false);
    }

    public void OnClickedNext()
    {
        User.Instance.curStageLevel++;
        SceneManager.LoadScene("InGame");

        //GameManager.Instance.GoNextStage();
        //gameObject.SetActive(false);

    }

    public void OnClickedRetry()
    {
        SceneManager.LoadScene("InGame");

    }

    // 

    void Start()
    {
        
    }

}
