using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    private bool isFalling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            isFalling = true;
        }
        if (isFalling)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, 0, 0, 0), 5f * Time.deltaTime);
        }
    }
}
