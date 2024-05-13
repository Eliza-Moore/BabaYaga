using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Добавляем пространство имен для работы с событиями UI

public class Movement : MonoBehaviour
{
    private Vector3 targetPosition; // Позиция, к которой должен двигаться персонаж
    private bool isMoving = false; // Флаг, указывающий, двигается ли персонаж
    public Animator animator; // Ссылка на компонент Animator
    public Collider2D floorCollider; // Коллайдер объекта floor

    public float speed = 5f; // Скорость движения персонажа

    void Start()
    {
        // Получаем коллайдер объекта floor
        floorCollider = GameObject.FindGameObjectWithTag("Floor").GetComponent<Collider2D>();
        // Получаем компонент Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Проверяем, был ли совершен клик, и не находится ли клик на UI элементе
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0; // Устанавливаем Z-координату на 0

            if (floorCollider.bounds.Contains(clickPosition))
            {
                targetPosition = clickPosition;
                isMoving = true;
            }
            else
            {
                targetPosition = GetNearestEdgePoint(clickPosition);
                isMoving = true;
            }

            // Проверяем направление клика относительно текущего положения персонажа и отражаем его при необходимости
            if ((targetPosition.x < transform.position.x && transform.localScale.x > 0) ||
                (targetPosition.x > transform.position.x && transform.localScale.x < 0))
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        if (isMoving)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.position = newPosition;

            bool isRunning = (newPosition - transform.position).sqrMagnitude > 0.001f;
            animator.SetBool("isRun", true);

            if (transform.position == targetPosition)
            {
                isMoving = false;
                animator.SetBool("isRun", false);
            }
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    private Vector3 GetNearestEdgePoint(Vector3 point)
    {
        return floorCollider.ClosestPoint(point);
    }
}
