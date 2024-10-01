using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeleter : MonoBehaviour
{
    // ��ʂ�Y���̍ŏ��_
    float minScreenPointY;
    // �A�C�e���̍���
    float itemHeight;
    // ��?�N���X�̃A�C�e�����X�g���g�p
    [SerializeField]
    ItemManager itemManager;
    void Start()
    {
        // �J�������ڂ��Ă����ʂ̉����̍��W���擾
        minScreenPointY = Camera.main.ViewportToWorldPoint(Vector2.down).y;
    }
    // Update is called once per frame
    void Update()
    {
        // ��������Ă���A�C�e���S�Ă�����
        foreach (var item in itemManager.items)
        {
            // �A�C�e���I�u�W�F�N�g�̍������擾
            itemHeight = item.transform.localScale.y;
            // ��ʊO�ɏo�Ă��邩�B��ʊO�ŏ����̂ō���������
            if (item.transform.position.y < minScreenPointY - itemHeight)
            {
                // �I�u�W�F�N�g��j��
                Destroy(item);
                // ��?���Ă��郊�X�g����j�󂵂��I�u�W�F�N�g�Ɠ���ID�̂��̂������[�u
                itemManager.items.RemoveAll(item_ =>
                item.GetComponent<FallItem>().ID == item_.GetComponent<FallItem>().ID);
                // �Ԋu�ŏo���Ă���Q�ȏオ��ʊO�ɏo�邱�Ƃ͖����̂ŏI��
                return;
            }
        }
    }
}