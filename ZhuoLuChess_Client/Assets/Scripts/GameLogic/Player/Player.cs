using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhuoLuChess
{
    public class Player
    {
        private bool m_hasSelectedChessPiece;
        private bool m_hasSelectedChessSeat;

        public List<ChessBase> Chesses;

        public bool IsFirst { get; set; }
        public string PlayerName { get; set; }
        public Color PlayerColor { get; set; }

        public Player()
        {
            PlayerName = "DefaultPlayer";
            PlayerColor = Color.red;
            IsFirst = true;
            Chesses = new List<ChessBase>();
        }
        public Player(string playerName, Color playerColor, bool isFirst)
        {
            PlayerName = playerName;
            PlayerColor = playerColor;
            IsFirst = isFirst;
            Chesses = new List<ChessBase>();
            for (int i = 0; i < 12; i++)
            {
                ChessNormal chessPiece = new ChessNormal();
                Chesses.Add(chessPiece);
            }
        }
        public Player(string playerName, Color playerColor, bool isFirst, List<ChessBase> specialChesses)
        {
            PlayerName = playerName;
            PlayerColor = playerColor;
            IsFirst = isFirst;
            Chesses = specialChesses;
            for (int i = 0; i < 12 - specialChesses.Count; i++)
            {
                ChessNormal chessPiece = new ChessNormal();
                Chesses.Add(chessPiece);
            }
        }

        public void ChooseChessPiece()
        {
            m_hasSelectedChessPiece = false;
            UMAP.I.updateHander += ChooseChessPieceAction;
        }
        private void ChooseChessPieceAction()
        {
            if (!m_hasSelectedChessPiece)
            {
                //UMAP.I.InputManager.
            }
        }
        
        public void ChooseChessSeat()
        {
            m_hasSelectedChessSeat = false;
            UMAP.I.InputManager
        }
        public void ChooseChessSeatAction()
        {

        }
    }
}

