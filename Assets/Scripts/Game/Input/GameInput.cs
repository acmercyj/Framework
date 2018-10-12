/**
 * ��Ϸ����
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
    /// �ƶ�ҡ��
    /// </summary>
    public GameJoystick moveJoystick;
    /// <summary>
    /// ���̰�ťӳ��
    /// </summary>
    private static Dictionary<KeyCode, KeyState> mapKeyState = new Dictionary<KeyCode, KeyState>();

    //==========================================================================
    /// <summary>
    /// Ϊ�������׳����ⰴ���¼�
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
    /// �������ⰴ���¼�
    /// </summary>
    /// <param name="vkey">���ⰴ���ļ�ֵ</param>
    /// <param name="arg">���ⰴ������</param>
    private void HandleVKey(EVKey vkey, object arg = null)
    {
        if (OnVKey != null)
        {
            OnVKey(vkey, arg);
        }
    }

    #region ҡ�˿���
    /// <summary>
    /// ҡ���ƶ�
    /// </summary>
    public void OnJoystickMove(Vector2 dir)
    {
        HandleVKey(EVKey.Move, dir);
    }

    /// <summary>
    /// �ƶ���ʼ
    /// </summary>
    public void OnJoystickMoveStart(Vector2 dir)
    {
        HandleVKey(EVKey.MoveStart, dir);
    }

    /// <summary>
    /// �ƶ�����
    /// </summary>
    public void OnJoystickMoveEnd()
    {
        HandleVKey(EVKey.MoveEnd);
    }
    #endregion

    #region ���̿���
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
    /// �������̰�����ת��Ϊ�����ⰴ����
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
