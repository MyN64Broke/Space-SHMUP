using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    [Header("Set in Inspector")]
    public float waveFrquency = 2;
    public float waveWidth = 4;
    public float waveRotY = 45;
    private float x0;
    private float birthTime;

    void Start(){
        x0 = pos.x;
        birthTime = Time.time;
    }

    public override void Move(){
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrquency;
        float sin  = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);
    }

    // Update is called once per frame
    void Update(){
        Move();
    }
}
