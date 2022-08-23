using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public GameObject panelDialogue;

	//public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		panelDialogue.SetActive(false);
	}

	public void StartDialogue (Dialogue dialogue)
	{
		//animator.SetBool("IsOpen", true);

		panelDialogue.SetActive(true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
			DisplayNextSentence();
        }
    }

    public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void EndDialogue()
	{
		panelDialogue.SetActive(false);
		//animator.SetBool("IsOpen", false);
	}

}
