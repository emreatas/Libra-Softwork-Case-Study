using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int _height;
    [SerializeField] private int _width;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _spawnObject;

    public Dictionary<Vector2Int, Tile> _tiles = new Dictionary<Vector2Int, Tile>();
    private void OnEnable()
    {
        GameManager.GenerateGrid += GameManager_GenerateGrid;
    }

    private void GameManager_GenerateGrid(int arg1, int arg2)
    {
        _height = arg1;
        _width = arg2;

        GenerateGrid();

    }

    private void OnDisable()
    {
        GameManager.GenerateGrid -= GameManager_GenerateGrid;
    }
    private void GenerateGrid()
    {
        _tiles.Clear();
        foreach (Transform child in _spawnObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                GameObject go = Instantiate(_tilePrefab, new Vector3(j, 0, i), Quaternion.identity);
                Tile tile = go.GetComponent<Tile>();
                go.transform.SetParent(_spawnObject.transform);
                tile.TilePos = new Vector2Int(j, i);
                _tiles.Add(new Vector2Int(j, i), tile);
                go.name = "Tile " + "x:" + j + "," + "y:" + i;
            }
        }

        SetNeighbor();

    }

    private void SetNeighbor()
    {
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                Vector2Int pos = new Vector2Int(j, i);

                if (_tiles[pos].TilePos.y + 1 <= _height - 1)
                {
                    _tiles[pos]._upNeighbor = _tiles[pos + new Vector2Int(0, 1)];
                    _tiles[pos]._neighbors.Add(_tiles[pos + new Vector2Int(0, 1)]);
                }
                if (_tiles[pos].TilePos.y - 1 >= 0)
                {
                    _tiles[pos]._downNeighbor = _tiles[pos + new Vector2Int(0, -1)];
                    _tiles[pos]._neighbors.Add(_tiles[pos + new Vector2Int(0, -1)]);
                }
                if (_tiles[pos].TilePos.x + 1 <= _width - 1)
                {
                    _tiles[pos]._rightNeighbor = _tiles[pos + new Vector2Int(1, 0)];
                    _tiles[pos]._neighbors.Add(_tiles[pos + new Vector2Int(1, 0)]);
                }
                if (_tiles[pos].TilePos.x - 1 >= 0)
                {
                    _tiles[pos]._leftNeighbor = _tiles[pos + new Vector2Int(-1, 0)];
                    _tiles[pos]._neighbors.Add(_tiles[pos + new Vector2Int(-1, 0)]);
                }
            }
        }
    }
}
