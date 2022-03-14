using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Position : MonoBehaviour
{
    private Sprite _currentSprite;
    public static Sprite bigViewStaticSprite;
    public Sprite beginSpriteBigView;
    private GameObject[] _images;
    private int _numberPicture = 1;
    public static bool panelActivating;
    [SerializeField ] private GameObject _picturePanelBigView;

    // �.�. �������� �������� �����-�� �����, �� ������������ ����������� WWW
    IEnumerator Start()
    {
        int i = 0;
        for (int y = 0; y < _images.Length; y++)
        {
            if (_images[y].tag == "Player")
            {
                string url = "http://data.ikppbb.com/test-task-unity-data/pics/" + _numberPicture + ".jpg";
                // ������� ������ �� �������� ��������
                
                if (_numberPicture <= 66)
                {
                    WWW www = new WWW(url);
                    // ������� ���������� �������
                    yield return www;
                    // ������������� ����������� �������� � �������� �������� �������
                    Texture2D downloadTexture = www.texture;
                    //��������� ����� ������ �� ����������� ��������
                    _currentSprite = Sprite.Create(downloadTexture, new Rect(0, 0, 1000, 1000), new Vector2(), 100);
                    //������ ������ ������ �� ������� ������ �� ������ �������
                    _images[y].GetComponent<Image>().sprite = _currentSprite;
                    _numberPicture += 1;
                }
            }
        }
    }

    private void Awake()
    {
        _images = FindObjectsOfType<GameObject>();
        bigViewStaticSprite = beginSpriteBigView;
    }

    public void ScaledPicture()
    {
        if(panelActivating == true)
        {
            _picturePanelBigView.gameObject.GetComponent<Image>().sprite = bigViewStaticSprite;
            _picturePanelBigView.SetActive(true);
        }
    }
    public void OffPic()
    {
        panelActivating = false;
        _picturePanelBigView.SetActive(false);
    }
    private void Update()
    {
        ScaledPicture();
    }
}