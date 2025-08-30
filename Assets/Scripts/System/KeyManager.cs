using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

// JSON 데이터 구조와 일치하는 클래스
[System.Serializable]
public class KeyData
{
    public string jump;
    public string attack;
    public string slide;
}

public enum PlayerActionType
{
    Jump,
    Attack,
    Slide
}

public class KeyManager : MonoBehaviour
{
    // 다른 스크립트에서 쉽게 접근할 수 있는 싱글톤 인스턴스
    public static KeyManager instance;

    // 변환된 KeyCode를 저장할 딕셔너리
    public Dictionary<PlayerActionType, KeyCode> Keys { get; private set; } = new();

    void Awake()
    {
        // 싱글톤 패턴 설정
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadKeyBindings();
    }

    private void LoadKeyBindings()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "KeyBindings.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            KeyData keyData = JsonUtility.FromJson<KeyData>(json);

            // 문자열을 KeyCode로 변환하여 딕셔너리에 저장
            // Enum.Parse를 사용하여 문자열로부터 해당하는 KeyCode 값을 찾습니다.
            Keys[PlayerActionType.Jump] = (KeyCode)Enum.Parse(typeof(KeyCode), keyData.jump);
            Keys[PlayerActionType.Attack] = (KeyCode)Enum.Parse(typeof(KeyCode), keyData.attack);
            Keys[PlayerActionType.Slide] = (KeyCode)Enum.Parse(typeof(KeyCode), keyData.slide);
        }
        else
        {
            Debug.LogError("KeyBindings.json 파일을 찾을 수 없습니다! 기본값으로 설정됩니다.");
            // 기본값 설정 (파일이 없을 경우)
            Keys[PlayerActionType.Jump] = KeyCode.Space;
            Keys[PlayerActionType.Attack] = KeyCode.F;
            Keys[PlayerActionType.Slide] = KeyCode.D;
        }
    }

    public void SaveKeyBindings()
    {
        try
        {
            // 1. 현재 KeyManager의 KeyCode들을 문자열로 변환하여 KeyData 객체에 담습니다.
            KeyData keyData = new KeyData
            {
                jump = Keys[PlayerActionType.Jump].ToString(),
                attack = Keys[PlayerActionType.Attack].ToString(),
                slide = Keys[PlayerActionType.Slide].ToString()
            };

            // 2. KeyData 객체를 JSON 형식의 문자열로 변환합니다. (true는 예쁘게 들여쓰기)
            string json = JsonUtility.ToJson(keyData, true);

            // 3. 파일 경로를 지정하고 변환된 JSON 문자열을 파일에 씁니다.
            string path = Path.Combine(Application.streamingAssetsPath, "KeyBindings.json");
            File.WriteAllText(path, json);

            Debug.Log("키 설정이 KeyBindings.json 파일에 성공적으로 저장되었습니다.");
        }
        catch (Exception e)
        {
            Debug.LogError($"키 설정 저장 중 오류 발생: {e.Message}");
        }
    }

    public void SetKey(KeyCode key, PlayerActionType actionType)
    {
        Keys[actionType] = key;
    }
}