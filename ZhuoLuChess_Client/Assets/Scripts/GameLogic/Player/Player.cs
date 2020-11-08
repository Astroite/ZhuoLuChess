using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhuoLuChess
{
    public class Player
    {
        private GameObject m_currSelectedChessPiese;
        private GameObject m_lastSelectedChessPiece;
        private GameObject m_currSelectedChessSeat;
        private GameObject m_lastSelectedChessSeat;

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

        public void SelectChessPiece()
        {
            m_currSelectedChessPiese = null;
            Debug.Log("HHHHH");
            UMAP.I.updateHander += OnSelecteChessPiece;
        }
        public void ReleaseChessPiece()
        {
            // m_currSelectedChessPiese
            Debug.Log("WWWWWW");
            UMAP.I.updateHander -= OnSelecteChessPiece;
        }
        private void OnSelecteChessPiece()
        {
            //if (m_currSelectedChessPiese != null)
            //    return;
            //Debug.Log("1");
            GameObject gameObject = UMAP.I.InputManager.CurrentSelectedGameObject;
            if (gameObject == null || gameObject.tag == null || !gameObject.CompareTag("ChessPiece"))
                return;
            Debug.Log("2");
            m_currSelectedChessPiese = gameObject;
            gameObject = null;
            ChessBase currChessPiece = m_currSelectedChessPiese.GetComponent<ChessBase>();
            if (currChessPiece == null)
                return;
            Debug.Log("3");
            if (m_currSelectedChessPiese == m_lastSelectedChessPiece)
            {
                currChessPiece.ResetChessPieceObject();
                return;
            }
            Debug.Log("4");
            if (m_lastSelectedChessPiece != null)
            {
                ChessBase lastChessPiece = m_lastSelectedChessPiece.GetComponent<ChessBase>();
                lastChessPiece.ResetChessPieceObject();                
            }
            Debug.Log("5");
            m_lastSelectedChessPiece = m_currSelectedChessPiese;
            currChessPiece.SuspendChessPieceObject();

        }

        //public void SelectChessSeat()
        //{
        //    m_hasSelectedChessSeat = false;
        //    UMAP.I.updateHander += OnSelectedChessSeat;
        //}
        //public void OnSelectedChessSeat()
        //{
        //    if (!m_hasSelectedChessSeat)
        //    {
        //        GameObject gameObject = UMAP.I.InputManager.CurrentSelectedGameObject;
        //        if (gameObject == null || !gameObject.CompareTag("ChessPiece"))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            ChessBase chessBase;
        //        }
        //    }
        //    else
        //    {
        //        UMAP.I.updateHander -= OnSelectedChessSeat;
        //    }
        //}
    }
}