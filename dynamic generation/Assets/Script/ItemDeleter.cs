using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeleter : MonoBehaviour
{
    // 画面のY軸の最小点
    float minScreenPointY;
    // アイテムの高さ
    float itemHeight;
    // 管?クラスのアイテムリストを使用
    [SerializeField]
    ItemManager itemManager;
    void Start()
    {
        // カメラが移している画面の下部の座標を取得
        minScreenPointY = Camera.main.ViewportToWorldPoint(Vector2.down).y;
    }
    // Update is called once per frame
    void Update()
    {
        // 生成されているアイテム全てを検索
        foreach (var item in itemManager.items)
        {
            // アイテムオブジェクトの高さを取得
            itemHeight = item.transform.localScale.y;
            // 画面外に出ているか。画面外で消すので高さを引く
            if (item.transform.position.y < minScreenPointY - itemHeight)
            {
                // オブジェクトを破壊
                Destroy(item);
                // 管?しているリストから破壊したオブジェクトと同じIDのものをリムーブ
                itemManager.items.RemoveAll(item_ =>
                item.GetComponent<FallItem>().ID == item_.GetComponent<FallItem>().ID);
                // 間隔で出しており２つ以上が画面外に出ることは無いので終了
                return;
            }
        }
    }
}