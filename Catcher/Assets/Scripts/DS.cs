using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DS : MonoBehaviour
{
    [Header("對話間隔"), Range(0, 1)]
    public float interval = 0.3f;
    [Header("對話系統")]
    public GameObject goDialogue;
    [Header("對話內容")]
    public Text textContent;
    [Header("三角形")]
    public GameObject goTip;
    [Header("對話按鍵")]
    public KeyCode keyDialogue = KeyCode.Mouse0;

    private void Start()
    {
        StartCoroutine(TypeEffect());
    }
    private IEnumerator TypeEffect()
    {
        
        string test1 = "你好，參賽者，歡迎參加本競賽！";
        string test2 = "請按下空白鍵開始進入比賽";
        string[] test = { test1, test2 }; 

        goDialogue.SetActive(true);       //顯示對話物件
        textContent.text = "";            //清除上次對話內容 


        for (int j = 0; j < test.Length; j++)
        {
            textContent.text = "";
            goTip.SetActive(false);

            for (int i = 0; i < test[j].Length; i++)
            {
                //print(test[i]);
                textContent.text += test[j][i];  //疊加對話內容的文字
                yield return new WaitForSeconds(interval);
            }

            goTip.SetActive(true);

            while (!Input.GetKeyDown(keyDialogue))
            {
                yield return null;
            }
        }

        goDialogue.SetActive(false);
    }
}
