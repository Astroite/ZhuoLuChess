using UnityEngine;

namespace ZhuoLuChess
{
    public class InputManager : Singleton<InputManager>
    {
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                PlayerManager.I.ActiveChessPiece = GetChessPiece(Input.mousePosition);
            }
        }

        //private GameObject GetChessSeat()
        //{

        //}

        private ChessBase GetChessPiece(Vector3 mousePosition)
        {
            ChessBase chessPiese = null;
            GameObject gameObject = GetRayHitGameObject(mousePosition);
            if (gameObject != null)
                chessPiese = gameObject.GetComponentInChildren<ChessBase>();
            return chessPiese;
        }

        private GameObject GetRayHitGameObject(Vector3 mousePosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                GameObject gameObject = hitInfo.collider.gameObject;
#if UNITY_EDITOR
                Debug.DrawLine(ray.origin, hitInfo.point);
                Debug.Log("click object name is " + gameObject.name);
#endif
                return gameObject;
            }
            return null;
        }
    }
}
