using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public Vector3 pos{
        get{
            return (this.transform.position);
        }
        set{
            this.transform.position = value;
        }
    } 
    public enum MoveType{
        horizontal,
        vertical
    }
    public MoveType moveType = MoveType.vertical;
    private Vector3[] points;
    //出生时间
    private float birthTime;
    //移动速度
    public float moveSpeed = 10;
    // 移动距离
    public float moveDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if (moveType == MoveType.vertical){
            VerticalMove();
        }
        if (moveType == MoveType.horizontal){
            HorizontalMove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // 垂直移动
    void VerticalMove()
    {
        points = new Vector3[2];
        Vector3 v = Vector3.zero;
        v.x = pos.x;
        v.y = pos.y + moveDistance;
        points[0] = v;

        v.y = pos.y - moveDistance;
        points[1] = v;
    }

    // 水平移动
    void HorizontalMove()
    {
        points = new Vector3[2];
        Vector3 v = Vector3.zero;
        v.y = pos.y;
        v.x = pos.x + moveDistance;
        points[0] = v;

        v.x = pos.x - moveDistance;
        points[1] = v;
    }
    public virtual void Move(){
        // 根据时间来调整位置
        float u = (Time.time - birthTime) / moveSpeed;

        //通过一个基于正弦曲线的平滑曲线调整u值
        u = 0.5f * (Mathf.Sin(2 * Mathf.PI * u) + 1);

        //在两点之间插值
        pos = (1 - u) * points[0] + u * points[1];

    }

}
