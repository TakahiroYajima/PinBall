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
                    if (!isLeftTouchControll && tag == "LeftFripperTag")
                    {
                        isLeftTouchControll = true;
                        SetAngle(this.flickAngle);
                    }
                }
                else
                {
                    if (!isRightTouchControll && tag == "RightFripperTag")
                    {
                        isRightTouchControll = true;
                        SetAngle(this.flickAngle);
                    }
                }
            }
            else if (Input.touches[i].phase == TouchPhase.Ended)
            {
                if (isLeftTouchControll && tag == "LeftFripperTag")
                {
                    isLeftTouchControll = false;
                    SetAngle(this.defaultAngle);
                }
                else if (isRightTouchControll && tag == "RightFripperTag")
                {
                    isRightTouchControll = false;
                    SetAngle(this.defaultAngle);
                }
            }
        }
        //タッチ入力が無い時はPC側の判定をする
        if (!isLeftTouchControll)
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

        if (!isRightTouchControll)
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
