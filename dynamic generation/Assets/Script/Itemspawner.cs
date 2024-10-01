using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemspawner : MonoBehaviour
{
    // 管?クラスのアイテムリストを使用
    [SerializeField]
    ItemManager itemManager;

    // 作成済みのPrefabから選ぶ
    GameObject item;

    // 生成するアイテムの最大サイズ
    [SerializeField]
    float itemMaxSize;

    // 生成するアイテムの最小サイズ
    [SerializeField]
    float itemMinSize;

    // カメラからアイテムのZ座標上の最小距離
    [SerializeField]
    float minDepth;

    // カメラからアイテムのZ座標上の最大距離
    [SerializeField]
    float maxDepth;

    // 生成時間の間隔
    [SerializeField]
    float timeInterval;

    // 経過時間を数える
    float currentTimer;

    // 生成したアイテムに付けるID
    int setID;

    // IDの最大番号
    [SerializeField]
    int maxIDNum;

    // 生成するアイテムの座標を設定して返す
    Vector3 GetSpawnPosition()
    {
        // 画面の右上の座標を設定
        var maxScreenPoint = Camera.main.ViewportToWorldPoint(Vector2.one);

        // 画面の最大座標をもとに画面上のX座標のランダムの位置を取得
        var randomPointX = Random.Range(-maxScreenPoint.x, maxScreenPoint.x);

        // アイテムオブジェクトの高さを取得
        var itemHeight = item.transform.localScale.y;

        // 沸くところを見せたくないので少し上から生成する
        var spawnPointY = maxScreenPoint.y + itemHeight;

        // 奥行きもランダマイズ
        var randomPointZ = Random.Range(minDepth, maxDepth);
        return new Vector3(randomPointX, spawnPointY, randomPointZ);
    }
    // 生成アイテムの大きさを設定する
    void SetItemScale()
    {
        // アイテムの大きさをランダマイズ
        var randomSize = Random.Range(itemMinSize, itemMaxSize);

        // x,y,zのサイズ比率は同じで設定
        item.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }
    // アイテムを生成する
    public void ItemSpawn()
    {
        // アイテムの大きさを設定する
        SetItemScale();

        // 座標を設定したので配置
        var instanceItem = Instantiate(item, GetSpawnPosition(), Quaternion.identity);

        // 生成したアイテムにIDを付ける
        SetID(instanceItem); ;

        // 生成したので管理してもらう
        itemManager.items.Add(instanceItem);

    }
    // 生成したアイテムにIDを付ける
    void SetID(GameObject instanceItem)
    {
        // 情報を個別に持たせるので１個ずつクラスを渡す
        instanceItem.AddComponent<FallItem>();

        // 番号を付ける
        instanceItem.GetComponent<FallItem>().ID = setID;

        // 番号は連番にするのでインクリメント
        ++setID;
    }
    // IDの数値が大きくなった場合にリセットをかける
    void ResetID()
    {
        // セットしているIDが設定した値を超えているか
        if (setID > maxIDNum)
        {
            // セットするIDの値をリセット
            setID = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // 順番に付けるので最初は0
        setID = 0;
        // 経過時間なので最初は0
        currentTimer = 0;
    }
    void Update()
    {
        // セットするIDの数値のリセットの必要性を調べる
        ResetID();

        // タイマーの時間を進める
        currentTimer += Time.deltaTime;

        // 経過時間が設定した時間を超えているか
        if (currentTimer >= timeInterval)
        {
            // 実際に生成するアイテムをプレハブリストからランダムに取得
            item = itemManager.itemPrefabs[Random.Range(0, itemManager.itemPrefabs.Length)];

            // アイテムをスポーン
            ItemSpawn();

            // 数えなおすので0に直す
            currentTimer = 0.0f;
        }
    }
}
