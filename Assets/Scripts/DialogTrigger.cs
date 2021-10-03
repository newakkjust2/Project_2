using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private Text m_hint;
    [SerializeField] private string _hintContent = " to SHOW THE HINT";
    [SerializeField] private KeyCode _keyNext = KeyCode.E, _keySkip = KeyCode.R;
    [SerializeField] private TextTyper typer;
    [SerializeField] private GameObject popup;

    private bool b_show;
    private Transform _camTransform;
    
    private void Start()
    {
        m_hint.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    { 
        if(!other.CompareTag("Player")) return; 
        b_show = true;
        ShowHint(_keyNext.ToString(), _hintContent); 
    }

    private void Update()
    {
        if (!b_show) return;
        
        if (Input.GetKeyDown(_keyNext))
        {
            NextKeyInput();
        }
     
        if (Input.GetKeyDown(_keySkip))
        {
            SkipKey();
        }
    }

    private void SkipKey()
    {
        typer.SkipText();
        popup.SetActive(false);
        m_hint.gameObject.SetActive(false);
    }

    protected void NextKeyInput()
    {
        if (!popup.activeInHierarchy)
            popup.SetActive(true);
        if (!typer.ReadNextContent())
            popup.SetActive(false);
        m_hint.gameObject.SetActive(!popup.activeInHierarchy);

        if (_camTransform == null)
        {
            _camTransform = Camera.main.transform;
        }

        popup.transform.LookAt(_camTransform);
        popup.transform.Rotate(0, 180, 0);

        ShowHint(_keySkip.ToString(), " skip.");
    }

    private void OnTriggerExit(Collider other)
    { 
        if(!other.CompareTag("Player")) return;

        b_show = false;
        m_hint.gameObject.SetActive(false); 
    }

    private void ShowHint(string key, string pressTo)
    {
        m_hint.text = "Press " + key + pressTo;
        m_hint.gameObject.SetActive(true); 
    }
}
