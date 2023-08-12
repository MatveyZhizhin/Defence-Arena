using Assets.Scripts.Player.Guns;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddNewGun : MonoBehaviour
{
    [SerializeField] private Gun[] guns;
    [SerializeField] private Sprite[] buttonIcons;

    private Gun newGun;
    [SerializeField] private Button newGunButton;

    private void Start()
    {
        GenerateButton();
    }

    private void GenerateButton()
    {
        newGun = guns[Random.Range(0, guns.Length)];
        foreach (var icon in buttonIcons)
        {
            if (icon.name == newGun.name)
            {
                newGunButton.GetComponent<SpriteRenderer>().sprite = icon;
                break;
            }
        }
        newGunButton?.onClick.AddListener(() => ChangeGun());
    }

    private void ChangeGun()
    {
        foreach (var gun in guns)
        {
            if(gun.gameObject.activeInHierarchy)
            {
                gun.gameObject.SetActive(false);
                newGun?.gameObject.SetActive(true);                
                break;
            }
        }
    }
}
