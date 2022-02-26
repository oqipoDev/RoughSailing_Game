using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct GameChunk
{
    public GameObject Object;
    public Vector2Int Position;
    public int inactiveFor;
}

public class ChunkHandler : MonoBehaviour
{
   [Range(1, 10)]public int UpdatesPerFrame = 1;
   [Header("Set at start")]
    public int Radius = 5;
    public GameObject ChunkObject;
    public bool DebugLines = false;
 
    private int ArraySize;
    Pool ChunkPool;
    List<Vector2Int> ChunkLoadOrder = new List<Vector2Int>();
    List<GameChunk> ActiveChunks = new List<GameChunk>();
    int CurrentChunkIndex = 0;
    private bool[,] CircleTruTab; //Truth table for neigboring chunks
    Vector2Int currentPos;
    
    void Start()
    {
        ChunkPool = new GameObject().AddComponent<Pool>();
        ChunkPool.ObjectToPool = ChunkObject;
        ArraySize = Radius * 2 + 1;

        CircleTruTab = new bool[ArraySize, ArraySize];

        int chunksInCircle = 0;

        //Chunk array thruth table
        for (int x = 0; x < ArraySize; x++)
        {
            for (int y = 0; y < ArraySize; y++)
            {
                CircleTruTab[x,y] = Radius > ArrayToPos(x, y).magnitude;
                //For chunkOrder
                if (CircleTruTab[x,y]) chunksInCircle++;
            }
        }

        string a = "";

        for (int x = 0; x < ArraySize; x++)
        {
            for (int y = 0; y < ArraySize; y++)
            {
                if(CircleTruTab[x,y])
                    a += "1"; 
                else a += "0";
            }
            a+= "\n";
        }
        //Debug.Log(a);
        //Debug.Log(chunksInCircle);

        Vector2Int lastChunkReg =  new Vector2Int(Radius, Radius);
        int distFromCenter = 1;
        
        ChunkLoadOrder.Add(lastChunkReg);
        chunksInCircle--;
        lastChunkReg += new Vector2Int(-1, -1);

        while(chunksInCircle > 0)
        {
            lastChunkReg += new Vector2Int(1, 2);
            if (AddChunkToQueue(lastChunkReg))
                chunksInCircle--;
            for (int i = 0; i < distFromCenter; i++)
            {
                lastChunkReg += new Vector2Int(1, -1);
                if (AddChunkToQueue(lastChunkReg))
                    chunksInCircle--;
            }
            for (int i = 0; i < distFromCenter; i++)
            {
                lastChunkReg += new Vector2Int(-1, -1);
                if (AddChunkToQueue(lastChunkReg))
                    chunksInCircle--;
            }
            for (int i = 0; i < distFromCenter; i++)
            {
                lastChunkReg += new Vector2Int(-1, 1);
                if (AddChunkToQueue(lastChunkReg))
                    chunksInCircle--;
            }
            for (int i = 0; i < distFromCenter - 1; i++)
            {
                lastChunkReg += new Vector2Int(1, 1);
                if (AddChunkToQueue(lastChunkReg))
                    chunksInCircle--;
            }
            distFromCenter ++;
        }



        ApplyCurrentPos();
    }

    void Update()
    {
        for (int i = 0; i < UpdatesPerFrame; i++)
        {
            Vector2Int CurrentChunk = ChunkLoadOrder[CurrentChunkIndex];

            Vector2Int worldChunkPos = ArrayToPos(CurrentChunk.x, CurrentChunk.y) + currentPos;

            //Disable chunks
            for (int c = 0; c < ActiveChunks.Count; c++)
            {
                var chonke = ActiveChunks[c];
                    chonke.inactiveFor++;
                    ActiveChunks[c] = chonke;
                    if(chonke.inactiveFor > ActiveChunks.Count * 1.5)
                    {
                        chonke.Object.gameObject.SetActive(false);
                        ActiveChunks.Remove(chonke);
                        goto Exit;
                    }
                
                if(chonke.Position == worldChunkPos)
                {
                    chonke.inactiveFor = 0;
                    ActiveChunks[c] = chonke;
                    goto Exit;
                }
            }


            GameChunk newChunkEntry = new GameChunk(); 
            GameObject newChunkObj = ChunkPool.GetPooledObject();

            newChunkEntry.Object = newChunkObj;
            newChunkEntry.Position = worldChunkPos;
            newChunkEntry.inactiveFor = 0;
            newChunkObj.transform.position = new Vector3(worldChunkPos.x, 0, worldChunkPos.y) * 10;

            ActiveChunks.Add(newChunkEntry);
            newChunkObj.SetActive(true);

            Exit:

            if(DebugLines)
                Debug.DrawLine(transform.position, new Vector3(worldChunkPos.x, 0, worldChunkPos.y) * 10, Color.cyan, 0.01f);
 
            //Move along the array
            if (++CurrentChunkIndex >= ChunkLoadOrder.Count)
            {
                CurrentChunkIndex = 0;

                ApplyCurrentPos();
            }
        }
    }

    private bool AddChunkToQueue(Vector2Int vectwo)
    {
        if (vectwo.x >= ArraySize || vectwo.x < 0 || vectwo.y >= ArraySize || vectwo.y < 0)
        return false;

        if(CircleTruTab[vectwo.x, vectwo.y])
        {
            ChunkLoadOrder.Add(vectwo);
            return true;
        }
        return false;
    }

    //Updates current object position
    private void ApplyCurrentPos()
    {
        currentPos = new Vector2Int
                (Mathf.RoundToInt(transform.position.x / 10),
                Mathf.RoundToInt(transform.position.z / 10));
    }

    private Vector2Int ArrayToPos(int x, int y)
    {
        return new Vector2Int(x - Radius, y - Radius);
    }
}
