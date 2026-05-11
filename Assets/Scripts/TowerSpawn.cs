using Unity.VisualScripting;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [SerializeField] public GameObject BlockPrefab;
    [SerializeField] public HingeJoint blockJoint;
    [SerializeField] public Rigidbody crane;
    private GameObject Clone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Clone = Instantiate(BlockPrefab, transform);
        blockJoint = Clone.GetComponent<HingeJoint>();
        blockJoint.connectedBody = crane;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Clone.transform.SetParent(null);
            Destroy(blockJoint);
        }
    }
}
