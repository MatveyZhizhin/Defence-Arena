using UnityEngine;

public class LinkProvider : MonoBehaviour
{
    public void FollowLink(string link)
    {
        Application.OpenURL(link);
    }
}