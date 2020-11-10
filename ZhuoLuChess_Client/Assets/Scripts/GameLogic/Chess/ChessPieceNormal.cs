using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhuoLuChess
{
    public class ChessPieceNormal : ChessPieceBase
    {
        public new bool IsEatable
        {
            get { return m_isEatable; }
            set { m_isEatable = value; }
        }
    }

}
