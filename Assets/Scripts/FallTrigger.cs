using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    public UnityEvent OnPinFall = new();
    public bool isPinFallen = false;
    private void OnTriggerEnter(Collider triggeredObject)
    {
        if(triggeredObject.CompareTag("Floor") && !isPinFallen)
        {
            isPinFallen = true;
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} is fallen");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
