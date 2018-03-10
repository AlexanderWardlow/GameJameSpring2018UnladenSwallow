using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTerminal : MonoBehaviour
{
    public Animator anim;
    public string correctCubeColor;
    public bool cantPickupAfter;
    public bool undoCor;
    public bool undoWrong;

    public Animator[] anim2;
    public string[] CoranimOn;
    public string[] CoranimOff;
    public Transform[] CoractiveOn;
    public Transform[] CoractiveOff;
    public string[] WronganimOn;
    public string[] WronganimOff;
    public Transform[] WrongactiveOn;
    public Transform[] WrongactiveOff;

    void OnTriggerEnter(Collider other)
    {
        print("wasup");
        //FIXME need to convert the objectControl to a c# class and check if object can be picked up
        if (!anim.GetBool("boxPresent"))
        {
            if (other.gameObject.tag == "PickUpAble")
            {
                if (cantPickupAfter)
                {
                    other.gameObject.tag = "Untagged";
                }

                anim.SetBool("boxPresent", true);
                if (other.gameObject.name.IndexOf(correctCubeColor) != -1)
                {
                    
                    anim.SetBool("CorrectAnswer", true);
                    anim.SetBool("WrongAnswer", false);
                    CorrectEffect();

                }
                else
                {
                    WrongEffect();
                    anim.SetBool("CorrectAnswer", false);
                    anim.SetBool("WrongAnswer", true);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickUpAble")
        {
            if (anim.GetBool("CorrectAnswer") && undoCor) {
                UndoCorrectEffect();
            }
            if (anim.GetBool("WrongAnswer") && undoWrong) {
                UndoWrongEffect();
            }
            anim.SetBool("CorrectAnswer", false);
            anim.SetBool("WrongAnswer", false);
            anim.SetBool("boxPresent", false);
        }
    }

	void OnTriggerStay(Collider other) {
		if (ObjectControl2.pickedUp == false) {
			if (other.tag == "PickUpAble") {
				other.transform.position = transform.position;
			}
		}
	}

    void CorrectEffect()
    {
        foreach (string value in CoranimOn)
        {
            anim2[0].SetBool(value, true);
        }
        foreach (string value in CoranimOff)
        {
            anim2[0].SetBool(value, false);
        }
        foreach (Transform value in CoractiveOn)
        {
            value.gameObject.SetActive(true);
        }
        foreach (Transform value in CoractiveOff)
        {
            value.gameObject.SetActive(false);
        }
    }

    void UndoCorrectEffect()
    {
        foreach (string value in CoranimOn)
        {
            anim2[0].SetBool(value, false);
        }
        foreach (string value in CoranimOff)
        {
            anim2[0].SetBool(value, true);
        }
        foreach (Transform value in CoractiveOn)
        {
            value.gameObject.SetActive(false);
        }
        foreach (Transform value in CoractiveOff)
        {
            value.gameObject.SetActive(true);
        }
    }

    void WrongEffect()
    {
        foreach (string value in WronganimOn)
        {
            anim2[0].SetBool(value, true);
        }
        foreach (string value in WronganimOff)
        {
            anim2[0].SetBool(value, false);
        }
        foreach (Transform value in WrongactiveOn)
        {
            value.gameObject.SetActive(true);
        }
        foreach (Transform value in WrongactiveOff)
        {
            value.gameObject.SetActive(false);
        }
    }

    void UndoWrongEffect()
    {
        foreach (string value in WronganimOn)
        {
            anim2[0].SetBool(value, false);
        }
        foreach (string value in WronganimOff)
        {
            anim2[0].SetBool(value, true);
        }
        foreach (Transform value in WrongactiveOn)
        {
            value.gameObject.SetActive(false);
        }
        foreach (Transform value in WrongactiveOff)
        {
            value.gameObject.SetActive(true);
        }
    }
}
