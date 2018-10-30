using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    public bool dead;

    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        if (!dead)
        {
            int size = 48;
            float posX = _camera.pixelWidth / 2 - size / 4;
            float posY = _camera.pixelHeight / 2 - size / 2;

            GUI.Label(new Rect(posX, posY, size, size), "o");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !dead)
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        sphere.transform.position = position;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
