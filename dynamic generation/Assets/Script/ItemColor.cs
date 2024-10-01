using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// アイテムが所持しているマテリアルの色を?新する
public class ItemColor : MonoBehaviour
{
    // 作成しておいたマテリアル
    [SerializeField]
    Material[] materials;
    // アイテムにつける色のグラデーションの設定
    [SerializeField]
    Gradient[] gradients;
    // 経過時間を数える
    float currentTimer;
    // 設定したグラデーションの変化を完了する時間
    [SerializeField]
    float changedTime;
    void Start()
    {
        // 経過時間なので最初は0
        currentTimer = 0;
    }
    void Update()
    {
        // 時間を進める
        currentTimer += Time.deltaTime;
        // グラデーションを進める
        UpdateItemColor();
    }
    // グラデーションを進める
    void UpdateItemColor()
    {
        // カウンターが規定値を変えたら1.0を入れる
        var timeRate = Mathf.Min(1.0f, currentTimer / changedTime);
        // グラデーションの変?を終えたら
        if (timeRate == 1.0f)
        {
            // 経過時間を0に戻す事で色の変化をループ
            currentTimer = 0.0f;
        }
        // マテリアルの色を変?していく(グラデーション)
        for (int i = 0; i < materials.Length; ++i)
        {
            materials[i].color = gradients[i].Evaluate(timeRate);
        }
    }
}