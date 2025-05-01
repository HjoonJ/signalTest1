using UnityEngine;

public class User : MonoBehaviour
{
    public int curStage;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }




}
