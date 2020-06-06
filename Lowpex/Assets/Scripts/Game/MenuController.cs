using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuButton;
    public GameObject menuIcon;
    public void MenuButonClicked()
    {
        menu.SetActive(!menu.activeSelf);
        menuIcon.GetComponent<Image>().sprite = Resources.Load("Images/Menu/" + (!menu.activeSelf ? "btnIconTent" : "btnIconBattle"), typeof(Sprite)) as Sprite;
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
