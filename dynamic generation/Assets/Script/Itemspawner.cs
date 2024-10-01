using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemspawner : MonoBehaviour
{
    // ��?�N���X�̃A�C�e�����X�g���g�p
    [SerializeField]
    ItemManager itemManager;

    // �쐬�ς݂�Prefab����I��
    GameObject item;

    // ��������A�C�e���̍ő�T�C�Y
    [SerializeField]
    float itemMaxSize;

    // ��������A�C�e���̍ŏ��T�C�Y
    [SerializeField]
    float itemMinSize;

    // �J��������A�C�e����Z���W��̍ŏ�����
    [SerializeField]
    float minDepth;

    // �J��������A�C�e����Z���W��̍ő勗��
    [SerializeField]
    float maxDepth;

    // �������Ԃ̊Ԋu
    [SerializeField]
    float timeInterval;

    // �o�ߎ��Ԃ𐔂���
    float currentTimer;

    // ���������A�C�e���ɕt����ID
    int setID;

    // ID�̍ő�ԍ�
    [SerializeField]
    int maxIDNum;

    // ��������A�C�e���̍��W��ݒ肵�ĕԂ�
    Vector3 GetSpawnPosition()
    {
        // ��ʂ̉E��̍��W��ݒ�
        var maxScreenPoint = Camera.main.ViewportToWorldPoint(Vector2.one);

        // ��ʂ̍ő���W�����Ƃɉ�ʏ��X���W�̃����_���̈ʒu���擾
        var randomPointX = Random.Range(-maxScreenPoint.x, maxScreenPoint.x);

        // �A�C�e���I�u�W�F�N�g�̍������擾
        var itemHeight = item.transform.localScale.y;

        // �����Ƃ�������������Ȃ��̂ŏ����ォ�琶������
        var spawnPointY = maxScreenPoint.y + itemHeight;

        // ���s���������_�}�C�Y
        var randomPointZ = Random.Range(minDepth, maxDepth);
        return new Vector3(randomPointX, spawnPointY, randomPointZ);
    }
    // �����A�C�e���̑傫����ݒ肷��
    void SetItemScale()
    {
        // �A�C�e���̑傫���������_�}�C�Y
        var randomSize = Random.Range(itemMinSize, itemMaxSize);

        // x,y,z�̃T�C�Y�䗦�͓����Őݒ�
        item.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }
    // �A�C�e���𐶐�����
    public void ItemSpawn()
    {
        // �A�C�e���̑傫����ݒ肷��
        SetItemScale();

        // ���W��ݒ肵���̂Ŕz�u
        var instanceItem = Instantiate(item, GetSpawnPosition(), Quaternion.identity);

        // ���������A�C�e����ID��t����
        SetID(instanceItem); ;

        // ���������̂ŊǗ����Ă��炤
        itemManager.items.Add(instanceItem);

    }
    // ���������A�C�e����ID��t����
    void SetID(GameObject instanceItem)
    {
        // �����ʂɎ�������̂łP���N���X��n��
        instanceItem.AddComponent<FallItem>();

        // �ԍ���t����
        instanceItem.GetComponent<FallItem>().ID = setID;

        // �ԍ��͘A�Ԃɂ���̂ŃC���N�������g
        ++setID;
    }
    // ID�̐��l���傫���Ȃ����ꍇ�Ƀ��Z�b�g��������
    void ResetID()
    {
        // �Z�b�g���Ă���ID���ݒ肵���l�𒴂��Ă��邩
        if (setID > maxIDNum)
        {
            // �Z�b�g����ID�̒l�����Z�b�g
            setID = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // ���Ԃɕt����̂ōŏ���0
        setID = 0;
        // �o�ߎ��ԂȂ̂ōŏ���0
        currentTimer = 0;
    }
    void Update()
    {
        // �Z�b�g����ID�̐��l�̃��Z�b�g�̕K�v���𒲂ׂ�
        ResetID();

        // �^�C�}�[�̎��Ԃ�i�߂�
        currentTimer += Time.deltaTime;

        // �o�ߎ��Ԃ��ݒ肵�����Ԃ𒴂��Ă��邩
        if (currentTimer >= timeInterval)
        {
            // ���ۂɐ�������A�C�e�����v���n�u���X�g���烉���_���Ɏ擾
            item = itemManager.itemPrefabs[Random.Range(0, itemManager.itemPrefabs.Length)];

            // �A�C�e�����X�|�[��
            ItemSpawn();

            // �����Ȃ����̂�0�ɒ���
            currentTimer = 0.0f;
        }
    }
}
