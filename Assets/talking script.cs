using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class talkingscript : MonoBehaviour
{
    [SerializeField] TMP_Text chatlog;
    [SerializeField] TMP_InputField input;
    string content = "Hej det är jag verity vill du lära du hur man skapar vänner.";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chatlog.text = content;
    }
    public void send()
    {
        content += "\nyou: " + input.text;
        Response(input.text);
        input.text = "";
    }
        
        void Response(string msg)
    {

    }

}
