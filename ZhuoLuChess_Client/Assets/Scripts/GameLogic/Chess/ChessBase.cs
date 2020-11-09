using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFLog = GameFramework.GameFrameworkLog;

namespace ZhuoLuChess
{
    public enum ChessStatue
    {
        Normal = 0,
        Suspend = 1        
    }

    public class ChessBase : MonoBehaviour
    {
        private string[] ChessStatus;
        private ChessStatue m_chessStatue;

        protected bool m_isEatable;

        private void Start()
        {
            m_chessStatue = ChessStatue.Normal;
            ChessStatus = Enum.GetNames(typeof(ChessStatue));
        }

        public bool IsEatable
        {
            get { return true; }
        }

        public void SuspendChessPieceObject()
        {
            m_chessStatue = ChessStatue.Suspend;
            GFLog.Debug(gameObject.name + " is " + ChessStatus[(int)m_chessStatue]);
        }

        public void ResetChessPieceObject()
        {
            m_chessStatue = ChessStatue.Normal;
            GFLog.Debug(gameObject.name + " is " + ChessStatus[(int)m_chessStatue]);
        }

        public void SwitchChessPieceStatue()
        {
            int index = (int)m_chessStatue;
            m_chessStatue = (ChessStatue)(++index % ChessStatus.Length);
            GFLog.Debug(gameObject.name + " is " + ChessStatus[(int)m_chessStatue]);
        }
    }
}

