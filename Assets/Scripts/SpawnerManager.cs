using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager Instance;

    [SerializeField] private ShapeManager[] shapes;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
    

    public ShapeManager CreateRandomShape()
    {
        int randomShape = Random.Range(0, shapes.Length);

        ShapeManager shape = Instantiate(shapes[randomShape], new Vector3(4f, 23.1f, 0f), Quaternion.identity) as ShapeManager;

        if (shape != null)
        {
            return shape;
        }

        return null;
    } 
}
