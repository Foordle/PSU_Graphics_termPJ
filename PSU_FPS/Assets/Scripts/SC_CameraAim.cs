using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CameraAim : MonoBehaviour
{
    public Texture2D AimTexture;
    public Rect AimRect;

    [SerializeField]
    private float aimSizeMultiplier = 0.1f; // ���� ũ�� ����

    [Header("RGB ���� ���� (255 ����)")]
    [Range(0, 255)]
    public int red = 255; // R�� (�⺻ ���)
    [Range(0, 255)]
    public int green = 255; // G��
    [Range(0, 255)]
    public int blue = 255; // B��
    [Range(0, 255)]
    public int alpha = 255; // ���� �� (�⺻ ������)

    // Start is called before the first frame update
    void Start()
    {
        float aimWidth = AimTexture.width * aimSizeMultiplier;
        float aimHeight = AimTexture.height * aimSizeMultiplier;

        AimRect = new Rect(
            (Screen.width - aimWidth) / 2,
            (Screen.height - aimHeight) / 2,
            aimWidth,
            aimHeight
        );
    }

    private void OnGUI()
    {
        // RGB ���� 255���� 0~1�� ��ȯ
        Color aimColor = new Color(red / 255f, green / 255f, blue / 255f, alpha / 255f);

        // GUI�� ������ ����
        GUI.color = aimColor;
        GUI.DrawTexture(AimRect, AimTexture);

        // GUI ������ �⺻������ ����
        GUI.color = Color.white;
    }
}
