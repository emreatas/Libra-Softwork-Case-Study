using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _tileX;
    private int _tileY;
    private Vector2Int _tilePos;

    private bool _cross;
    [SerializeField] private GameObject _crossObj;

    public Tile _upNeighbor;
    public Tile _downNeighbor;
    public Tile _leftNeighbor;
    public Tile _rightNeighbor;

    public List<Tile> _neighbors = new List<Tile>();

    public int TileX
    {
        get { return _tileX; }
        set { _tileX = value; }
    }
    public int TileY
    {
        get { return _tileY; }
        set { _tileY = value; }
    }
    public Vector2Int TilePos
    {
        get { return _tilePos; }
        set { _tilePos = value; }
    }
    public bool Cross
    {
        get { return _cross; }
        set
        {
            _cross = value;
            if (_cross)
            {
                _crossObj.SetActive(true);
            }
            else
            {
                _crossObj.SetActive(false);

            }
        }
    }
}
