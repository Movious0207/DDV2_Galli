using Unity.VisualScripting;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [SerializeField] public GameObject FirstBlockPrefab;
    [SerializeField] public Rigidbody CloneRigidbody;
    [SerializeField] public GameObject BlockPrefab1;
    [SerializeField] public GameObject BlockPrefab2;
    [SerializeField] public GameObject BlockPrefab3;

    [SerializeField] public GameObject FirstBlock;
    [SerializeField] public GameObject LastBlock;
    
    [SerializeField] public HingeJoint blockJoint;
    [SerializeField] public Rigidbody crane;
    [SerializeField] public WorldMovement world;
    [SerializeField] public BlockScript blockScript;

    [SerializeField] public Transform newParent;

    [SerializeField] public int perfectStreak;
    [SerializeField] public int score;

    private bool isFalling;
    
    private GameObject Clone;

    void BlockCreate()
    {
        if(world.BlockAmount > 0)
        {
            int building = Random.Range(1, 4);
            switch(building)
            {
                case 1:
                    Clone = Instantiate(BlockPrefab1, transform);
                    break;
                case 2:
                    Clone = Instantiate(BlockPrefab2, transform);
                    break;
                case 3:
                    Clone = Instantiate(BlockPrefab3, transform);
                    break;

            }
        }
        else
        {
            Clone = Instantiate(FirstBlockPrefab, transform);
        }
        blockScript = Clone.GetComponent<BlockScript>();
        blockJoint = Clone.GetComponent<HingeJoint>();
        CloneRigidbody = Clone.GetComponent<Rigidbody>();
        blockJoint.connectedBody = crane;
    }

    void Start()
    {
        BlockCreate();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1) 
        {
            Clone.transform.SetParent(null);
            Destroy(Clone.GetComponent<HingeJoint>());
            isFalling = true;
            Clone.transform.rotation = new Quaternion(0,180,0,0);
            CloneRigidbody.angularVelocity = Vector3.zero;
        }
        if (isFalling)
        {
            if (blockScript.collided)
            {
                if(blockScript.worldCollided)
                {
                    FirstBlock = Clone;
                    LastBlock = Clone;
                    blockScript = null;
                    Clone.transform.SetParent(newParent);
                    CloneRigidbody.linearVelocity = Vector3.zero;
                    Clone.transform.rotation = new Quaternion(0, 180, 0, 0);
                    CloneRigidbody.isKinematic = true;
                    isFalling = false;
                    world.BlockAmount++;
                    BlockCreate();
                }
                else
                {
                    if(Clone.transform.position.x < LastBlock.transform.position.x + 1.5f && Clone.transform.position.x > LastBlock.transform.position.x - 1.5f)
                    {
                        if (Clone.transform.position.x < LastBlock.transform.position.x + 0.2f && Clone.transform.position.x > LastBlock.transform.position.x - 0.2f)
                        {
                            Clone.transform.position = new Vector3(LastBlock.transform.position.x, Clone.transform.position.y, Clone.transform.position.z);
                            perfectStreak++;
                            score += 100;
                            AudioManager.PlaySound(SoundType.Perfect,1);
                        }
                        else
                        {
                            perfectStreak = 0;
                            score += 50;
                            AudioManager.PlaySound(SoundType.Collision,1);
                        }
                        LastBlock = Clone;
                        blockScript = null;
                        Clone.transform.SetParent(newParent);
                        CloneRigidbody.linearVelocity = Vector3.zero;
                        Clone.transform.rotation = new Quaternion(0, 180, 0, 0);
                        CloneRigidbody.isKinematic = true;
                        isFalling = false;
                        world.BlockAmount++;
                        BlockCreate();
                    }
                    else
                    {
                        isFalling = false;
                    }
                }
            }
        }
        if (Clone.transform.position.y < LastBlock.transform.position.y + 0.5)
        {
            score -= 100;
            perfectStreak = 0;
            Destroy(Clone);
            BlockCreate();
        }
    }
}
