using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator sharedInstance;

    public List<LevelBlock> currentLevelBlock = new List<LevelBlock>();

    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();

    public Transform levelInitialPoint;

    public bool isGeneratingInitialBlocks;

    private void Awake()
    {
        sharedInstance = this;
        
    }

    public void GenerateInitialBLocks()
    {
        if (currentLevelBlock.Count == 0)
        {
            isGeneratingInitialBlocks = true;
            for (int i = 0; i < 3; i++)
            {
                AddNewBlock();
            }
            isGeneratingInitialBlocks = false;
        }

    }

    public void RemoveOldBLock()
    {
        LevelBlock block = currentLevelBlock[0];
        currentLevelBlock.Remove(block);
        Destroy(block.gameObject);
    }

    public void RemoveAllTheBlocks()
    {
        while (currentLevelBlock.Count > 0)
        {
            RemoveOldBLock();
        }
    }

    public void AddNewBlockAll()
    {
        LevelBlock block = allTheLevelBlocks[allTheLevelBlocks.Count-1];
        allTheLevelBlocks.Add(block);
    }
    
    public void AddNewBlock()
    {
        int randomIndex = Random.Range(0,allTheLevelBlocks.Count);
        
        if (isGeneratingInitialBlocks)
        {
            randomIndex = 0;
        }

        LevelBlock block = Instantiate(allTheLevelBlocks[randomIndex]);
        
        block.transform.SetParent(this.transform, false);

        Vector3 blockPosition = Vector3.zero;

        if (currentLevelBlock.Count == 0)
        {
            blockPosition = levelInitialPoint.position;
        }
        else
        {
            blockPosition = currentLevelBlock[currentLevelBlock.Count - 1].exitPoint.position;
        }

        block.transform.position = blockPosition;
        
        currentLevelBlock.Add(block);

    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBLocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
