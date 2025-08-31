using System.Collections.Generic;
using UnityEngine;

public class MenuChanger : MonoBehaviour
{
    [SerializeField] private List<Menu> _menus = new List<Menu>();

    public void SetMenu(MenuNames name)
    {
        foreach (Menu menu in _menus)
        {
            if (menu.Name == name)
                menu.Show();
            else
                menu.Hide();
        }
    } 
}
