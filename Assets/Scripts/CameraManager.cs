using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public Transform boxSpawner;
	public float scrollSpeed = 2.5f;
	public static CameraManager Instance;
	public float shakeDuration = 0.25f;
	public float shakeAmount = 0.15f;
	public float decreaseFactor = 1.0f;

	private bool shaking;
	private Vector3 preShakePosition;
	private float shakeTimer;

	private float highestBoxPosition = -5f;

	private Vector3 initialPosition;
	private bool scrolling;

	private void Awake()
	{
		Instance = this;

		initialPosition = transform.position;
	}

	private void Update()
	{
		if (GameManager.Instance.isGameActive)
		{
			if (shaking)
			{
				CheckShakeFX();
			}

			CheckCameraPosition();
		}
		else
		{
			if (scrolling)
			{
				ScrollCamera();
			}
			
		}
		
	}

	private void CheckShakeFX()
	{
		if (shakeTimer > 0)
		{
			transform.localPosition = preShakePosition + Random.insideUnitSphere * shakeAmount;
			shakeTimer -= Time.deltaTime * Random.Range(decreaseFactor - 0.1f, decreaseFactor + 0.1f);
		}
		else
		{
			shaking = false;
			shakeTimer = 0f;
			transform.localPosition = preShakePosition;
		}
	}

	private void  CheckCameraPosition()
	{
		if (highestBoxPosition + 6f > boxSpawner.transform.position.y)
		{
			transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
		}
	}

	private void ScrollCamera()
	{
		transform.position = Vector3.MoveTowards(transform.position, initialPosition, 15f*Time.deltaTime);

		if (transform.position == initialPosition)
		{
			scrolling = false;
		}
	}

	public void Shake()
	{
		shaking = true;
		preShakePosition = transform.localPosition;
		shakeTimer = shakeDuration;

	}

	public void UpdateBoxesHeight(float boxHeight)
	{
		highestBoxPosition = boxHeight;

	}

	public void ResetCameraPosition()
	{

		scrolling = true;
	}

}
