using UnityEngine;

public class BackupToGameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    private GameObject[,] cells;  // Store the GameObjects
    private bool[,] nextGeneration;
    private float cellSize = 0.2f; // Size of our cells
    private int numberOfColumns, numberOfRows;
    private float spawnChancePercentage = 0.2f; // 20% chance of cell being alive initially

    void Start()
    {
        Application.targetFrameRate = 4;

        // Calculate the number of columns and rows based on cell size and screen size
        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight * Camera.main.aspect;
        numberOfColumns = Mathf.FloorToInt(screenWidth / cellSize);
        numberOfRows = Mathf.FloorToInt(screenHeight / cellSize);

        // Initialize the cell grid and next generation grid
        cells = new GameObject[numberOfColumns, numberOfRows];
        nextGeneration = new bool[numberOfColumns, numberOfRows];

        // Create and initialize cells
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColumns; x++)
            {
                Vector2 position = new Vector2(x * cellSize - (screenWidth / 2), y * cellSize - (screenHeight / 2));
                GameObject newCellObj = Instantiate(cellPrefab, position, Quaternion.identity);
                newCellObj.transform.localScale = new Vector3(cellSize, cellSize, 1f);

                Cell newCell = newCellObj.GetComponent<Cell>();
                newCell.alive = (Random.value < spawnChancePercentage);
                cells[x, y] = newCellObj;
            }
        }
    }

    void Update()
    {
        CalculateNextGeneration();
        UpdateCellStatus();
    }

    void CalculateNextGeneration()
    {
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColumns; x++)
            {
                int liveNeighbors = CountLiveNeighbors(x, y);
                bool isAlive = cells[x, y].GetComponent<Cell>().alive;

                if (isAlive)
                {
                    // Rules 1 and 3
                    if (liveNeighbors < 2 || liveNeighbors > 3)
                    {
                        nextGeneration[x, y] = false;
                    }
                    else
                    {
                        // Rule 2
                        nextGeneration[x, y] = true;
                    }
                }
                else
                {
                    // Rule 4
                    if (liveNeighbors == 3)
                    {
                        nextGeneration[x, y] = true;
                    }
                    else
                    {
                        nextGeneration[x, y] = false;
                    }
                }
            }
        }
    }

    void UpdateCellStatus()
    {
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColumns; x++)
            {
                cells[x, y].GetComponent<Cell>().alive = nextGeneration[x, y];
                cells[x, y].GetComponent<Cell>().UpdateStatus();
            }
        }
    }

    int CountLiveNeighbors(int x, int y)
    {
        int count = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;

                int neighborX = x + i;
                int neighborY = y + j;

                // Check if the neighbor is within bounds
                if (neighborX >= 0 && neighborX < numberOfColumns && neighborY >= 0 && neighborY < numberOfRows)
                {
                    if (cells[neighborX, neighborY].GetComponent<Cell>().alive)
                        count++;
                }
            }
        }

        return count;
    }
}
