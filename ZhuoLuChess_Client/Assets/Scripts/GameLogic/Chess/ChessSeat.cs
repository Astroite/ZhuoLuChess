using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFLog = GameFramework.GameFrameworkLog;

namespace ZhuoLuChess
{
    public enum ChessSeatState
    {
        Empty = 0,
        Occupy,
        Ruins
    }

    public class ChessSeat : MonoBehaviour
    {
        private ChessSeatState m_seatState;

        public ChessPieceBase ChessPiece { get; set; }

        public void PreviewEffect(GameObject chessPiece)
        {
            GFLog.Debug("Preview");
        }

        public void ClearPreview()
        {
            GFLog.Debug("Clear Preview");
        }

        public void BeginDropEffect()
        {
            GFLog.Debug("Drop Down");
        }

        public void BeginGoalEffect()
        {
            GFLog.Debug("Goal Effect");
        }


    }
}

