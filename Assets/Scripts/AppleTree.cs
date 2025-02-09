using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    
    // Prefab for instantiating branches
    public GameObject branchPrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between apple instantiations
    public float appleDropDelay = 1f;

    // Base seconds between branch instantiations (branches fall less frequently)
    public float branchDropDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Start dropping apples after 2 seconds
        Invoke("DropApple", 2f);

        // If a branch prefab is assigned, start dropping branches after 3 seconds
        if (branchPrefab != null)
        {
            Invoke("DropBranch", 3f);
        }
    }

    // Instantiates an apple at the tree's position and schedules the next drop
    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    // Instantiates a branch at the tree's position and schedules the next drop
    void DropBranch()
    {
        GameObject branch = Instantiate(branchPrefab);
        branch.transform.position = transform.position;
        // Schedule the next branch drop with a random delay between branchDropDelay and 2*branchDropDelay seconds
        float nextBranchDrop = Random.Range(branchDropDelay, branchDropDelay * 2f);
        Invoke("DropBranch", nextBranchDrop);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic horizontal movement of the tree
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Reverse direction when the tree reaches the edges
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
        else if (Random.value < changeDirChance)
        {
            speed *= -1; // Randomly change direction
        }
    }

    // FixedUpdate for time-based random direction changes
    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
