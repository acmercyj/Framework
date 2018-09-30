/**
 * 游戏输入
 */

using System;
using UnityEngine;
using System.Collections.Generic;

struct KeyState
{
    public int key;
    public float arg;
    public bool state;
}

public class GameInput : View
{
    /// <summary>
    /// 移动摇杆
    /// </summary>
    public GameJoystick moveJoystick;
    /// <summary>
    /// 键盘按钮映射
    /// </summary>
    private static Dictionary<KeyCode, KeyState> mapKeyState = new Dictionary<KeyCode, KeyState>();

    //==========================================================================
    /// <summary>
    /// 为调用者抛出虚拟按键事件
    /// </summary>
    public static Action<int, object> OnVKey { get; set; }
    public static GameInput Instance { get; private set; }
    //==========================================================================

    public void Awake()
    {
        Instance = this;
    }

    public void OnDestroy()
    {
        Instance = null;
        OnVKey = null;
    }

    private void OnEnable()
    {
        //moveJoystick.OnMove = OnJoystickMove;
        //moveJoystick.OnMoveStart = OnJoystickMoveStart;
        //moveJoystick.OnMoveEnd = OnJoystickMoveEnd;
        //attackBtn.OnDown = OnAttackDown;
        //attackBtn.Drag = OnAttackDrag;
        //attackBtn.OnUp = OnAttackUp;
        //skillBtn.OnDown = OnSkillDown;
        //skillBtn.OnUp = OnSkillUp;
    }

	private void OnDisable()
    {
        //moveJoystick.OnMove = null;
        //moveJoystick.OnMoveStart = null;
        //moveJoystick.OnMoveEnd = null;
        //attackBtn.OnDown = null;
        //attackBtn.Drag = null;
        //attackBtn.OnUp = null;
        //skillBtn.OnDown = null;
        //skillBtn.OnUp = null;
    }

    /// <summary>
    /// 处理虚拟按键事件
    /// </summary>
    /// <param name="vkey">虚拟按键的键值</param>
    /// <param name="arg">虚拟按键参数</param>
    private void HandleVKey(int vkey, object arg = null)
    {
        if (OnVKey != null)
        {
            OnVKey(vkey, arg);
        }
    }

    /// <summary>
    /// 摇杆移动
    /// </summary>
    public void OnJoystickMove(Vector2 data)
    {
        //HandleVKey(GameVKey.Move, data);
    }

    /// <summary>
    /// 移动开始
    /// </summary>
    public void OnJoystickMoveStart()
    {
        //HandleVKey(GameVKey.MoveStart);
    }

    /// <summary>
    /// 移动结束
    /// </summary>
    public void OnJoystickMoveEnd()
    {
        //HandleVKey(GameVKey.MoveEnd);
    }

    /// <summary>
    /// 攻击按下
    /// </summary>
    public void OnAttackDown()
    {
        //attackBtn.Down();
        //HandleVKey(GameVKey.ActionDown, 0);
    }

    /// <summary>
    /// 攻击摇杆
    /// </summary>
    public void OnAttackDrag(Vector2 dir)
    {
        //HandleVKey(GameVKey.ActionDrag, dir);
    }

    /// <summary>
    /// 攻击抬起
    /// </summary>
    public void OnAttackUp()
    {
        //attackBtn.Up();
        //HandleVKey(GameVKey.ActionUp, 0);
    }

    /// <summary>
    /// 技能按下
    /// </summary>
    public void OnSkillDown()
    {
        //HandleVKey(GameVKey.ActionDown, 1);
    }

    /// <summary>
    /// 技能抬起
    /// </summary>
    public void OnSkillUp()
    {
        //HandleVKey(GameVKey.ActionUp, 1);
    }
    //==========================================================================
    //键盘控制
    #region 键盘控制
    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        //HandleVKey(KeyCode.A, GameVKey.MoveX, -1, GameVKey.MoveX, 0);
        //HandleVKey(KeyCode.D, GameVKey.MoveX, 1, GameVKey.MoveX, 0);
        //HandleVKey(KeyCode.W, GameVKey.MoveY, 1, GameVKey.MoveY, 0);
        //HandleVKey(KeyCode.S, GameVKey.MoveY, -1, GameVKey.MoveY, 0);
#endif
    }

    /// <summary>
    /// 将【键盘按键】转化为【虚拟按键】
    /// </summary>
    private void HandleVKey(KeyCode key, int pressKey, float pressArg, int releaseKey, float releaseArg)
    {
        //if (!mapKeyState.ContainsKey(key)) mapKeyState.Add(key, new KeyState() { key = GameVKey.None, arg = 0, state = false });

        if (Input.GetKey(key))
        {
            if (!mapKeyState[key].state)
            {
                //HandleVKey(GameVKey.MoveStart);
                var keyState = mapKeyState[key];
                keyState.state = true;
                keyState.key = pressKey;
                keyState.arg = pressArg;
                mapKeyState[key] = keyState;
                HandleVKey(pressKey, pressArg);
            }
        }
        else
        {
            if (mapKeyState[key].state)
            {
                var keyState = mapKeyState[key];
                keyState.state = false;
                keyState.arg = 0;
                //keyState.key = GameVKey.None;
                mapKeyState[key] = keyState;
                HandleVKey(releaseKey, releaseArg);
                var end = true;
                foreach (var item in mapKeyState)
                {
                    var keyCode = item.Key;
                    var temp = item.Value;
                    if (temp.state)
                    {
                        HandleVKey(temp.key, temp.arg);
                        end = false;
                    }
                }
                //if (end)
                    //HandleVKey(GameVKey.MoveEnd);
            }
        }
    }
    #endregion
}
