using UnityEngine;

namespace _Project.Scripts.Utils
{
    public class GameObjectToScreenCenter : MonoBehaviour
    {
        private Camera m_camera;
        private void Awake()
        {
            m_camera = Camera.main;
        }
        private void Update()
        {
            var screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            var ray = m_camera.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out var hit, 100f))
            {
                this.transform.position = hit.point;
            }
            else
            {
                this.transform.position = ray.GetPoint(100f);
            }
        }
    }
}