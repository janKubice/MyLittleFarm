using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class tableView : MonoBehaviour
{
    public string[] columnNames;
    public GameObject[] item;
    public int rowNumber;
    public Sprite backGround;
    public int fontSize = 15;
    int index = 0;
    GameObject bcg;
    void Start()
    {
        makeHeaders();
        makeTable();
    }

    /// <summary>
    /// seřadí componenty do tabulky
    /// </summary>
    private void makeTable()
    {
        for (int i = 0; i < rowNumber; i++)
        {
            for (int j = 0; j < columnNames.Length; j++)
            {
                item[index].transform.localPosition = new Vector2((j + 1) * 120, ((i + 1) * 30) - (70 * (i + 1)));
                item[index].transform.localScale = new Vector2(0.7f, 1);

                index++;
            }
        }
    }

    /// <summary>
    /// vytvoří hlavičky tabulky
    /// </summary>
    public void makeHeaders()
    {
        for (int i = 1; i <= columnNames.Length; i++)
        {
            GameObject columnHeader = new GameObject(columnNames[i - 1] + "_header");
            columnHeader.AddComponent<Text>();
            columnHeader.transform.parent = gameObject.transform;
            columnHeader.transform.localScale = new Vector2(1, 1);
            columnHeader.transform.localPosition = new Vector2(i * 120, 20);

            Text columnText = columnHeader.GetComponent<Text>();
            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            columnText.text = columnNames[i - 1];
            columnText.font = ArialFont;
            columnText.fontSize = fontSize;
            columnText.color = Color.black;
            columnText.alignment = TextAnchor.MiddleCenter;


            RectTransform rt = columnText.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(100, 35);

            GameObject columnBackGround = new GameObject(columnNames[i - 1] + "_background");
            columnBackGround.AddComponent<RectTransform>();
            columnBackGround.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = columnBackGround.GetComponent<SpriteRenderer>();
            sr.sprite = backGround;
            columnBackGround.transform.localScale = new Vector2(10, 5);
            sr.color = new Color(150 + (2 * i), 150 + (2 * i), 150 + i);
            columnBackGround.transform.parent = columnHeader.transform;
            columnBackGround.transform.localScale = new Vector2(9, 3.5f);
            columnBackGround.transform.localPosition = new Vector2(0, 0);
        }
    }
}