using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;

    //左右のフリッパーがコントロール中か
    private bool isLeftTouchControll = false;
    private bool isRightTouchControll = false;
    private int leftTouchID = -1;
    private int rightTouchID = -1;

    private float windowMiddlePosition = 0f;//ウィンドウ横幅の中央位置

	// Use this for initialization
	void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>();
        windowMiddlePosition = (float)Screen.width / 2f;
        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
        FripperAction();
    }

    private void FripperAction()
    {
        for (int i = 0; i < Input.touches.Length; i++)
        {
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                if (Input.touches[i].position.x < windowMiddlePosition)
                {
                    if (leftTouchID < 0 && tag == "LeftFripperTag")
                    {
                        leftTouchID = Input.touches[i].fingerId;
                        SetAngle(this.flickAngle);
                    }
                }
                else
                {
                    if (rightTouchID < 0 && tag == "RightFripperTag")
                    {
                        rightTouchID = Input.touches[i].fingerId;
                        SetAngle(this.flickAngle);
                    }
                }
            }
            else if (Input.touches[i].phase == TouchPhase.Ended)
            {
                if (leftTouchID > -1 && tag == "LeftFripperTag" && leftTouchID == Input.touches[i].fingerId)
                {
                    leftTouchID = -1;
                    SetAngle(this.defaultAngle);
                }

                if (rightTouchID > -1 && tag == "RightFripperTag" && rightTouchID == Input.touches[i].fingerId)
                {
                    rightTouchID = -1;
                    SetAngle(this.defaultAngle);
                }
            }
        }
        //タッチ入力が無い時はPC側の判定をする
        if (leftTouchID < 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }

        if (rightTouchID < 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }
    }

    private void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
