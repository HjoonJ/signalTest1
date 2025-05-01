using TMPro;
using UnityEngine;

public class SequenceElement : MonoBehaviour
{
    // 얘가 몇번째인지
    public int number;
    public TMP_Text numberText;

    public SequenceSignal sSignal;

    public void Start()
    {
        sSignal = GetComponentInParent<SequenceSignal>();
    }

    public void SetNumber(int n) 
    { 
        number = n;
        
        numberText.text = number.ToString();

    }



    // 충돌감지
    public virtual void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            sSignal.ElementTouched(this);
        }
    }


}
