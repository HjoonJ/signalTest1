using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultCanvas : MonoBehaviour
{
    // ��Ȱ��ȭ �Ǿ� �ִ� ���ӿ�����Ʈ�� �̱��� ��������

    // 1. �� ���������ΰ� - StageManager.Instance.stageDatas[i]
    // 2. �� Ÿ�Ӹ���(��������������) - StageManager.Instance.stageDatas[i].timeLimit
    // 3. Ÿ�ӽ��� �迭 (�迭0 ��°, 1��°�� �ν�)
    // 4. ���� �帥 �ð� timer
    // 5. ��Ÿ �̹��� ǥ�� 

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

    public int starCount;

    public Image[] starImages;

 

    public void ShowResult(bool clear)
    {
        //���� ��������������
        StageData curStageData = StageManager.Instance.GetStageData(User.Instance.curStageLevel);
        //���� �帥 �ð�
        float curTimer = GameManager.Instance.timer;

        //1.�迭�� ���ؼ� starCount ���� �����ϱ�
        //2.���������� Ŭ���� �� ȹ���� �� ���� �����ϱ�


        //***�̺κп��� ���� �߻�!!

        gameObject.SetActive(true);

        for (int i = 0; starImages.Length > 0; i++)
        {
            starImages[i].gameObject.SetActive(false);
        }


        starCount = 1;
        for (int i = 0; i < curStageData.timeStep.Length; i++)
        { 
            if (curStageData.timeStep[i] >= curTimer)
            {
                //starCount = 3 - i;
                // �� 3��
                if (i == 0)
                {
                    starCount = 3;
                }
                // �� 2��
                else if (i == 1)
                {
                    starCount = 2;
                
                }


                break;

            }
        
        }

        //starCount ���� ���� ��Ÿ �̹��� ǥ�� UI ó���ϱ�.

        //gameObject.SetActive(true);

        if (clear == true)
        {
            resultText.text = "Clear!";

            // for ������ ¥����.
            //for (int i = 0; i < starCount; i++)
            //{
            //    starImages[i].gameObject.SetActive(true);
            //}

            if (starCount == 3) 
            {
                starImages[0].gameObject.SetActive(true);
                starImages[1].gameObject.SetActive(true);
                starImages[2].gameObject.SetActive(true);
            }
            else if (starCount == 2)
            {
                starImages[0].gameObject.SetActive(true);
                starImages[1].gameObject.SetActive(true);
            }
            else if (starCount == 1)
            {
                starImages[0].gameObject.SetActive(true);
            }

            nextBtn.gameObject.SetActive(true);
            retryBtn.gameObject.SetActive(false);
        }
        else
        {
            resultText.text = "Fail!";
            retryBtn.gameObject.SetActive(true);
            nextBtn.gameObject.SetActive(false);
        }

        // ���������� �����ϱ�.
        User.Instance.SaveClearStage(curStageData.stageLevel, starCount, clear);

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

        for (int i = 0; starImages.Length > 0; i++)
        {
            starImages[i].gameObject.SetActive(false);

        }
    }

   

}
