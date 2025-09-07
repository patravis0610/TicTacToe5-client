using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Singleton<T> : MonoBehaviour where T : Component //T�� ������Ʈ Ÿ���̾����
{
    private static T _instance; //�̱��� �ν��Ͻ��� �����ϴ� ���� ����   
    //�ν��Ͻ� ������Ƽ: get�� set�� ���
    public static T Instance //�̱��� �ν��Ͻ��� �����ϴ� ���� ������Ƽ
    {
        get //get�� �����ؼ� ���� �о�� 
        {
            if (_instance == null) //_instance�� null�̸�
            {
                _instance = FindFirstObjectByType<T>(); //������ TŸ���� ������Ʈ�� ã�Ƽ� _instance�� �Ҵ�
                if (_instance == null) //���� TŸ���� ������Ʈ�� ������
                {
                    GameObject obj = new GameObject(); //�� ���ӿ�����Ʈ ����
                    obj.name = typeof(T).Name; //���ӿ�����Ʈ �̸��� TŸ���� �̸����� ����
                    _instance = obj.AddComponent<T>(); //TŸ���� ������Ʈ�� �߰��ϰ� _instance�� �Ҵ�
                }
            }
            return _instance; //_instance ��ȯ
        }
    }

    private void Awake()    //������Ʈ�� Ȱ��ȭ�� �� ȣ��Ǵ� �޼���
    {
        if (_instance == null) //�̹� ���Ӹ޴����� ������� ����
        {
            _instance = this as T; //���� ������Ʈ�� TŸ������ ��ȯ�Ͽ� _instance�� �Ҵ礤
            DontDestroyOnLoad(gameObject); //���� �ٲ� �ı����� ����    
            //�� ��ȯ�� ȣ��Ǵ� �׼� �޼��� �Ҵ�
            SceneManager.sceneLoaded += OnSceneLoad;    //���� �ε�� �� ȣ��Ǵ� �޼��� ���


        }
        else //�̹� ���Ӹ޴����� ������� ����
        {
            Destroy(gameObject); //�Ǵٸ� ���� �޴�����  ������ ���� -�����
        }
    }
    protected abstract void OnSceneLoad(Scene scene, LoadSceneMode mode); //���� �ε�� �� ȣ��Ǵ� �߻� �޼���

}


