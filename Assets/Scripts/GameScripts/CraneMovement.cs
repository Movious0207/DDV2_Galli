using UnityEngine;
using UnityEngine.InputSystem;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] private int swingSpeed = 5;
    [SerializeField] private Transform worldCoords;

    void Start()
    {
        transform.position += transform.right * swingSpeed * Time.deltaTime;
    }

    void Update()
    {
        
    }
}
