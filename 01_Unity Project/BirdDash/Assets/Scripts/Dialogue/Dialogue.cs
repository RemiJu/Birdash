using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject textBox;
    public TMP_Text textComponent;

    public TextAsset textFile;
    public string[] lines;
    
    public float textSpeed;

    public int currentLine;
    public int endAtLine;

    public int currentBird;

    public GameObject[] Customers;

    // Start is called before the first frame update

    public void Awake()
    {
        if (textFile != null)
        {
            lines = (textFile.text.Split("\n"));

        }

        if (endAtLine == 0)
        {
            endAtLine = lines.Length - 1;

        }
        textBox.SetActive(false);
        currentLine = 0;


    }

    void Start()
    {
        //textComponent.text = string.Empty;
        //StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLine > endAtLine) {
            currentLine = 0;
        }
        //if (Input.GetMouseButtonDown(0)) //left mouse button
        //{
        //    NextLine();
        //}
        //else
        //{
        //    StopAllCoroutines();
        //    textComponent.text = lines[index];
        //}                           
    }

    public void StartDialogue(int currentLine)
    {
        //index = 0;
        
        //textComponent.text = lines[currentLine];
        StartCoroutine(TypeLine(currentLine));
    }

    IEnumerator TypeLine(int currentLine)
    {
        textBox.SetActive(true);
        currentBird = Random.Range(0, Customers.Length);
        Customers[currentBird].gameObject.SetActive(true);  
        foreach (char c in lines[currentLine].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(2.5f);
        textBox.SetActive(false);
        textComponent.text = "";
        Customers[currentBird].gameObject.SetActive(false);
    }

    //void NextLine()
    //{
    //    if (index < lines.Length -1)
    //    {
    //        index++;
    //        textComponent.text = string.Empty;
    //        StartCoroutine(TypeLine());
    //    }
    //    else
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
