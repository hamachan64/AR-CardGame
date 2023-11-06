using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRay : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMesh counter;

    void Start()
    {
    }

    void Update()
    {
        /* �^�[�Q�b�g�̃|�W�V�������擾 */
        Vector3 targetPos = target.transform.position;

        /* �v���C���[�̃|�W�V�������擾 */
        Vector3 playerPos = player.transform.position;

        /* �^�[�Q�b�g�ƃv���C���[�̋������擾 */
        float dis = Vector3.Distance(targetPos, playerPos);

        Debug.Log(dis);
        /* �J�E���^�[ */
        //counter.text = Convert.ToString(dis);
    }
}
