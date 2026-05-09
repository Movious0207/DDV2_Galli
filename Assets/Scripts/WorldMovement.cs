using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;

    [SerializeField] private int BlockAmount = 0;

    bool isMoving = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
            BlockAmount ++;
        }
        if(isMoving)
        {
            UnityEngine.Vector3 nextPosition = BlockAmount * -transform.up * 20;
            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
            if(transform.position == nextPosition)
            {
                isMoving = false;
            }
        }
    }
}
