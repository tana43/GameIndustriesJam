using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random4 : MonoBehaviour
{
    [SerializeField] public GameObject obj;
    bool trigger = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            RectTransform t = obj.GetComponent<RectTransform>();

            // �����_���ȕ����ɒe����΂����߂Ƀ����_���ȃx�N�g���𐶐�
            float randomX = Random.Range(10f, 150f); // �����_����X�����̗�
            float randomY = Random.Range(10f, 150f); // �����_����Y�����̗�
            Vector2 randomDirection = new Vector2(randomX, randomY);

            // �ʒu�������_���ɒe����΂�
            t.anchoredPosition += randomDirection * 0.5f;

            // �����_���ȉ�]�p�x��������
            float randomAngle = Random.Range(0f, 360f);
            t.Rotate(new Vector3(0, 0, randomAngle)); // Z����]�i2D�̂��߁j

            // ��]�̌��ʂ𑦍��ɔ��f
            t.localRotation = Quaternion.Euler(0, 0, t.localRotation.eulerAngles.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger = true;
    }
}
