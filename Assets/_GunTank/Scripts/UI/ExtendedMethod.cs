using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtendedMethod
{
    /// <summary>
    /// x,y방향 입력을 계산하여 지면에서 정규화된 속도 제공
    /// </summary>
    /// <param name="rb">이동 대상</param>
    /// <param name="x">X축 이동방향</param>
    /// <param name="z">Y축 이동방향</param>
    /// <param name="speed">이동속도</param>
    public static void MoveNormailzeGround(this Rigidbody rb, float x, float z, float speed)
    {
        Vector3 vector = rb.velocity;
        vector.x = x;
        vector.z = z;
        //지면이동 속도를 계산하기 위해 Y값은 0으로 고정해 정규값 계한 후 복원
        vector.y = 0;
        vector.Normalize();
        vector = rb.transform.TransformDirection(vector) * speed;

        vector.y = rb.velocity.y;

        rb.velocity = vector;
    }
}
