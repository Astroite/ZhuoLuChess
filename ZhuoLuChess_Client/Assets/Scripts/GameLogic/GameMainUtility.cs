using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;

public partial class GameMain : MonoBehaviour
{

    [SerializeField]
    private string m_LogHelperTypeName = "GameFramework.LogHelper";

    private void Init()
    {
        InitLogHelper();
    }

    private void InitLogHelper()
    {
        if (string.IsNullOrEmpty(m_LogHelperTypeName))
        {
            return;
        }

        Type logHelperType = Utility.Assembly.GetType(m_LogHelperTypeName);
        if (logHelperType == null)
        {
            throw new GameFrameworkException(Utility.Text.Format("Can not find log helper type '{0}'.", m_LogHelperTypeName));
        }

        GameFrameworkLog.ILogHelper logHelper = (GameFrameworkLog.ILogHelper)Activator.CreateInstance(logHelperType);
        if (logHelper == null)
        {
            throw new GameFrameworkException(Utility.Text.Format("Can not create log helper instance '{0}'.", m_LogHelperTypeName));
        }

        GameFrameworkLog.SetLogHelper(logHelper);
    }
}
