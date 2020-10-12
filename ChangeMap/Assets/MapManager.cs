using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [Header("地圖編號：0 1 2")]
    public int[] indexesMap = { 0, 1, 2 };
    [Header("地圖的圖片，按造順序放：0 1 2")]
    public Sprite[] spritesMap = new Sprite[3];
    [Header("介面：要變更圖片的 Image - 左 中 右")]
    public Image[] imagesMap = new Image[3];

    /// <summary>
    /// 變更地圖
    /// </summary>
    /// <param name="value">往右：-1，往左：1</param>
    public void ChangeMap(int value)
    {
        for (int i = 0; i < indexesMap.Length; i++)                                 // 迴圈執行每一張地圖
        {
            indexesMap[i] += value;                                                 // 改變編號，往右就全體 -1，往左 +1
            if (indexesMap[i] == indexesMap.Length) indexesMap[i] = 0;              // 判斷 如果 編號 = 長度 (超出最大範圍) 就歸 0
            if (indexesMap[i] == -1) indexesMap[i] = indexesMap.Length - 1;         // 判斷 如果 編號 = -1 (超出最小範圍) 就改為最大值 - (長度 - 1)
        }

        for (int i = 0; i < imagesMap.Length; i++)                                  // 迴圈更新每張地圖
        {
            int index = indexesMap[i];                                              // 每張地圖的編號
            imagesMap[i].sprite = spritesMap[index];                                // 圖片改為對應的圖片
        }
    }
}
