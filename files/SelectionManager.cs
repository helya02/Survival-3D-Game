using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; } // Singleton instance
 
    public bool OnTarget;
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;
    public GameObject selectedObject;

    public Image centerDotImage;
    public Image handIcon;
 
    public bool handIsVisible;
 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
 
    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
        interaction_Info_UI.SetActive(false);
        OnTarget = false;
    }
 
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
 
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
 
            InteractableObject interactableObject = selectionTransform.GetComponent<InteractableObject>();
            if (interactableObject != null && interactableObject.playerInRange)
            {
                interaction_text.text = interactableObject.GetItemName();
                interaction_Info_UI.SetActive(true);
                selectedObject = interactableObject.gameObject;
                OnTarget = true;
                if (interactableObject.CompareTag("pickable")) //give this tag to the objects and apply to the all of those prefabs
                {
 
                    centerDotImage.gameObject.SetActive(false);
                    handIcon.gameObject.SetActive(true);
 
                    handIsVisible = true;
 
                }
                else
                {
                    handIcon.gameObject.SetActive(false);
                    centerDotImage.gameObject.SetActive(true);
 
                    handIsVisible = false;
 
                }
 
            }
            else
            {
                interaction_Info_UI.SetActive(false);
                OnTarget = false;
            }
        }
        else
        {
            interaction_Info_UI.SetActive(false);
            OnTarget = false;
        }
    }
}