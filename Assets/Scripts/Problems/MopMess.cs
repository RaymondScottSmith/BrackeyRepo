using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopMess : Problem
{
   private Color messColor;
   public float fadeOut = 1f;
   private SpriteRenderer mySprite;
   [SerializeField]
   private float numberOfScrubs = 4;

   [SerializeField] public GrabMop grabMop;

   private void Awake()
   {
      mySprite = GetComponent<SpriteRenderer>();
      messColor = mySprite.color;
      
   }

   [ContextMenu("Scrub Mess")]
   public void ScrubMess(Mop mop)
   {
      fadeOut = fadeOut - (1 / numberOfScrubs);
      if (fadeOut <= 0)
      {
         ProblemManager.Instance.AdvanceEvent();
         interactMessage = "";
         mop.transform.parent.gameObject.SetActive(false);
         Destroy(gameObject);
      }
      else
      {
         messColor = new Color(messColor.r, messColor.g, messColor.b, fadeOut);
         mySprite.color = messColor;
      }
   }

   public override string InteractMessage(Grabber grabber)
   {
      if (grabber.heldMop.activeSelf && fadeOut>0)
      {
         return interactMessage;
      }
      else
      {
         grabber.DisplayMessage("");
         grabber.heldMop.SetActive(false);
      }

      return "";
   }

   public override void StartEvent()
   {
      grabMop.gameObject.SetActive(true);
      grabMop.StartEvent();
   }

   public override void Interact(Grabber grabber)
   {
      
   }
}
