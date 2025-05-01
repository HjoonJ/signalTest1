using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public User user;


    public Stage[] stages;

    public void Start()
    {
        stages = GetComponentsInChildren<Stage>();



        //������ ������ �ִ� curStage ������ ���� Ȱ���ؼ� �Ҵ�!!
        int index = user.curStage;

        stages[index].gameObject.SetActive(true);


    }

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }






}
