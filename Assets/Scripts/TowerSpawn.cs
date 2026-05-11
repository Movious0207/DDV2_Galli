using Unity.VisualScripting;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [SerializeField] public GameObject BlockPrefab;
    [SerializeField] public HingeJoint blockJoint;
    [SerializeField] public Rigidbody crane;
    [SerializeField] public GameObject world;
    private bool isFalling;
    private GameObject Clone;

    void BlockCreate()
    {
        Clone = Instantiate(BlockPrefab, transform);
        blockJoint = Clone.GetComponent<HingeJoint>();
        blockJoint.connectedBody = crane;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BlockCreate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Clone.transform.SetParent(null);
            Destroy(Clone.GetComponent<HingeJoint>());
            isFalling = true;
        }
        if (isFalling)
        {
            Clone.transform.rotation = Quaternion.RotateTowards(transform.rotation, world.transform.rotation, 5f * Time.deltaTime);
            if (Clone.transform.position.y <= 0)
            {
                isFalling = false;
                BlockCreate();
            }
        }
    }
}
