using System.Collections;
using UnityEngine;

public class DialogueSystem : MonoBehaviour

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
        //StartCoroutine(TypeEffect());
    }
    private IEnumerator TypeEffect(string[] contents)
    {
        //�󴫦W�٧ֱ��� ctrl+ R R 
        //���ե�
        //string test1 = "���o�A�A�n~";
        //string test2 = "�ĤG�q���~";
        //string[] contents = { test1, test2 }; 

        goDialogue.SetActive(true);       //��ܹ�ܪ���

        for (int j = 0; j < contents.Length; j++)
        {
            textContent.text = "";            //�M���W����ܤ��e 
            goTip.SetActive(false);
            
            for (int i = 0; i < contents[j].Length; i++)
            {
                //print(test[i]);
                textContent.text += contents[j][i];  //�|�[��ܤ��e����r
                yield return new WaitForSeconds(interval);
            }

            goTip.SetActive(true);

            while(!Input.GetKeyDown(keyDialogue))
            {
                yield return null; 
            }
        }

        goDialogue.SetActive(false);
    }


    /// <summary>
    /// �}�l���
    /// </summary>
    /// <param name="contents">�n��ܥ��r�ĪG����ܤ��e</param>
    public void StartDialogue(string[] contents) 
    {
        StartCoroutine(TypeEffect(contents));
    }


    /// <summary>
    ///������ 
    /// </summary>
    public void StopDialogue()
    {
        StopAllCoroutines();             //�����{
        goDialogue.SetActive(false);     //���ù�ܤ���       
    }
}
