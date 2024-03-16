using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private InputManager _input;
    private TileManager _tile;
    private TowerManager _tower;

    public static InputManager Input { get { return Instance._input; } }
    public static TileManager Tile { get { return Instance._tile; } }
    public static TowerManager Tower { get { return Instance._tower; } }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _input = new();
        _tile = new();
        _tower = new();

        _tile.OnAwake();
        _tower.OnAwake();
    }    

    void Start()
    {
    }

    void Update()
    {                                                                                                                                                                                                                                                                                                     
        _input.OnUpdate();
    }
}
