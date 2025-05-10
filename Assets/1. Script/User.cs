using UnityEngine;

public class User : MonoBehaviour
{
    public static User Instance;
    public int curStageLevel;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }




}
