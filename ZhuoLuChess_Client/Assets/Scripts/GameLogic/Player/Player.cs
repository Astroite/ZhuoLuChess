using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFLog = GameFramework.GameFrameworkLog;

namespace ZhuoLuChess
{
    public class Player
    {
        private GameObject m_currSelectedChessPiese;
        private GameObject m_lastSelectedChessPiece;
        private GameObject m_currSelectedChessSeat;
        private GameObject m_lastSelectedChessSeat;

        public List<ChessPieceBase> Chesses;

        public bool IsFirst { get; set; }
        public string PlayerName { get; set; }
        public Color PlayerColor { get; set; }

        public Player()
        {
            PlayerName = "DefaultPlayer";
            PlayerColor = Color.red;
            IsFirst = true;
            Chesses = new List<ChessPieceBase>();
        }
        public Player(string playerName, Color playerColor, bool isFirst)
        {
            PlayerName = playerName;
            PlayerColor = playerColor;
            IsFirst = isFirst;
            Chesses = new List<ChessPieceBase>();
            for (int i = 0; i < 12; i++)
            {
                ChessPieceNormal chessPiece = new ChessPieceNormal();
                Chesses.Add(chessPiece);
            }
        }
        public Player(string playerName, Color playerColor, bool isFirst, List<ChessPieceBase> specialChesses)
        {
            PlayerName = playerName;
            PlayerColor = playerColor;
            IsFirst = isFirst;
            Chesses = specialChesses;
            for (int i = 0; i < 12 - specialChesses.Count; i++)
            {
                ChessPieceNormal chessPiece = new ChessPieceNormal();
                Chesses.Add(chessPiece);
            }
        }

        #region Select Chess Piece
        public void BeginSelectChessPiece()
        {
            m_currSelectedChessPiese = null;
            m_lastSelectedChessPiece = null;
            UMAP.I.InputManager.NeedMonitorChessPiece = true;
            UMAP.I.updateHander += OnSelecteChessPiece;
        }
        public void EndSelectChessPiece()
        {
            UMAP.I.InputManager.NeedMonitorChessPiece = false;
            UMAP.I.updateHander -= OnSelecteChessPiece;
        }
        private void OnSelecteChessPiece()
        {
            GameObject gameObject = UMAP.I.InputManager.CurrentSelectedGameObject;
            if (gameObject == null || gameObject.tag == null || !gameObject.CompareTag("ChessPiece"))
                return;

            m_currSelectedChessPiese = gameObject;
            UMAP.I.InputManager.ClearCurrentSelectedObject();
            ChessPieceBase currChessPiece = m_currSelectedChessPiese.GetComponent<ChessPieceBase>();
            if (currChessPiece == null)
                return;

            if (m_currSelectedChessPiese == m_lastSelectedChessPiece)
            {
                currChessPiece.SwitchChessPieceStatue();
                return;
            }

            if (m_lastSelectedChessPiece != null)
            {
                ChessPieceBase lastChessPiece = m_lastSelectedChessPiece.GetComponent<ChessPieceBase>();
                lastChessPiece.ResetChessPieceObject();                
            }

            m_lastSelectedChessPiece = m_currSelectedChessPiese;
            currChessPiece.SuspendChessPieceObject();

        }
        #endregion

        #region Select Chess Seat
        public void BeginSelectChessSeat()
        {
            m_currSelectedChessSeat = null;
            m_lastSelectedChessSeat = null;
            UMAP.I.InputManager.NeedMonitorChessSeat = true;
            UMAP.I.updateHander += OnPointAtChessSeat;
            UMAP.I.updateHander += OnSelectChessSeat;
        }
        public void EndSelectChessSeat()
        {
            UMAP.I.InputManager.NeedMonitorChessSeat = false;
            UMAP.I.updateHander -= OnPointAtChessSeat;
            UMAP.I.updateHander -= OnSelectChessSeat;
        }
        private void OnPointAtChessSeat()
        {
            GameObject pointedSeat = UMAP.I.InputManager.CurrentPointedGameObject;
            if (pointedSeat == null || pointedSeat.tag == null || !pointedSeat.CompareTag("ChessSeat"))
                return;

            m_currSelectedChessSeat = pointedSeat;
            UMAP.I.InputManager.ClearCurrentSelectedObject();
            ChessSeat currChessSeat = m_currSelectedChessSeat.GetComponent<ChessSeat>();
            if (currChessSeat == null)
                return;

            if (m_lastSelectedChessSeat == m_currSelectedChessSeat)
            {
                //ChessSeat.SwitchChessPieceStatue();
                return;
            }

            if (m_lastSelectedChessSeat != null)
            {
                ChessSeat lastChessSeat = m_lastSelectedChessSeat.GetComponent<ChessSeat>();
                // lastChessSeat.ResetChessPieceObject();
            }

            m_lastSelectedChessSeat = m_currSelectedChessSeat;
            currChessSeat.SuspendChessPieceObject();
        }
        private void OnSelectChessSeat()
        {
            GameObject gameObject = UMAP.I.InputManager.CurrentSelectedGameObject;
            if (gameObject == null || gameObject.tag == null || !gameObject.CompareTag("ChessPiece"))
                return;

            m_currSelectedChessPiese = gameObject;
            UMAP.I.InputManager.ClearCurrentSelectedObject();
            ChessPieceBase currChessPiece = m_currSelectedChessPiese.GetComponent<ChessPieceBase>();
            if (currChessPiece == null)
                return;

            if (m_currSelectedChessPiese == m_lastSelectedChessPiece)
            {
                currChessPiece.SwitchChessPieceStatue();
                return;
            }

            if (m_lastSelectedChessPiece != null)
            {
                ChessPieceBase lastChessPiece = m_lastSelectedChessPiece.GetComponent<ChessPieceBase>();
                lastChessPiece.ResetChessPieceObject();
            }

            m_lastSelectedChessPiece = m_currSelectedChessPiese;
            currChessPiece.SuspendChessPieceObject();
        }
        #endregion
    }
}