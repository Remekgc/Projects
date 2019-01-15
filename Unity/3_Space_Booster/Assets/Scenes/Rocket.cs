using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float levelLoadDeley = 2f;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip sucess;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem RightEngineParticles;
    [SerializeField] ParticleSystem LeftEngineParticles;
    [SerializeField] ParticleSystem sucessParticles;
    [SerializeField] ParticleSystem deathParticles;

    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State { Alive, Dying, Transcending };
    State state = State.Alive;

    bool collisionsDisabled = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            RespondToThrustInput();
            Rotate();
        }
        if (Debug.isDebugBuild)
        {
            RespondToDebugKeys();
        }
        BackToMenu();
    }

    private static void BackToMenu()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionsDisabled = !collisionsDisabled; //toggle colission if true then false, if false then true
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive || collisionsDisabled)
        {
            return; // ignore collisions when dead
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //do nothing.
                break;
            case "Finish":
                StartSucessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }
    
    private void StartSucessSequence()
    {
        sucessParticles.Play();
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(sucess);
        Invoke("LoadNextLevel", levelLoadDeley); // parameterise time
    }

    private void StartDeathSequence()
    {
        deathParticles.Play();
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        Invoke("ReloadLevel", levelLoadDeley);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextLevel()
    {
        int currentSceenIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceenIndex = currentSceenIndex + 1;
        if (nextSceenIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceenIndex = 0; //loop back to start
        }
        SceneManager.LoadScene(nextSceenIndex);
    }

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {
            NewMethod();
        }
    }

    private void NewMethod()
    {
        audioSource.Stop();
        LeftEngineParticles.Stop();
        RightEngineParticles.Stop();
    }

    private void ApplyThrust()
    {
        LeftEngineParticles.Play();
        RightEngineParticles.Play();

        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateManually(rcsThrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateManually(-rcsThrust * Time.deltaTime);
        }
    }

    private void RotateManually(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true; // take manual control of rotation
        transform.Rotate(Vector3.forward * rotationThisFrame);
        LeftEngineParticles.Play();
        rigidBody.freezeRotation = false; // resume physics control of rotation   
    }
}
