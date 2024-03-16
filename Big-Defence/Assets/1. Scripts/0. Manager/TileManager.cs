using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager
{
    public Tile[,] map { get; private set; }

    public readonly int MapWidth = 32;
    public readonly int MapHeight = 32;
    // tileSize = 1 ( 1 meter = 1 Unit )

    public void OnAwake()
    {
        this.map = new Tile[MapWidth, MapHeight];
    }

    public void AddToMap(int posX, int posY, GameObject tileObj)
    {
        tileObj.transform.position = new Vector3 (posX, posY, 0);

        map[posX, posY] = new Tile(posX, posY, tileObj);
    }

    public void SetType(TileType _type, Vector3 _tilePos)
    {
        map[(int)_tilePos.x, (int)_tilePos.y].type = _type;
    }
}

public enum TileType
{
    Open, Close, Defence
}

public class Tile
{
    protected int posX, posY;

    public GameObject obj;

    public TileType type;

    public Tile(int posX, int posY, GameObject tileObj)
    {
        this.posX = posX;
        this.posY = posY;
        this.obj = tileObj; 
        this.type = TileType.Open;
    }
}