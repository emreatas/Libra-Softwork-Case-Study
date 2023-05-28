using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public static event Action<int, int> GenerateGrid;
    public void OnGenerateGrid(int _height, int _width)
    {
        if (GenerateGrid != null)
        {
            GenerateGrid(_height, _width);
        }
    }

    public static event Action<Tile> ClickedTile;
    public void OnClickedTile(Tile tile)
    {
        if (ClickedTile != null)
        {
            tile.Cross = true;

            ClickedTile(tile);
        }
    }

}
