using System;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ShapeManager _activeShape;

    [Space(10)]
    [Header("Sayaçlar")]
    [Range(0.01f, 1f)]
    [SerializeField] private float _spawnTime = 0.5f;
    private float _spawnCounter = 0f;
    
    private void Start()
    {
        if (!SpawnerManager.Instance)
        {
            print("SpawnManager örneği sahnede bununamadı.");
            return;
        }
        
        _activeShape = SpawnerManager.Instance.CreateRandomShape();
            
        _activeShape.transform.position = BoardManager.Instance.ConvertVectorToInt(_activeShape.transform.position);
    }

    private void Update()
    {
        if (!BoardManager.Instance || !SpawnerManager.Instance)
        {
            return;
        }

        if (Time.time > _spawnCounter)
        {
            _spawnCounter = Time.time + _spawnTime;
            
            if (_activeShape)
            {
                _activeShape.MoveDown();
                
                BoardManager.Instance.SnapToGrid(_activeShape);

                if (!BoardManager.Instance.IsPositionInLimits(_activeShape))
                {
                    _activeShape.MoveUp();

                    if (SpawnerManager.Instance)
                    {
                        _activeShape = SpawnerManager.Instance.CreateRandomShape();
                    }
                }
            }
        }
    }
}
