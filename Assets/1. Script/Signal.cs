using UnityEngine;

public class Signal : MonoBehaviour
{
    public GameObject signalObject;
    public string key;

    public bool clear = false;


    public virtual void StartSignal(SignalMethod signalMethod = SignalMethod.Any, bool on = false)
    {
       
    }

    public virtual void EndSignal(bool complete)
    {
        if (complete ==true)
        {
            //Destroy(signalObject);
            signalObject.SetActive(false);
            clear = true;


            // 클리어 됐는지 확인
            GameManager.Instance.CheckClear();
        }
        
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        StartSignal();
        if (other.CompareTag("Player"))
        {
            //Debug.Log($"Signal OnTriggerEnter Player {other.gameObject.name}");

            EndSignal(true);
        }
    }
}

public enum SignalMethod
{
    Right,
    Left,
    Any,
}
