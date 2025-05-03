using UnityEngine;

public class User : MonoBehaviour
{
    public static User Instance;
    public int curStage;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }




}
