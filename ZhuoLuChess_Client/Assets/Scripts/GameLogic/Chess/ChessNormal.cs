using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhuoLuChess
{
    public class ChessNormal : ChessBase
    {
        public new bool IsEatable
        {
            get { return m_isEatable; }
            set { m_isEatable = value; }
        }
    }

}
