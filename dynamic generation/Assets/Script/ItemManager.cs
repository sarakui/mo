using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{//�~�炷�A�C�e���̃v���n�u
    public GameObject[] itemPrefabs;
    //���������A�C�e�����i�[
    [System.NonSerialized]
    public List<GameObject> items;
    // Start is called before the first frame update
    void Start()
    {
        //�R�[�h�ň����̂�List���X�N���v�g�ŏ�����
        items= new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
