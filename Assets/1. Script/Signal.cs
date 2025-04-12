using UnityEngine;

public class Signal : MonoBehaviour
{
    public GameObject signalObject;
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Signal OnTriggerEnter {other.gameObject.name}");

        if (other.CompareTag("Player"))
        {
            Debug.Log($"Signal OnTriggerEnter Player {other.gameObject.name}");
            
            Destroy(signalObject);
        }
    }
}
