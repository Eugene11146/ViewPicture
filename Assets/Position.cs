using System.Collections;
using UnityEngine;
using System.Net.Http;
using UnityEngine.UI;



public class Position : MonoBehaviour
{
   
    private Sprite sp;
    
    public static Sprite spit;
    
    public Sprite spNull;

    private GameObject[] images;
    private int _numberPicture = 1;

    public static bool panelActivating;

    [SerializeField ] private GameObject picPanel;



    // �.�. �������� �������� �����-�� �����, �� ������������ �����������, �����������
    // ��������� � ���������� ������ ����� ���������� WWW �������
    // ��� ����������� � C# ����� ��� ������������� �������� - IEnumerator
    IEnumerator Start()
    {
        int i = 0;
        for (int y = 0; y < images.Length; y++)
        {
            if (images[y].tag == "Player")
            {

                string url = "http://data.ikppbb.com/test-task-unity-data/pics/" + _numberPicture + ".jpg";
                // ������� ������ �� �������� ��������

                if (_numberPicture <= 66)
                {
                    WWW www = new WWW(url);
                    // ������� ���������� �������
                    yield return www;
                    // ������������� ����������� �������� � �������� �������� �������
                    Texture2D a = www.texture;

                    Debug.Log(url);

                    sp = Sprite.Create(a, new Rect(0, 0, 1000, 1000), new Vector2(), 100);

                    images[y].GetComponent<Image>().sprite = sp;

                    _numberPicture += 1;

                    Debug.Log(_numberPicture);
                }
            }
            
        }


    }

    private void Awake()
    {
        images = FindObjectsOfType<GameObject>();

        spit = spNull;
    }

    public void ScaledPicture()
    {
        if(panelActivating == true)
        {
            picPanel.gameObject.GetComponent<Image>().sprite = spit;
            picPanel.SetActive(true);
        }
    }

    public void OffPic()
    {
        panelActivating = false;
        picPanel.SetActive(false);
    }

    private void Update()
    {
        ScaledPicture();
       
    }
}