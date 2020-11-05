using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhuoLuChess
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        private ChessBase m_activeChessPiece;

        public ChessBase ActiveChessPiece
        {
            get { return m_activeChessPiece; }
            set
            {
                if (m_activeChessPiece != null)
                    m_activeChessPiece = value;
            }
        }
    }
}