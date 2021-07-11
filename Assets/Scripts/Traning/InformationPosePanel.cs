using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPosePanel : MonoBehaviour
{
    [SerializeField] private GameObject playAnimationHint;
    [SerializeField] private Image hintImage;
    [SerializeField] private Text namePose;
    [SerializeField] private Text hintText;


    public GameObject PlayAnimationHint => playAnimationHint;
    public Image HintImage => hintImage;
    public Text NamePose => namePose;
    public Text HintText => hintText;
}
