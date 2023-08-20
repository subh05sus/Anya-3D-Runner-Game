using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SIDE {Left,Mid,Right}

// public enum HitX {Left, Mid, Right, None}
// public enum HitY {Up, Mid, Down, None}
// public enum HitZ {Front, Mid, Back, None}


public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 8f;
    public SIDE m_side = SIDE.Mid;
    float NewXPose = 0f;
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    public float XValue;
    private CharacterController m_char;
    private float x;
    private float y;
    public float SpeedDodge;
    public float JumpPower = 3f;
    public bool InJump;
    public float IncreaseSpeedByTime = 0.001f;

    public bool InRoll;
    public float ColliderHeight;
    public float ColliderCenterY;
    internal float RollCounter;

    // public HitX hitX = HitX.None;
    // public HitY hitY = HitY.None;
    // public HitZ hitZ = HitZ.None;


    void Start() {
        m_char = GetComponent<CharacterController>();
        transform.position = Vector3.zero;

        ColliderHeight = m_char.height;
        ColliderCenterY = m_char.center.y;
    }
    void Update()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) ;
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) ;
        SwipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ;
        SwipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) ;

        if (!PlayerManager.isGameStarted)
        {
            return;
        }


        if (SwipeLeft || SwipeManager.swipeLeft)
        {
            if (m_side == SIDE.Mid)
            {
                NewXPose = -XValue;
                m_side = SIDE.Left;
            }
            else if (m_side == SIDE.Right)
            {
                NewXPose = 0;
                m_side = SIDE.Mid;
            }
        }
        else if (SwipeRight || SwipeManager.swipeRight)
        {
            if (m_side == SIDE.Mid)
            {
                NewXPose = XValue;
                m_side = SIDE.Right;
            }
            else if (m_side == SIDE.Left)
            {
                NewXPose = 0;
                m_side = SIDE.Mid;

            }
        }
        x = Mathf.Lerp(x, NewXPose, Time.deltaTime * SpeedDodge);
        m_char.Move((x-transform.position.x) * Vector3.right);
        m_char.Move(moveSpeed*Time.deltaTime * Vector3.forward);
        m_char.Move(y*Time.deltaTime * Vector3.up);
        Jump();
        Roll();

        if (moveSpeed<18)
        {
            moveSpeed += IncreaseSpeedByTime;
        }
        
    }

    public void Jump(){
        if (m_char.isGrounded)
        {
            if (SwipeUp || SwipeManager.swipeUp)
            {
                y = JumpPower;
                InJump= true;
            }
        }else
        {
            y -= JumpPower*2* Time.deltaTime;

        }
    }
    public void Roll()
    {
        RollCounter -= Time.deltaTime;
        if (RollCounter <= 0)
        {
            RollCounter = 0f;
            m_char.center = new Vector3(0,ColliderCenterY,0);
            m_char.height = ColliderHeight;
            InRoll = false;
        }

        if (SwipeManager.swipeDown || SwipeDown)
        {
            RollCounter = 2f;
            y -= 15f;
            m_char.center = new Vector3(0,ColliderCenterY/2f,0);
            m_char.height = ColliderHeight/2f;
            InRoll=true;
            InJump = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.transform.tag=="Obstacle")
        {
            PlayerManager.gameOver=true;
        }
    }

    // public void OnCharacterColliderHit(Collider col){
    //     hitX = GetHitX(col);
        
    // }

    // public HitX GetHitX(Collider col){
    //     Bounds char_bounds = m_char.bounds;
    //     Bounds col_bounds = col.bounds;
    //     float min_x = Mathf.Max(col_bounds.min.x, char_bounds.min.x);
    //     float max_x = Mathf.Min(col_bounds.max.x, char_bounds.max.x);
    //     float average = (min_x + max_x)/2f - col_bounds.min.x;
    //     HitX hit;
    //     if(average > col_bounds.size.x - 0.33f)
    //         hit = HitX.Right;
    //     else if(average<0.33f)
    //         hit = HitX.Left;
    //     else
    //         hit = HitX.Mid;

    //     return hit;
    // }

}