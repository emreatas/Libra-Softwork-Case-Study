using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class CrossManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.ClickedTile += GameManager_ClickedTile;
    }

    private void GameManager_ClickedTile(Tile obj)
    {
        int count = NeigborCrossCount(obj);

        if (count == 0) { return; }

        if (count >= 1)
        {
            foreach (Tile t in obj._neighbors)
            {
                if (NeigborCrossCount(t) >= 2 && t.Cross)
                {
                    StartCoroutine(CrossClose(t));
                    StartCoroutine(CrossClose(obj));
                }
            }
        }
        if (count == 2)
        {
            StartCoroutine(CrossClose(obj));
        }
    }

    private int NeigborCrossCount(Tile tile)
    {
        int flag = 0;

        foreach (Tile t in tile._neighbors)
        {
            if (t.Cross)
            {
                flag++;
            }
        }

        return flag;
    }

    IEnumerator CrossClose(Tile tile)
    {
        yield return new WaitForSeconds(.2f);
        tile.Cross = false;

        foreach (Tile t in tile._neighbors)
        {
            t.Cross = false;
        }
    }

    private void OnDisable()
    {
        GameManager.ClickedTile -= GameManager_ClickedTile;
    }
}
