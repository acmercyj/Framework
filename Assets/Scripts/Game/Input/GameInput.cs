/**
 * 游戏输入
 */

using System;
using UnityEngine;
using System.Collections.Generic;

struct KeyState
{
    public EVKey key;
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
    public static Action<EVKey, object> OnVKey { get; set; }
    public static GameInput Instance { get; private set; }
    //==========================================================================

    public void Awake()
    {
        Instance = this;
        moveJoystick.OnDown = OnJoystickMoveStart;
        moveJoystick.Drag = OnJoystickMove;
        moveJoystick.OnUp = OnJoystickMoveEnd;
    }

    public void OnDestroy()
    {
        Instance = null;
        OnVKey = null;
        moveJoystick.OnDown = null;
        moveJoystick.Drag = null;
        moveJoystick.OnUp = null;
    }

    /// <summary>
    /// 处理虚拟按键事件
    /// </summary>
    /// <param name="vkey">虚拟按键的键值</param>
    /// <param name="arg">虚拟按键参数</param>
    private void HandleVKey(EVKey vkey, object arg = null)
    {
        if (OnVKey != null)
        {
            OnVKey(vkey, arg);
        }
    }

    #region 摇杆控制
    /// <summary>
    /// 摇杆移动
    /// </summary>
    public void OnJoystickMove(Vector2 dir)
    {
        HandleVKey(EVKey.Move, dir);
    }

    /// <summary>
    /// 移动开始
    /// </summary>
    public void OnJoystickMoveStart(Vector2 dir)
    {
        HandleVKey(EVKey.MoveStart, dir);
    }

    /// <summary>
    /// 移动结束
    /// </summary>
    public void OnJoystickMoveEnd()
    {
        HandleVKey(EVKey.MoveEnd);
    }
    #endregion

    #region 键盘控制
    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        HandleVKey(KeyCode.A, EVKey.MoveX, -1, EVKey.MoveX, 0);
        HandleVKey(KeyCode.D, EVKey.MoveX, 1, EVKey.MoveX, 0);
        HandleVKey(KeyCode.W, EVKey.MoveY, 1, EVKey.MoveY, 0);
        HandleVKey(KeyCode.S, EVKey.MoveY, -1, EVKey.MoveY, 0);
#endif
    }

    /// <summary>
    /// 将【键盘按键】转化为【虚拟按键】
    /// </summary>
    private void HandleVKey(KeyCode key, EVKey pressKey, float pressArg, EVKey releaseKey, float releaseArg)
    {
        if (!mapKeyState.ContainsKey(key)) mapKeyState.Add(key, new KeyState() { key = EVKey.None, arg = 0, state = false });

        if (Input.GetKey(key))
        {
            if (!mapKeyState[key].state)
            {
                HandleVKey(EVKey.MoveStart);
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
                keyState.key = EVKey.None;
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
                if (end)
                    HandleVKey(EVKey.MoveEnd);
            }
        }
    }
    #endregion
}
