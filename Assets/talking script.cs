using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public enum TalkingState
{
    Start,
    State1,
    State2,
    State3,
    FreeConversation,
    OnlyFeelings,
    OnlyFriends,
    FeelingResponse,
    Total
}
public class talkingscript : MonoBehaviour
{
    TalkingState CurrentTalkingState = TalkingState.Start;
    [SerializeField] TMP_Text chatlog;
    [SerializeField] TMP_InputField input;
    string content = "Hej det är jag verity jag kan lära dig hur man skapar vänner. skirv numbret brevid alrenativet för att börja, 1 starta koversation 2 hur skapar man vänner 3 börja skapa vänner. ";
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
    public void PrintQuestion(string aContentToAdd)
    {
        content += aContentToAdd;
    }
    void Response(string msg)
    {
        string response = "";
        Match match = null;
        switch (CurrentTalkingState)
        {
            case TalkingState.Start:
                CheckState1(msg,ref response);
                CheckState2(msg, ref response);
                CheckState3(msg,ref response);
                break;
            case TalkingState.State1:
                CheckStateFeelings(msg, ref response);
                CheckStateFriends(msg, ref response);
                break;
            case TalkingState.State3:
                break;
            case TalkingState.FreeConversation:
                CheckStateFeelings(msg, ref response);
                CheckStateFriends(msg, ref response);
                break;
            case TalkingState.OnlyFeelings:
                CheckStateFeelings(msg,ref response);
                break;
            case TalkingState.OnlyFriends:
                CheckStateFriends(msg, ref response);
                break;
            case TalkingState.FeelingResponse:
                CheckStateFriends(msg, ref response);
                break;
            default:
                break;

        }
     
    }

    private Match CheckStateFriends(string msg, ref string response)
    {
        Match match;
        match = Regex.Match(msg, "vänner"); // använder samma variable match men tittar olikt mönster
        if (match.Success)
        {
            string gillar = msg.Substring(match.Index + match.Length);
            string[] tycker =
            {
                    "",
                    "varför tycker du så",
                    "berätta mer",
                    "intressant elaborera vidare",
                };
            response = tycker[Random.Range(0, tycker.Length)];
            content += "\nVerity: " + response;
            //CurrentTalkingState = TalkingState.Teacha
        }

        return match;
    }

    private Match CheckStateFeelings(string msg, ref string response)
    {
        Match match;
        match = Regex.Match(msg, "jag mår"); // varje medelande du sickar checkas omd et är med i ett patter
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
            content += "\nVerity: " + response;
            CurrentTalkingState = TalkingState.FeelingResponse;

        }

        return match;
    }

    private Match CheckState1(string msg, ref string response)
    {
        Match match = Regex.Match(msg, "1"); // varje medelande du sickar checkas omd et är med i ett patter
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
            PrintQuestion("\nVerity: " + " Hej hej vad hetter du");
            CurrentTalkingState = TalkingState.State1;

 
        }
        return match;

    }
    private Match CheckState2(string msg, ref string response)
    {
        Match match = Regex.Match(msg, "2"); // varje medelande du sickar checkas omd et är med i ett patter
        if (match.Success)//om det är med i en pattern
        {
            //string mående = msg.Substring(match.Index + match.Length); // tar den bort allt förutom ordet efter jag mår
            //string[] svara =
            //{
            //     "Varför mår du" + mående,
            //    "Är det första gången du mår" + mående,
            //    "mår du ofta" + mående,
            //    "vad hände för att du ska känna dig" + mående,
            //    "kan du förklara varför du mår" + mående,
            //};
            //response = svara[Random.Range(0, svara.Length)]; // välj en random
            content += "\nVerity: " + " Jag är nu i state 2: starta koversation";
            CurrentTalkingState = TalkingState.State2;


        }
        return match;
    }
    private Match CheckState3(string msg, ref string response)
    {
        Match match = Regex.Match(msg, "3"); // varje medelande du sickar checkas omd et är med i ett patter
        if (match.Success)//om det är med i en pattern
        {
            //string mående = msg.Substring(match.Index + match.Length); // tar den bort allt förutom ordet efter jag mår
            //string[] svara =
            //{
            //     "Varför mår du" + mående,
            //    "Är det första gången du mår" + mående,
            //    "mår du ofta" + mående,
            //    "vad hände för att du ska känna dig" + mående,
            //    "kan du förklara varför du mår" + mående,
            //};
            //response = svara[Random.Range(0, svara.Length)]; // välj en random
            content += "\nVerity: " + " Jag är nu i state 3: starta koversation";
            CurrentTalkingState = TalkingState.State3;


        }
        return match;
    }

}
