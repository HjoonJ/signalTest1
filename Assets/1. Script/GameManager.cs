using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public User user;


    public Stage[] stages;

    public void Start()
    {
        stages = GetComponentsInChildren<Stage>();



        //유저가 가지고 있는 curStage 변수의 값을 활용해서 켠다!!
        int index = user.curStage;

        stages[index].gameObject.SetActive(true);


    }

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }






}
