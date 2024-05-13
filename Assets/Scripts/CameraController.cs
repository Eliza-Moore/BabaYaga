using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ������ �� ��������� ������
    public float smoothTime = 0.3f; // �����, �� ������� ������ ��������� ������� �������
    public float offsetX = 2f; // ������ �� ����������� �� ������
    public float edgeBuffer = 2f; // ����� ��� ����������� ���� ������
    private Vector3 velocity = Vector3.zero; // ������ ��������

    private void LateUpdate()
    {
        // ���� ����� �� �����, ������� �� �������
        if (target == null)
            return;

        // ��������� ������� ������
        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + edgeBuffer;
        float rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - edgeBuffer;

        // ������� ������ �� �����������
        float targetX = target.position.x;

        // ���� ����� ������������ � ���� ������, ������ �������� ���������
        if (targetX < leftEdge || targetX > rightEdge)
        {
            // ����� ������� ������ �� �����������
            targetX = Mathf.Clamp(targetX, leftEdge + offsetX, rightEdge - offsetX);

            // ������ ����� ������� ������ � ������� ����������������� ���������
            Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
