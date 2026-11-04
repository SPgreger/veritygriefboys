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
        string response = "";
        Match match = Regex.Match(msg, "ja"); // varje medelande du sickar checkas omd et är med i ett patter
        if (match.Success)//om det är med i en pattern
        {
            string mående = msg.Substring(match.Index + match.Length); // tar den bort allt förutom ordet efter jag mår
            string[] svara =
            {
                
            };
            response = svara[Random.Range(0, svara.Length)]; // välj en random
        }
    }

}
