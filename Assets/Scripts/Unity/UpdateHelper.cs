/**
 * Update
 */

using UnityEngine;

public delegate void UpdaterEvent();

public class UpdateHelper : MonoBehaviour
{
    public static UpdateHelper Instance;

    private event UpdaterEvent UpdateEvent;
    private event UpdaterEvent FixedUpdateEvent;

    /// <summary>
    /// 单例
    /// </summary>
    private void Start()
    {
        Instance = this;
    }

    /// <summary>
    /// 添加Update的监听事件
    /// </summary>
    public static void AddUpdateListener(UpdaterEvent listener)
    {
        if (Instance != null)
        {
            Instance.UpdateEvent += listener;
        }
    }

    /// <summary>
    /// 删除Update的监听事件
    /// </summary>
    public static void RemoveUpdateListener(UpdaterEvent listener)
    {
        if (Instance != null)
        {
            Instance.UpdateEvent -= listener;
        }
    }

    /// <summary>
    /// 添加FixedUpdateEvent的监听事件
    /// </summary>
    public static void AddFixedUpdateListener(UpdaterEvent listener)
    {
        if (Instance != null)
        {
            Instance.FixedUpdateEvent += listener;
        }
    }

    /// <summary>
    /// 删除FixedUpdateEvent的监听事件
    /// </summary>
    public static void RemoveFixedUpdateListener(UpdaterEvent listener)
    {
        if (Instance != null)
        {
            Instance.FixedUpdateEvent -= listener;
        }
    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    private void Update()
    {
        if (UpdateEvent != null)
        {
            UpdateEvent();
        }
    }

    /// <summary>
    /// Fixeds the update.
    /// </summary>
    private void FixedUpdate()
    {
        if (FixedUpdateEvent != null)
        {
            FixedUpdateEvent();
        }
    }
}
