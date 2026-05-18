using Unity.VisualScripting;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [SerializeField] public GameObject BlockPrefab;
    [SerializeField] public GameObject FirstBlock;
    [SerializeField] public GameObject LastBlock;
    [SerializeField] public HingeJoint blockJoint;
    [SerializeField] public Rigidbody crane;
    [SerializeField] public WorldMovement world;
    [SerializeField] public BlockScript blockScript;
    [SerializeField] public Transform newParent;
    private bool isFalling;
    private GameObject Clone;

    void BlockCreate()
    {
        Clone = Instantiate(BlockPrefab, transform);
        blockScript = Clone.GetComponent<BlockScript>();
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
            Clone.transform.rotation = new Quaternion(0,0,0,0);
            Clone.GetComponent<Rigidbody>().freezeRotation = true;
        }
        if (isFalling)
        {
            if (blockScript.collided)
            {
                if(blockScript.worldCollided)
                {
                    FirstBlock = Clone;
                    LastBlock = Clone; 
                }
                else
                {
                    if(Clone.transform.position.x < LastBlock.transform.position.x + 0.2f && Clone.transform.position.x > LastBlock.transform.position.x - 0.2f)
                    {
                        Clone.transform.position = new Vector3 (LastBlock.transform.position.x, Clone.transform.position.y, Clone.transform.position.z); 
                    }
                    LastBlock = Clone;
                }
                blockScript = null;
                Clone.transform.SetParent(newParent);
                Clone.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                Clone.GetComponent<Rigidbody>().isKinematic = true;
                isFalling = false;
                world.BlockAmount ++;
                BlockCreate();
            }
            if (Clone.transform.position.y < LastBlock.transform.position.y)
            {
                Destroy(Clone);
                BlockCreate();
            }
        }
    }
}
