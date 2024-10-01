using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{//降らすアイテムのプレハブ
    public GameObject[] itemPrefabs;
    //生成したアイテムを格納
    [System.NonSerialized]
    public List<GameObject> items;
    // Start is called before the first frame update
    void Start()
    {
        //コードで扱うのでListをスクリプトで初期化
        items= new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
