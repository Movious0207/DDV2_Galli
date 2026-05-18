using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;

    [SerializeField] public int BlockAmount = 0;

    [SerializeField] private float amountLowered = 0;

    bool isMoving = false;

    void Start()
    {
        
    }

    void Update()
    {
        UnityEngine.Vector3 nextPosition = BlockAmount * -transform.up * amountLowered;
        if(transform.position == nextPosition)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        if(isMoving)
        {
            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
        }
    }
}
