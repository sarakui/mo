using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �A�C�e�����������Ă���}�e���A���̐F��?�V����
public class ItemColor : MonoBehaviour
{
    // �쐬���Ă������}�e���A��
    [SerializeField]
    Material[] materials;
    // �A�C�e���ɂ���F�̃O���f�[�V�����̐ݒ�
    [SerializeField]
    Gradient[] gradients;
    // �o�ߎ��Ԃ𐔂���
    float currentTimer;
    // �ݒ肵���O���f�[�V�����̕ω����������鎞��
    [SerializeField]
    float changedTime;
    void Start()
    {
        // �o�ߎ��ԂȂ̂ōŏ���0
        currentTimer = 0;
    }
    void Update()
    {
        // ���Ԃ�i�߂�
        currentTimer += Time.deltaTime;
        // �O���f�[�V������i�߂�
        UpdateItemColor();
    }
    // �O���f�[�V������i�߂�
    void UpdateItemColor()
    {
        // �J�E���^�[���K��l��ς�����1.0������
        var timeRate = Mathf.Min(1.0f, currentTimer / changedTime);
        // �O���f�[�V�����̕�?���I������
        if (timeRate == 1.0f)
        {
            // �o�ߎ��Ԃ�0�ɖ߂����ŐF�̕ω������[�v
            currentTimer = 0.0f;
        }
        // �}�e���A���̐F���?���Ă���(�O���f�[�V����)
        for (int i = 0; i < materials.Length; ++i)
        {
            materials[i].color = gradients[i].Evaluate(timeRate);
        }
    }
}