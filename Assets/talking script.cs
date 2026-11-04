using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class talkingscript : MonoBehaviour
{
    [SerializeField] TMP_Text chatlog;
    [SerializeField] TMP_InputField input;
    string content = "Hej det är jag verity jag kan lära du hur man skapar vänner.";
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
        Match match = Regex.Match(msg, "jag mår"); // varje medelande du sickar checkas omd et är med i ett patter
        if (match.Success)//om det är med i en pattern
        {
            string mående = msg.Substring(match.Index + match.Length); // tar den bort allt förutom ordet efter jag mår
            string[] svara =
            {
                 "Varför mår du" + mående,
                "Är det första gången du mår" + mående,
                "mår du ofta" + mående,
                "vad hände för att du ska känna dig" + mående,
                "kan du förklara varför du mår" + mående,
            };
            response = svara[Random.Range(0, svara.Length)]; // välj en random
            content += "\nCOSMO: " + response;

        }
        match = Regex.Match(msg, "vänner"); // använder samma variable match men tittar olikt mönster
        if (match.Success)
        {
            string gillar = msg.Substring(match.Index + match.Length);
            string[] tycker =
            {
                    "",
                    "varför tycker du så",
                    "berätta mer",
                    "intresant elaborera vidare",
                };
            response = tycker[Random.Range(0, tycker.Length)];
            content += "\nCOSMO: " + response;
        }
    }
}
