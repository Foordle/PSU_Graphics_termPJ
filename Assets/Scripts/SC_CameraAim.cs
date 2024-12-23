using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CameraAim : MonoBehaviour
{
    public Texture2D AimTexture;
    public Rect AimRect;

    [SerializeField]
    private float aimSizeMultiplier = 0.1f; // 에임 크기 배율

    [Header("RGB 필터 조정 (255 기준)")]
    [Range(0, 255)]
    public int red = 255; // R값 (기본 흰색)
    [Range(0, 255)]
    public int green = 255; // G값
    [Range(0, 255)]
    public int blue = 255; // B값
    [Range(0, 255)]
    public int alpha = 255; // 투명도 값 (기본 불투명)

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
        // RGB 값을 255에서 0~1로 변환
        Color aimColor = new Color(red / 255f, green / 255f, blue / 255f, alpha / 255f);

        // GUI의 색상을 변경
        GUI.color = aimColor;
        GUI.DrawTexture(AimRect, AimTexture);

        // GUI 색상을 기본값으로 복원
        GUI.color = Color.white;
    }
}
