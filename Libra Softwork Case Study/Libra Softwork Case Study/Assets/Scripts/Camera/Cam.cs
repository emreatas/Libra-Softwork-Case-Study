using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Camera cam;
    private void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
    }
    private void OnEnable()
    {
        GameManager.GenerateGrid += GameManager_GenerateGrid;
    }
    private void GameManager_GenerateGrid(int arg1, int arg2)
    {
        cam.transform.position = new Vector3((arg2 % 2 == 0 ? (arg2 / 2) - .5f : arg2 / 2), Mathf.Max(arg1, arg2), arg1 % 2 == 0 ? (arg1 / 2) - .5f : arg1 / 2);
    }
    private void OnDisable()
    {
        GameManager.GenerateGrid -= GameManager_GenerateGrid;

    }



}
