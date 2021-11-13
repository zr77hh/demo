using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private Tile tilePrefab,buttonPrefab;
    [SerializeField] private Transform cam;

    private void Start()
    {
        width += 2;
        height += 2;

        GenerateGrid();
        setCameraPos();
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (!isCorner(x,y))
                {
                    Tile tile;

                    bool isButtonPos = x == 0 || x == width - 1 || y == 0 || y == height - 1;
                    if (isButtonPos)
                    {
                        tile = buttonPrefab;
                    }
                    else
                    {
                        tile = tilePrefab;
                    }
                    spawnTile(tile, x, y);
                }
            }
        }
    }
    bool isCorner(float x, float y)
    {
        bool bottomLeft = x == 0 && y == 0;
        bool bottomRight = y == 0 && x == width - 1;
        bool topLeft = x == 0 && y == height - 1;
        bool topRight = x == width - 1 && y == height - 1;

        return bottomLeft || bottomRight || topRight || topLeft;
    }
    void spawnTile(Tile tileToSpawn,float row,float column)
    {
        Quaternion rotation = getTileRotation(row,column);

        Tile spawnedTile = Instantiate(tileToSpawn, new Vector3(row, column), rotation);
        spawnedTile.name = $"Tile {row} {column}";
        spawnedTile.transform.SetParent(transform);

        bool isOffset = (row % 2 == 0 && column % 2 != 0) || (row % 2 != 0 && column % 2 == 0);
        spawnedTile.Init(isOffset);
    }

    private Quaternion getTileRotation(float x,float y)
    {
        bool isLeft = x == 0;
        if (isLeft)
        {
            return Quaternion.Euler(new Vector3(0, 90, -90));
        }
        bool isRight = x == width - 1;
        if (isRight)
        {
            return Quaternion.Euler(new Vector3(0, -90, 90));
        }
        bool isBottom = y == 0;
        if (isBottom)
        {
            return Quaternion.Euler(new Vector3(-90, 0, 0));
        }
        bool isTop = y == height - 1;
        if (isTop)
        {
            return Quaternion.Euler(new Vector3(90, 0, 180));
        }
        return Quaternion.identity;
    }

    void setCameraPos()
    {
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -15);
    }
}