using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextAnimation : MonoBehaviour
{
    public float typingSpeed = 0.1f;
    public string fullText;
    private string currentText = "";

    public TextMeshProUGUI textMeshPro;
    private float timer;
    private int currentIndex;

    public float delayBeforeAnimation = 2f; // Delay in seconds before starting the animation
    public float delayAfterAnimation = 2f; // Delay in seconds before deleting the objects
    private bool animationStarted = false;
    private float deleteTimer = 0f;
    private bool isDeleting = false;


    private void Start()
    {
        currentText = "";
        timer = 0f;
        currentIndex = 0;

        Invoke("StartAnimation", delayBeforeAnimation);
       
    }

    private void Update()
    {
        if (animationStarted)
        {
            if (currentIndex < fullText.Length)
            {
                timer += Time.deltaTime;

                if (timer >= typingSpeed)
                {
                    timer = 0f;
                    currentText += fullText[currentIndex];
                    currentIndex++;

                    textMeshPro.text = currentText;
                }
            }
            else
            {
                // Animation complete, start the delay before deleting
                deleteTimer += Time.deltaTime;

                if (deleteTimer >= delayAfterAnimation)
                {
                    isDeleting = true;
                    deleteTimer = 0f;

                    // Call a method or event to handle the deletion of objects
                    DeleteObjects();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Speed up the typing by decreasing the typing speed
            typingSpeed /= 2f;
        }
    }

    private void StartAnimation()
    {
        animationStarted = true;
    }

   
    private void DeleteObjects()
    {
        // Delete the parent object
        Destroy(transform.gameObject);
    }
}
