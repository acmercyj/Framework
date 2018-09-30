/**
 * ��Ϸ����
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
    /// �������ⰴ���¼�
    /// </summary>
    /// <param name="vkey">���ⰴ���ļ�ֵ</param>
    /// <param name="arg">���ⰴ������</param>
    private void HandleVKey(int vkey, object arg = null)
    {
        if (OnVKey != null)
        {
            OnVKey(vkey, arg);
        }
    }

    /// <summary>
    /// ҡ���ƶ�
    /// </summary>
    public void OnJoystickMove(Vector2 data)
    {
        //HandleVKey(GameVKey.Move, data);
    }

    /// <summary>
    /// �ƶ���ʼ
    /// </summary>
    public void OnJoystickMoveStart()
    {
        //HandleVKey(GameVKey.MoveStart);
    }

    /// <summary>
    /// �ƶ�����
    /// </summary>
    public void OnJoystickMoveEnd()
    {
        //HandleVKey(GameVKey.MoveEnd);
    }

    /// <summary>
    /// ��������
    /// </summary>
    public void OnAttackDown()
    {
        //attackBtn.Down();
        //HandleVKey(GameVKey.ActionDown, 0);
    }

    /// <summary>
    /// ����ҡ��
    /// </summary>
    public void OnAttackDrag(Vector2 dir)
    {
        //HandleVKey(GameVKey.ActionDrag, dir);
    }

    /// <summary>
    /// ����̧��
    /// </summary>
    public void OnAttackUp()
    {
        //attackBtn.Up();
        //HandleVKey(GameVKey.ActionUp, 0);
    }

    /// <summary>
    /// ���ܰ���
    /// </summary>
    public void OnSkillDown()
    {
        //HandleVKey(GameVKey.ActionDown, 1);
    }

    /// <summary>
    /// ����̧��
    /// </summary>
    public void OnSkillUp()
    {
        //HandleVKey(GameVKey.ActionUp, 1);
    }
    //==========================================================================
    //���̿���
    #region ���̿���
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
    /// �������̰�����ת��Ϊ�����ⰴ����
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
