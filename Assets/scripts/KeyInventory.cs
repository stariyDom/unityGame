using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    // ���������� ������ � ������
    public int keys = 0;

    // ����� ��� ���������� �����
    public void AddKey()
    {
        keys++;
        Debug.Log("���� ��������. ����� ������: " + keys);
    }


}
