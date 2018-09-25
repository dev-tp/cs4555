using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    public int selectedWeapon = 0;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(selectedWeapon == i);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            transform.GetChild(selectedWeapon % transform.childCount).gameObject.SetActive(false);
            transform.GetChild(++selectedWeapon % transform.childCount).gameObject.SetActive(true);
        }
    }
}
