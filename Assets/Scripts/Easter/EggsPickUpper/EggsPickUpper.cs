using System;
using UnityEngine;

public class EggsPickUpper : MonoBehaviour
{
    public event Action<GameObject> OnPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPickedUp?.Invoke(this.gameObject);
        }
    }
}
