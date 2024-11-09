using System;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoardManager boardManager;

    private ShapeManager _activeShape;

    [Space(10)]
    [Header("Sayaçlar")]
    [Range(0.01f, 1f)]
    [SerializeField] private float _spawnTime = 0.5f;
    private float _spawnCounter = 0f;
    
    private void Start()
    {
        if (SpawnerManager.Instance == null)
        {
            print("SpawnManager örneği sahnede bununamadı.");
            return;
        }

        if (_activeShape)
        {
            print("ShapeManager örneği oluşturulamadı.");
            return;
        }
        
        _activeShape = SpawnerManager.Instance.CreateRandomShape();
            
        _activeShape.transform.position = ConvertVectorToInt(_activeShape.transform.position);
    }

    private void Update()
    {
        if (!boardManager || !SpawnerManager.Instance)
        {
            return;
        }

        if (Time.time > _spawnCounter)
        {
            _spawnCounter = Time.time + _spawnTime;
            
            if (_activeShape)
            {
                _activeShape.MoveDown();
            }
        }

        
    }

    private Vector2 ConvertVectorToInt(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), math.round(vector.y));
    }
}
