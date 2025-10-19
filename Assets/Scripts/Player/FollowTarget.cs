using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 offset;

    void Start()
    {
        //�J�����ƃ^�[�Q�b�g�̊Ԃ̋���
        offset = gameObject.transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        //�J�������^�[�Q�g��2�_�ԋ����𑫂����ʒu�ɌŒ�
        gameObject.transform.position = target.transform.position + offset;
    }
}
