using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    int flag;

    public void ChangeValue()
    {
        int.TryParse(_inputField.text, out int result);
        flag = result;
        if (flag <= 4)
        {
            _inputField.text = "5";
        }
    }

    public void ChangeGrid()
    {
        Debug.Log(flag);
        GameManager.Instance.OnGenerateGrid(flag, flag);
    }


}
