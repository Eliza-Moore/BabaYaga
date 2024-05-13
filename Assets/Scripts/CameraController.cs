using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Ссылка на трансформ игрока
    public float smoothTime = 0.3f; // Время, за которое камера достигнет целевой позиции
    public float offsetX = 2f; // Отступ по горизонтали от игрока
    public float edgeBuffer = 2f; // Буфер для определения края экрана
    private Vector3 velocity = Vector3.zero; // Вектор скорости

    private void LateUpdate()
    {
        // Если игрок не задан, выходим из функции
        if (target == null)
            return;

        // Вычисляем границы экрана
        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + edgeBuffer;
        float rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - edgeBuffer;

        // Позиция игрока по горизонтали
        float targetX = target.position.x;

        // Если игрок приближается к краю экрана, камера начинает двигаться
        if (targetX < leftEdge || targetX > rightEdge)
        {
            // Новая позиция камеры по горизонтали
            targetX = Mathf.Clamp(targetX, leftEdge + offsetX, rightEdge - offsetX);

            // Задаем новую позицию камеры с помощью экспоненциального затухания
            Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
