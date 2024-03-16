using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] towers;

    public void MakeTower(int towerNum, Vector3 pos)
    {
        if (GameManager.Tower.Map[(int)pos.x, (int)pos.y] != null) 
        {
            Debug.Log("Tower Exist");
            return;
        }
        pos.z = 0;
        _ = Instantiate(towers[towerNum], pos, Quaternion.identity, transform);
    }

    public void DestroyTower()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(GameManager.Input.mousePosTileCenter);
            MakeTower(0, GameManager.Input.mousePosTileCenter);
            GameManager.Tile.SetType(TileType.Close, GameManager.Input.mousePosTileCenter);
        }
    }
}
