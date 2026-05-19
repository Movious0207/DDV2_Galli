using UnityEngine;
using UnityEngine.InputSystem;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] private int swingSpeed;
    void Start()
    {
        transform.position += transform.right * swingSpeed * Time.deltaTime;
    }

    void Update()
    {
        
    }
}
