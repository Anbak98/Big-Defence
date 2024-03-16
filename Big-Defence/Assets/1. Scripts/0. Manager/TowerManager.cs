using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerManager
{
    public Tower[,] Map { get; private set; }

    public int maxSerialNum = 0;

    public void OnAwake()
    {
        maxSerialNum = 0;
        Map = new Tower[GameManager.Tile.MapWidth, GameManager.Tile.MapHeight];
    }

    public void AddToOwn(int posX, int posY, Tower _tower)
    {
        _tower.serialNum = maxSerialNum;
        Map[posX, posY] = _tower;
        Debug.Log(maxSerialNum);
        maxSerialNum++;
    }
}

public class Tower : MonoBehaviour
{
    public float posX;
    public float posY;

    public int HP;
    public int maxHP;

    public int damage;
    
    GameObject towerObj;

    public int serialNum;

    public Tower()
    {
        posX = 0;
        posY = 0;
        HP = 0;
        maxHP = 100; 
        damage = 10;
        towerObj = null;
    }

    public Tower(float posX, float posY, GameObject towerObj)
    {
        this.posX = posX;
        this.posY = posY;
        this.towerObj = towerObj;
    }

    protected virtual void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        GameManager.Tower.AddToOwn((int)posX, (int)posY, this);
    }
}