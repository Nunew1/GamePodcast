using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public float typingSpeed = 0.02f;
    public Image characterImage;

    public Sprite marioSprite;
    public Sprite nouvelSprite;
    public Sprite roadsignSprite;

    private Dictionary<string, Sprite> characterSprites;
    private Queue<string> sentences;
    private bool isTyping = false;
    private string currentSentence;

    void Start()
    {
        sentences = new Queue<string>();

        // Initialize the dictionary with character sprites
        characterSprites = new Dictionary<string, Sprite>
        {
            { "Mario", marioSprite },
            { "Nouvel", nouvelSprite },
            { "Roadsign", roadsignSprite }
        };

        string[] dialogueLines = new string[]
        {
            "Mario: Hello and welcome to our podcast called the 'Kontollers'! I'm your host, Mario, and today we're diving into a topic that's been on everyone's mind lately.",
            "Nouvel: And I'm Nouvel, your co-host. We've got a fantastic episode lined up for you today. But first, Mario, what have you been playing lately?",
            "Mario: Ah, glad you asked! I've been completely absorbed in 'Mystic Realms'. The new update is incredible. What about you, Nouvel?",
            "Nouvel: I've been hooked on 'Galactic Conquest'. It's been a real challenge, but I love it. And speaking of challenges, we've got a guest today who knows all about overcoming them.",
            "Mario: That's right! Joining us is Roadsign, a game designer and industry expert. Roadsign, welcome to the show!",
            "Roadsign: Thanks for having me, Mario and Nouvel. It's great to be here.",
            "Nouvel: Roadsign, before we get into the main topic, could you tell our listeners a bit about your background and what got you into game design?",
            "Roadsign: Sure thing, Nouvel. I've been passionate about games since I was a kid. I started out modding games in high school, which eventually led me to pursue a career in game design. Now, I work on developing immersive and innovative gaming experiences.",
            "Mario: That's amazing, Roadsign. Today, we're going to discuss the rise of narrative-driven games. What do you think has led to their increasing popularity?",
            "Roadsign: I think it's a combination of factors. Players are looking for deeper, more meaningful experiences. Narrative-driven games offer that by providing compelling stories and characters that players can connect with.",
            "Nouvel: Absolutely. It's fascinating how storytelling has evolved in games. Speaking of which, let's dive into some examples. What narrative-driven game has recently impressed you, Roadsign?",
            "Roadsign: I'd have to say 'Celestial Journey'. The way it intertwines gameplay with story is just phenomenal. Each decision you make feels impactful and shapes the outcome of the game.",
            "Mario: That sounds incredible. For our listeners who might be new to narrative-driven games, what would you recommend as a starting point?",
            "Roadsign: I'd suggest starting with 'Life is Strange' or 'The Walking Dead' series by Telltale Games. They're both fantastic examples of how powerful storytelling can be in games.",
            "Nouvel: Great recommendations, Roadsign. Before we wrap up, any last tips for aspiring game designers out there?",
            "Roadsign: Yes, keep creating and experimenting. Don't be afraid to take risks and tell the stories you want to tell. The industry is always looking for fresh perspectives.",
            "Mario: Wise words, Roadsign. Thank you so much for joining us today. It's been a pleasure having you on the show.",
            "Roadsign: Thanks for having me, Mario and Nouvel. It's been fun.",
            "Nouvel: And to our listeners, thanks for tuning in to this episode of 'Kontollers'. Don't forget to subscribe and leave a review. We'll be back next week with more gaming insights and discussions.",
            "Mario: Until next time, keep playing and stay curious. This is Mario and Nouvel, signing off.",
            "Mario: ton lu suka gamenya ga?",
            "Roadsign: oh ya ton, lu pura pura sakit ya"
        };

        StartDialogue(dialogueLines);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = currentSentence;
                isTyping = false;
            }
            else
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(string[] dialogueLines)
    {
        dialogueBox.SetActive(true);
        sentences.Clear();

        foreach (string line in dialogueLines)
        {
            sentences.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string speaker = sentence.Split(':')[0];
        UpdateCharacterSprite(speaker);
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        currentSentence = sentence;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void UpdateCharacterSprite(string speaker)
    {
        if (characterSprites.ContainsKey(speaker))
        {
            characterImage.sprite = characterSprites[speaker];
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
