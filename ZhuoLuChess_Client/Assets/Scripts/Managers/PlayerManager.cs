using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ZhuoLuChess
{
    public class PlayerManager : ManagerBase
    {
        private ChessBase m_activeChessPiece;

        public bool NeedPlay;
        public Player[] Players;
        public Player Player;
        public Player currentPlayer;
        public int PlayerIndex;

        public override void Init()
        {
            //Players = new Player[2];
            //Players[0] = new Player()
            //{
            //    PlayerName = "Player One",
            //    PlayerColor = Color.red,
            //    IsFirst = true
            //};

            //Players[1] = new Player()
            //{
            //    PlayerName = "Player Two",
            //    PlayerColor = Color.green,
            //    IsFirst = false,
            //};

            //PlayerIndex = 0;
            //currentPlayer = Players[PlayerIndex];

            //Test
            Player = new Player()
            {
                PlayerName = "Player One",
                PlayerColor = Color.red,
                IsFirst = true
            };

            Player.SelectChessPiece();
        }

        public override void Update()
        {
            base.Update();
            if (NeedPlay)
            {
                
            }
        }
        
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