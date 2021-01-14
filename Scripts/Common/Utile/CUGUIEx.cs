using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static partial class CUtileEx 
{
    /// <summary>
    /// Component 또는 MonoBehaviour를 상속 받는 클래스의 GameObject를 SetActive 하는 함수
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_GameObject"></param>
    /// <param name="_Visble"></param>
    public static void SetActive<T>(T _GameObject, bool _Visble, bool _Log = true) where T : MonoBehaviour
    {
        // _GameObject 가 null이 아니거니 MonoBehaviour 또는 MonoBehaviour를 상속 받는 대상일 경우
        if (_GameObject is MonoBehaviour)
        {
            MonoBehaviour _Component = _GameObject as MonoBehaviour;
            _Component.gameObject.SetActive(_Visble);
        }
        else
        {
            if (_Log == true)
                Debug.LogError("_GameObject is Null or Not MonoBehaviour");
        }
    }


    /// <summary>
    /// GameObject를 SetActive 하는 함수
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_GameObject"></param>
    /// <param name="_Visble"></param>
    public static void SetActive(GameObject _GameObject, bool _Visble)
    {
        if (_GameObject != null)
        {
            _GameObject.SetActive(_Visble);
        }
        else
        {
            Debug.LogError("_GameObject is Null or Not MonoBehaviour");
        }
    }

    /// <summary>
    /// Transform SetActive 하는 함수
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_GameObject"></param>
    /// <param name="_Visble"></param>
    public static void SetActive(Transform _Transform, bool _Visble)
    {
        if (_Transform != null)
        {
            _Transform.gameObject.SetActive(_Visble);
        }
        else
        {
            Debug.LogError("_GameObject is Null or Not MonoBehaviour");
        }
    }

    /// <summary>
    /// 버튼 인터렉션이 가능/불가능 처리
    /// </summary>
    /// <param name="_Button"></param>
    /// <param name="_Interactable"></param>
    public static void SetEnable(Button _Button, bool _Interactable)
    {
        if (_Button != null)
        {
            _Button.interactable = _Interactable;
        }
        else
        {
            Debug.LogError("_Button is Null");
        }
    }

    public static void SetImage(Image _Image, Sprite _Sprite)
    {
        if (_Image != null)
        {
            _Image.sprite = _Sprite;
        }
        else
        {
            Debug.LogError("_Image is Null");
        }
    }

    public static void SetImage(Image _Image, Color32 _Color)
    {
        if (_Image != null)
        {
            _Image.color = _Color;
        }
        else
        {
            Debug.LogError("_Image is Null");
        }
    }
    public static void SetImageFillAmount(Image _Image, float _Sprite)
    {
        if (_Image != null)
        {
            _Image.fillAmount = _Sprite;
        }
        else
        {
            Debug.LogError("_Image is Null");
        }
    }

    /// <summary>
    /// ImageDataTableKey 참고
    /// </summary>
    /// <param name="_Image"></param>
    /// <param name="_ImageDataKey"></param>
    //public static void SetImage(Image _Image, int _ImageDataKey)
    //{
    
    //    if (_Image != null)
    //    {
    //        DImageData _DImageData = CDataTableManager.Get.DImageDataTable.GetData(_ImageDataKey);


    //        if (_DImageData != null)
    //        {
    //            Sprite _Sprite = CResourcesManager.Get.LoadResData<Sprite>(CResourcePath.ImagePath + _DImageData.ResourcePath);
    //            _Image.sprite = _Sprite;
    //        }
    //        else
    //        {
    //            Debug.LogError("_ImageDataKey is Null, Key :"+ _ImageDataKey);
    //        }
         
       
    //    }
    //    else
    //    {
    //        Debug.LogError("_Image is Null");
    //    }
    //}

    /// <summary>
    /// Images/ 루트 경로를 제외한 나머지 경로 로 스프라이트 로드
    /// </summary>
    /// <param name="_Image"></param>
    /// <param name="_SpritePath"></param>
    //public static void SetImage(Image _Image, string _SpritePath)
    //{
    //    if (_Image != null)
    //    {
    //        Sprite _Sprite = CResourcesManager.Get.LoadResData<Sprite>(CResourcePath.ImagePath + _SpritePath);
    //        _Image.sprite = _Sprite;
    //    }
    //    else
    //    {
    //        Debug.LogError("_Image is Null");
    //    }
    //}


    /// <summary>
    /// 슬라이더 Value값 세팅 함수
    /// </summary>
    /// <param name="_Slider"></param>
    /// <param name="_Value">Max : 1f </param>
    public static void SetSlider(Slider _Slider, float _Value)
    {
        if (_Slider != null)
        {
            _Slider.value = _Value;
        }
        else
        {
            Debug.LogError("_Slider is Null");
        }
    }
    #region Text
    /// <summary>
    /// 텍스트 설정
    /// </summary>
    /// <param name="_Text"></param>
    /// <param name="_String"></param>
    public static void SetText(Text _Text, string _String)
    {
        if(_Text != null)
        {
            _Text.text = _String;
        }
        else
            Debug.LogError("_Text is Null");

    }
    public static void SetText(TextMesh _TextMesh, string _String)
    {
        if (_TextMesh != null)
        {
            _TextMesh.text = _String;
        }
        else
            Debug.LogError("_TextMesh is Null");

    }

    /// <summary>
    /// 텍스트 설정
    /// </summary>
    /// <param name="_Text"></param>
    /// <param name="_String"></param>
    //public static void SetText(Text _Text, int TableKey)
    //{
    //    if (_Text != null)
    //    {           
    //        _Text.text = CDataTableManager.Get.GetText(TableKey);
    //    }
    //    else
    //        Debug.LogError("_Text is Null");

    //}

    public static void SetTextFormat(Text _Text, string _FormatString, params object[] _String)
    {
        SetText(_Text, string.Format(_FormatString, _String));
    }

    //public static void SetTextFormat(Text _Text, int _TableKey, params object[] _String)
    //{
    //   string _FormatString =   CDataTableManager.Get.GetText(_TableKey);

    //    SetText(_Text, string.Format(_FormatString, _String));
    //}


    //public static string GetTextFormat(int _TableKey, params object[] _String)
    //{
    //    return CDataTableManager.Get.GetTextFormat(_TableKey, _String);
    //}
    //public static string GetText(int _TableKey)
    //{
    //    return CDataTableManager.Get.GetText(_TableKey);
    //}

    /// <summary>
    /// 텍스트 설정
    /// </summary>
    /// <param name="_Text"></param>
    /// <param name="_String"></param>
    /// <param name="_FontSize"></param>
    public static void SetText(Text _Text, string _String, int _FontSize)
    {
        if (_Text != null)
        {
            _Text.text = _String;
            _Text.fontSize = _FontSize;
        }
        else
            Debug.LogError("_Text is Null");

    }

    /// <summary>
    ///  텍스트 설정
    /// </summary>
    /// <param name="_Text"></param>
    /// <param name="_String"></param>
    /// <param name="_Color"></param>
    public static void SetText(Text _Text, string _String, Color _Color)
    {
        if (_Text != null)
        {
            _Text.text = _String;
            _Text.color = _Color;
        }
        else
            Debug.LogError("_Text is Null");
    }

    /// <summary>
    /// 텍스트 설정
    /// </summary>
    /// <param name="_Text"></param>
    /// <param name="_String"></param>
    /// <param name="_FontSize"></param>
    /// <param name="_Color"></param>
    public static void SetText(Text _Text, string _String, int _FontSize, Color _Color)
    {
        if (_Text != null)
        {
            _Text.text = _String;
            _Text.fontSize = _FontSize;
            _Text.color = _Color;
        }
        else
            Debug.LogError("_Text is Null");
    }

    #endregion


    public static void SetColor(Image _Image, Color32 _Color)
    {
        if (_Image != null)
        {
            _Image.color = _Color;
        }
    }

    public static void SetColor(Text _Text, Color32 _Color)
    {
        if (_Text != null)
        {
            _Text.color = _Color;
        }
    }

    public static void SetButtonColor(Button _Button,Color _Color)
    {
        if(_Button != null)
        {
            ColorBlock _ColorBlock = _Button.colors;
            _ColorBlock.selectedColor = _Color;
            _ColorBlock.normalColor = _Color;
            _Button.colors = _ColorBlock;
        }
    }

    public static void SetButtonSelect(Button _Button, bool _State)
    {
        if (_Button != null)
        {
            if(_State)
            _Button.Select(); 
        }
    }

    /// <summary>
    /// 버튼 리스트 셀렉트 컬러 변경
    /// </summary>
    /// <param name="_Button"></param>
    /// <param name="_SelectIndex"></param>
    /// <param name="_SelectColor"></param>
    /// <param name="_NonSelectColor"></param>
    public static void SetButtonColor(List<Button> _Button, int _SelectIndex, Color _SelectColor, Color _NonSelectColor)
    {
        if (_Button != null && _Button.Count > 0)
        {
            ColorBlock _ColorBlock = _Button[_SelectIndex].colors;
            _ColorBlock.selectedColor = _SelectColor;
            _ColorBlock.normalColor = _SelectColor;
            _Button[_SelectIndex].colors = _ColorBlock;
            for (int i = 0; i < _Button.Count; i++)
            {
                if (i == _SelectIndex)
                    continue;

                _ColorBlock = _Button[i].colors;
                _ColorBlock.selectedColor = _NonSelectColor;
                _ColorBlock.normalColor = _NonSelectColor;
                _Button[i].colors = _ColorBlock;
            }
        }
    }


    public static Color32 GetGradeColor(EItemGrade _EItemGrade)
    {
        switch (_EItemGrade)
        {
            case EItemGrade.eNone:
                return CColor.Grade_None;
            case EItemGrade.eCommon:
                return CColor.Grade_Common;
            case EItemGrade.eUncommon:
                return CColor.Grade_Uncommon;
            case EItemGrade.eMagic:
                return CColor.Grade_Magic;
            case EItemGrade.eRare:
                return CColor.Grade_Rare;
            case EItemGrade.eUnique:
                return CColor.Grade_Unique;
        }
        return CColor.Grade_Common;
    }
    public static bool Destroy(GameObject obj, float time = 0.0f)
    {
        if (obj == null)
        {
            //  Debug.LogWarning("NGUIToolsEx warning : Destroy GameObject is null!");
            return false;
        }
        else
        {
            UnityEngine.Object.Destroy(obj, time);
        }

        return true;
    }

    /// <summary>
    /// 자식 오브젝트를 제거 한다
    /// </summary>
    /// <param name="_Transform"></param>
    /// <param name="_Time"></param>
    public static void DestroyChild(Transform _Transform, float _Time = 0.0f)
    {
        if(_Transform != null)
        {
            for (int i = _Transform.childCount; i > 0; i--)
            {
                Destroy(_Transform.GetChild(i-1).gameObject, _Time);
            }
        }
    }


    /// <summary>
    /// List에 들어있는 UIObject를 제거하고 리스트를 초기화 한다.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_Target"></param>
    public static void ClearList<T>(List<T> _Target) where T : MonoBehaviour
    {
        if (_Target?.Count > 0)
        {
            for (int i = 0; i < _Target.Count; i++)
            {
                if (_Target[i] != null)
                    Object.Destroy(_Target[i].gameObject);

            }
            _Target.Clear();
        }
    }

}
