using UnityEngine;

namespace ZhuoLuChess
{
    public class InputManager
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                UMAP.I.PlayerManager.ActiveChessPiece = GetChessPiece(Input.mousePosition);
            }
        }

        //private GameObject GetChessSeat()
        //{

        //}

        private ChessBase GetChessPiece(Vector3 mousePosition)
        {
            ChessBase chessPiese = null;
            GameObject gameObject = GetRayHitGameObject(mousePosition);
#if UNITY_EDITOR
            GameObject parent = gameObject.transform.parent.gameObject;
            GameObject grandParent = parent.transform.parent.gameObject;
            Debug.Log(grandParent.name + " " + parent.name);
#endif
            if (gameObject != null)
                chessPiese = gameObject.GetComponentInChildren<ChessBase>();
            return chessPiese;
        }

        private GameObject GetRayHitGameObject(Vector3 mousePosition)
        {
            // TODO Camera.main => CameraManager.ActiveCamera
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                GameObject gameObject = hitInfo.collider.gameObject;
#if UNITY_EDITOR
                Debug.DrawLine(ray.origin, hitInfo.point);
#endif
                return gameObject;
            }
            return null;
        }
    }
}
