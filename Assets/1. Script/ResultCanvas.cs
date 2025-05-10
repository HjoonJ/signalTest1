using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultCanvas : MonoBehaviour
{
    public static ResultCanvas Instance;

    public TMP_Text resultText;
    public Button nextBtn;
    public Button retryBtn;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ShowResult(bool clear)
    {
        gameObject.SetActive(true);

        if (clear == true)
        {
            resultText.text = "Clear!";

            nextBtn.gameObject.SetActive(true);
        }
        else
        {
            resultText.text = "Fail!";
            retryBtn.gameObject.SetActive(true);
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
