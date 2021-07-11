using UnityEngine;
using UnityEngine.UI;

public class TraningDayElement : MonoBehaviour
{
    [SerializeField] private Sprite bgForPassedDay;
    [SerializeField] private Sprite bgForUnpassedDay;

    [SerializeField] private Color fontColorForPassedDay;
    [SerializeField] private Color fontColorForUnpassedDay;

    [SerializeField] private Button button;
    [SerializeField] private Image background;
    [SerializeField] private Text currentDayText;

    [SerializeField] private GameObject _readyMarkObject;

    public Sprite BgForPassedDay => bgForPassedDay;
    public Sprite BgForUnpassedDay => bgForUnpassedDay;

    public Button Button => button;
    public Image Background => background;
    public Text CurrentDayText => currentDayText;

    public GameObject ReadymarkObject => _readyMarkObject;

    public Color FontColorForPassedDay => fontColorForPassedDay;
    public Color FontColorForUnpassedDay => fontColorForUnpassedDay;
}
