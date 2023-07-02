using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookSheet : MonoBehaviour
{
    public Text titletxt;
    public Text contentTxt;
    public GameObject panelbook;

    //public Animator animator;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        panelbook.SetActive(false);
    }


	public void StartDialogueEnglish(DialogueEnglish dialogue)
	{
		//animator.SetBool("IsOpen", true);

		panelbook.SetActive(true);

		titletxt.text = dialogue.name;

		sentences.Clear();



		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}


	public void StartDialogue(Dialogue dialogue)
	{
		//animator.SetBool("IsOpen", true);

		panelbook.SetActive(true);

		titletxt.text = dialogue.name;

		sentences.Clear();



		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	private void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button3))
		{
			EndDialogue();
		}
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		FindObjectOfType<AudioManager>().Play("Button");
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		contentTxt.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			contentTxt.text += letter;
			yield return null;
		}
	}

	public void EndDialogue()
	{
		ActiveSheet.isActive = false;
		panelbook.SetActive(false);
		//animator.SetBool("IsOpen", false);
	}



}
