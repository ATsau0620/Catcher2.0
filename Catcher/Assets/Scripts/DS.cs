using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DS : MonoBehaviour
{
    [Header("��ܶ��j"), Range(0, 1)]
    public float interval = 0.3f;
    [Header("��ܨt��")]
    public GameObject goDialogue;
    [Header("��ܤ��e")]
    public Text textContent;
    [Header("�T����")]
    public GameObject goTip;
    [Header("��ܫ���")]
    public KeyCode keyDialogue = KeyCode.Mouse0;

    private void Start()
    {
        StartCoroutine(TypeEffect());
    }
    private IEnumerator TypeEffect()
    {
        
        string test1 = "�A�n�A���ɪ̡A�w��ѥ[���v�ɡI";
        string test2 = "�Ы��U�ƹ��k��}�l�i�J����";
        string[] test = { test1, test2 }; 

        goDialogue.SetActive(true);       //��ܹ�ܪ���
        textContent.text = "";            //�M���W����ܤ��e 


        for (int j = 0; j < test.Length; j++)
        {
            textContent.text = "";
            goTip.SetActive(false);

            for (int i = 0; i < test[j].Length; i++)
            {
                //print(test[i]);
                textContent.text += test[j][i];  //�|�[��ܤ��e����r
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