using Meta.XR.ImmersiveDebugger.UserInterface;
using PaintIn3D;
using UnityEngine;
using UnityEngine.UI;

public class GuideHandler : MonoBehaviour
{
    [SerializeField] Image guideImage;
    [SerializeField] CwPaintableMeshTexture cwPaintableMeshTexture;

    public void ActivateGuide(bool value)
    {
        guideImage.enabled = value;
    }

    public void ClearGuide()
    {
        cwPaintableMeshTexture.Clear();
    }


    public void SetOpacity(float value)
    {
        Color newColor = guideImage.color;
        newColor.a = value;
        guideImage.color = newColor;
    }

}
