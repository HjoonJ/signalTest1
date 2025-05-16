using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultCanvas : MonoBehaviour
{
    // 비활성화 되어 있는 게임오브젝트의 싱글톤 가져오기

    private static ResultCanvas instance; //변수
    public static ResultCanvas Instance //속성 = 변수 + 함수
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
