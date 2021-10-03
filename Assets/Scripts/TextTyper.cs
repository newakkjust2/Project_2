using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TextTyper : MonoBehaviour
{
    [SerializeField] private Text m_text;

    [SerializeField] private float stepInSeconds = 0.1f, stepInSecondsIfSpace = 0.2f;
    [SerializeField] private string[] content; 
    [SerializeField] private AudioClip[] _clips;

    private int i_audioSources = 0;
    private List<AudioSource> l_audioSources = new List<AudioSource>();
    private int _contentIndex = 0;
    private Coroutine _coroutineHandler;

    private bool b_started;
         
    void TheStart()
    { 
        foreach (var audioSource in GetComponents<AudioSource>())
        {
            audioSource.playOnAwake = false;
            audioSource.loop = false; 
            l_audioSources.Add(audioSource);
        } 
        b_started = true;
    }

    public bool ReadNextContent()
    { 
        if (content.Length <= _contentIndex)
        {
            _contentIndex = 0;
            return false;
        }
        m_text.text = "";
        FillTextContainer();
        _contentIndex++;  
        return true;
    }

    public void SkipText()
    {
        _contentIndex = 0;
    }

    private void FillTextContainer()
    {
        if (_coroutineHandler != null) 
            StopCoroutine(_coroutineHandler); 
        _coroutineHandler = StartCoroutine(SteppedShowText(content[_contentIndex]));
    }
    
    private void PlayAudio()
    {
        if (!b_started)
        {
            TheStart();
            return;
        }
        if(_clips.Length == 0) return;

        i_audioSources++;
        if (i_audioSources >= l_audioSources.Count)
            i_audioSources = 0; 
    
        l_audioSources[i_audioSources].clip = _clips[Random.Range(0, _clips.Length)]; 
        l_audioSources[i_audioSources].Play();
        Debug.Log(i_audioSources.ToString() + " < " + l_audioSources.Count.ToString());
        
    }
  
    private IEnumerator SteppedShowText(string str)
    { 
        foreach (var t in str)
        {
            m_text.text += t;
            float o = 0;
            if(t.ToString() == " ") o = stepInSecondsIfSpace;
            PlayAudio();
            yield return new WaitForSeconds(stepInSeconds + o);
        }

        yield return null;
    }
}
