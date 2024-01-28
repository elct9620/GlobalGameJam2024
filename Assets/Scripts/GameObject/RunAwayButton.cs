using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using Entity;
using Event;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class RunAwayButton : MonoBehaviour, IGameEventHandler<ResolveEvent>
{
    [Inject] private readonly PuzzleCommand _puzzleCommand;
    [Inject] private readonly GameEvent<ResolveEvent> _resolveEvent;

    public float maxMoveSpeed = 600.0f;
    public int cornerEscapeCount = 0;
    public int cornerEscapeThreshold = 1;
    public float sizeMultiplier = 2.0f;
    public float resetSizeAfterSeconds = 5.0f;
    public float cornerCountCooldown = 1.0f;
    public float escapeCooldown = 1.0f;
    public bool isMoving = true;

    private RectTransform rectTransform;
    private Vector2 originalSize;
    private float thresholdDistance;
    private float cornerEscapeDistance = 100.0f;
    private float lastCornerCountTime = 0.0f;
    private float lastEscapeTime = -10.0f;
    private IGameEventHandler<ResolveEvent> _gameEventHandlerImplementation;

    private void Start()
    {
        _resolveEvent.AddListener(this);
        
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;
        thresholdDistance = Mathf.Max(originalSize.x, originalSize.y) * 2;
    }

    public void OnDestroy()
    {
        _resolveEvent.RemoveListener(this);
    }

    private void Update()
    {
        if (!isMoving)
        {
            return;
        }

        Vector2 mousePosition = Input.mousePosition;
        float distanceToMouse = Vector2.Distance(rectTransform.position, mousePosition);

        if (IsNearCorner(rectTransform.position) && distanceToMouse <= thresholdDistance)
        {
            if (Time.time - lastEscapeTime > escapeCooldown && Time.time - lastCornerCountTime > cornerCountCooldown)
            {
                lastCornerCountTime = Time.time;
                if (++cornerEscapeCount >= cornerEscapeThreshold)
                {
                    StartCoroutine(EnlargeAndResetSize());
                    cornerEscapeCount = 0;
                }
                lastEscapeTime = Time.time;
                TeleportToSafePosition(); // 瞬間移動到安全位置
            }
            
            _puzzleCommand.Start(PuzzleType.BootProgram, Time.time);
        }
        else if (distanceToMouse <= thresholdDistance)
        {
            // 正常移動邏輯
            Vector2 directionToMove = ((Vector2)rectTransform.position - mousePosition).normalized;
            float speedFactor = Mathf.Clamp01(1 - distanceToMouse / thresholdDistance);
            float currentSpeed = Mathf.Lerp(0, maxMoveSpeed, speedFactor);

            Vector2 newPosition = rectTransform.position + (Vector3)directionToMove * currentSpeed * Time.deltaTime;
            newPosition = ClampToScreen(newPosition, rectTransform);
            rectTransform.position = newPosition;
        }
    }

    private void TeleportToSafePosition()
    {
        Vector2 newPosition = new Vector2(
            Random.Range(0, Screen.width),
            Random.Range(0, Screen.height)
        );

        newPosition = ClampToScreen(newPosition, rectTransform);

        rectTransform.position = newPosition;
    }

    private IEnumerator EnlargeAndResetSize()
    {
        Vector2 targetSize = originalSize * sizeMultiplier;
        float elapsedTime = 0;

        while (elapsedTime < resetSizeAfterSeconds)
        {
            rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, targetSize, elapsedTime / resetSizeAfterSeconds);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0;
        while (elapsedTime < resetSizeAfterSeconds)
        {
            rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, originalSize, elapsedTime / resetSizeAfterSeconds);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        thresholdDistance = Mathf.Max(originalSize.x, originalSize.y) * 2;
    }

    private bool IsNearCorner(Vector2 position)
    {
        float screenWidth  = Screen.width;
        float screenHeight = Screen.height;

        bool nearTopLeft     = position.x < cornerEscapeDistance && position.y > screenHeight - cornerEscapeDistance;
        bool nearTopRight    = position.x > screenWidth                                       - cornerEscapeDistance && position.y > screenHeight - cornerEscapeDistance;
        bool nearBottomLeft  = position.x < cornerEscapeDistance                                                     && position.y < cornerEscapeDistance;
        bool nearBottomRight = position.x > screenWidth - cornerEscapeDistance                                       && position.y < cornerEscapeDistance;

        return nearTopLeft || nearTopRight || nearBottomLeft || nearBottomRight;
    }

    private Vector2 GetDirectionAwayFromCorner(Vector2 position)
    {
        float screenWidth  = Screen.width;
        float screenHeight = Screen.height;

        if(position.x < screenWidth / 2 && position.y > screenHeight / 2)
            return new Vector2(1, -1); // 從左上角逃逸
        else if(position.x > screenWidth / 2 && position.y > screenHeight / 2)
            return new Vector2(-1, -1); // 從右上角逃逸
        else if(position.x < screenWidth / 2 && position.y < screenHeight / 2)
            return new Vector2(1, 1); // 從左下角逃逸
        else
            return new Vector2(-1, 1); // 從右下角逃逸
    }

    private Vector2 ClampToScreen(Vector2 position, RectTransform rectTransform)
    {
        float width  = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        position.x = Mathf.Clamp(position.x, width  / 2, Screen.width  - width  / 2);
        position.y = Mathf.Clamp(position.y, height / 2, Screen.height - height / 2);

        return position;
    }

    public void OnGameEvent(ResolveEvent payload)
    {
        if (payload.type == PuzzleType.BootProgram)
        {
            isMoving = false;
        }
    }
}