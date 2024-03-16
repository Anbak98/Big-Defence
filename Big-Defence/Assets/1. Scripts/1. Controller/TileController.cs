using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] pattern;

    private GameObject MakeTile(Sprite sprite)
    {
        GameObject tileObj = new("tile");

        tileObj.transform.SetParent(transform);
        tileObj.AddComponent<SpriteRenderer>().sprite = sprite;

        return tileObj;
    }

    void Start()
    {
        for (int posX = 0; posX < GameManager.Tile.MapWidth; posX++)
        {
            for (int posY = 0; posY < GameManager.Tile.MapHeight; posY++)
            {
                GameManager.Tile.AddToMap( posX, posY, MakeTile(pattern[0]) );
            }
        }
    }
}
