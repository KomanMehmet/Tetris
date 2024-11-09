using Unity.Mathematics;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    
    [SerializeField] private Transform tilePrefab;

    [SerializeField] private int height = 22;
    [SerializeField] private int width = 10;

    private Transform[,] _grid;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _grid = new Transform[height, width];
        print(_grid.Length);
    }

    private void Start()
    {
        CreateEmptySquare();
    }

    private void CreateEmptySquare()
    {
        if (tilePrefab != null)
        {
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    Transform tile = Instantiate(tilePrefab, new Vector3(h, w, 0), quaternion.identity);
                    tile.name = "x " + h.ToString() + " , " + " y " + w.ToString();
                    tile.parent = transform;
                }
            }
        }
        else
        {
            print("TilePrefab eklenmedi!");
        }
        
    }

    public bool IsPositionInLimits(ShapeManager shape)
    {
        foreach (Transform child in shape.transform)
        {
            Vector2 pos = ConvertVectorToInt(child.position);

            if (!IsWithinBoardLimits((int)pos.x, (int)pos.y))
            {
                return false;
            }

            if (pos.y < height)
            {
                if (IsCellFilled((int)pos.x, (int)pos.y, shape))
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    private bool IsWithinBoardLimits(int x, int y)
    {
        return (x >= 0 && x < height && y >= 0);
    }
    
    

    private bool IsCellFilled(int x, int y, ShapeManager shape)
    {
        return (!_grid[x, y] && _grid[x, y].parent != shape.transform);
    }
    
    public void SnapToGrid(ShapeManager shape)
    {
        if (!shape) return;

        foreach (Transform child in shape.transform)
        {
            Vector2 pos = ConvertVectorToInt(child.position);
            
            _grid[(int)pos.x, (int)pos.y] = child;
        }
    }
    
    public Vector2 ConvertVectorToInt(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }
}
