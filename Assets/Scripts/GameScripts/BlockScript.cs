using UnityEngine;
public class BlockScript : MonoBehaviour
{
    [SerializeField] public bool worldCollided;
    [SerializeField] public bool collided;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "World")
        {
            collided = true;
            worldCollided = true;
        }
        if (collision.gameObject.name == "Block(Clone)")
        {
            collided  = true;
        }
    }
}
