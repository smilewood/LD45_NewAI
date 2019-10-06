using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DisplayTextAction : UnityEvent<string[], float, EventCompleteCallback> { }

public class TextBoxController : MonoBehaviour
{
    public static DisplayTextAction DisplayText = new DisplayTextAction();
    private EventCompleteCallback onComplete = ()=> { Debug.Log("testing"); };
    [SerializeField]
    private Text textbox = default;


    private string[] displaying = empty;
    private int section = 1;

    private float letterSpeed = 10f;

    private Boolean scrolling = false;

    private static readonly String[] empty = { "" };
    private static TypedTextGenerator generator = new TypedTextGenerator();


    void Start()
    {
        DisplayText.AddListener(this.SetTextToDisplay);
        advanceText();
    }

    /// <summary>
    /// Method called when text is requested to be dispalyed. 
    /// </summary>
    /// <param name="text">Array of strings to display. Each entry in the array will be an individual text box.</param>
    /// <param name="textSpeed">Number of charecters per second to display in typewriter style. 0 for no delay.</param>
    /// <param name="completeAction">Delegate function to be called when all text has been displayed.</param>
    private void SetTextToDisplay( string[] text, float textSpeed, EventCompleteCallback onComplete )
    {
        displaying = text;
        section = 0;
        letterSpeed = textSpeed;
        textbox.gameObject.transform.parent.gameObject.SetActive(true);
        advanceText();
        this.onComplete = onComplete;
    }
    private void Update()
    {
        if(displaying.Length > 0)
            if (Input.anyKeyDown)
                advanceText();
    }

    /// <summary>
    /// Advances the current text to the next box if finished scrolling. If still scrolling, instantly completes the
    /// current text box. If there is no more text invokes the onComplete callback. 
    /// </summary>
    internal void advanceText()
    {
        if (scrolling)
        {
            StopAllCoroutines();
            textbox.text = displaying[section];
            ++section;
            scrolling = false;
            return;
        }

        if (section == displaying.Length)
        {
            section = 0;
            displaying = empty;
            textbox.gameObject.transform.parent.gameObject.SetActive(false);
            onComplete();
        }
        else
        {
            StartCoroutine("updateDisplayedText");
        }
    }

    /// <summary>
    /// Prints text one charecter at a time to the textbox. 
    /// </summary>
    private IEnumerator updateDisplayedText()
    {
        if (letterSpeed == 0)
        {
            textbox.text = displaying[section];
        }
        else
        {
            scrolling = true;
            for (int i = 0; i <= displaying[section].Length; ++i)
            {
                textbox.text = generator.GetTypedTextAt(displaying[section], i).TextToPrint;
                yield return new WaitForSeconds(1f / letterSpeed);
            }
            ++section;
            scrolling = false;
        }
    }
}
