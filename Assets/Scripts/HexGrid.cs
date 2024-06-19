using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;
    [SerializeField]
    private GameObject earthDeposit;
    [SerializeField]
    private GameObject fireDeposit;
    [SerializeField]
    private GameObject waterDeposit;
    [SerializeField]
    private GameObject airDeposit;
    [SerializeField]
    private GameObject goldDeposit;
    [SerializeField]
    private int gridWidth = 15;
    [SerializeField]
    private int gridHeight = 15;
    [SerializeField]
    private float cellSize = 3f;

    private List<Vector2> depositsPositions = new List<Vector2>();

    public Vector3[,] hexGrid = new Vector3[15,15];
    private void Start()
    {
        GenerateCoordinates();
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                float xPos = x * cellSize * Mathf.Sqrt(3) / 2;
                float zPos = z * cellSize;
                if (x % 2 == 1)
                {
                    zPos += cellSize / 2;
                }
                Vector3 cellPosition = new Vector3(xPos, 0.1f, zPos);
                GameObject cell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                cell.transform.parent = transform;
                cell.GetComponent<CellLogic>().xPos = x;
                cell.GetComponent<CellLogic>().yPos = z;
                hexGrid[x,z] = cell.transform.position;
                SpawnResourceDeposits(cell.transform, x, z);
                cell.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
        }
    }
    private void GenerateCoordinates()
    {
        bool close = true;
        Vector2 position = new Vector2(Random.Range(1, 14), Random.Range(3, 12));
        depositsPositions.Add(position);
        for (int i = 1; i < 10; i++)
        {
            position = new Vector2(Random.Range(1, 14), Random.Range(3, 12));
            while (close)
            {
                position = new Vector2(Random.Range(1, 14), Random.Range(3, 12));
                foreach(Vector2 pos in depositsPositions)
                {
                    if(Mathf.Abs(position.x - pos.x) < 3 && Mathf.Abs(position.y - pos.y) < 3)
                    {
                        close = true;
                        break;
                    }
                    close = false;
                }
            }
            close = true;
            depositsPositions.Add(position);
        }
    }
    private void SpawnResourceDeposits(Transform cell, int x, int y)
    {
        if(depositsPositions.Contains(new Vector2(x,y)))
        {
            switch(depositsPositions.IndexOf(new Vector2(x, y)))
            {
                case 0:
                case 1:
                    Instantiate(earthDeposit, cell.position, Quaternion.identity, transform);
                    break;
                case 2:
                case 3:
                    Instantiate(fireDeposit, cell.position, Quaternion.identity, transform);
                    break;
                case 4:
                case 5:
                    Instantiate(waterDeposit, cell.position, Quaternion.identity, transform);
                    break;
                case 6:
                case 7:
                    Instantiate(airDeposit, cell.position, Quaternion.identity, transform);
                    break;
                case 8:
                case 9:
                    Instantiate(goldDeposit, cell.position, Quaternion.identity, transform);
                    break;
            }
        }
    }
}
