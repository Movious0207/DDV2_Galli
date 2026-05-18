using UnityEngine;
using UnityEngine.InputSystem;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] private int swingSpeed = 300;
    [SerializeField] private Transform worldCoords;

    void Start()
    {
        transform.position += transform.right * swingSpeed * Time.deltaTime;
    }

    void Update()
    {
        
    }
}
