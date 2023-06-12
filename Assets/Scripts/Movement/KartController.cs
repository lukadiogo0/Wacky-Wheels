using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartController : MonoBehaviour
{
    public Rigidbody rb;
    public float offsety;

    public float CurrentSpeed = 0;
    public float MaxSpeed;
    public float boostSpeed;
    private float RealSpeed; //not the applied speed
    private bool isAccelerating = false;
    private bool isBraking = false;
    private float turnAmount = 0f;
    private bool isSpacePressed = false;
    private bool isSpaceStillPressed = false;

    [Header("Tires")]
    public Transform frontLeftTire;
    public Transform frontRightTire;
    public Transform backLeftTire;
    public Transform backRightTire;

    //drift and steering stuffz
    private float steerDirection;
    private float driftTime;

    bool driftLeft = false;
    bool driftRight = false;
    float outwardsDriftForce = 50000;

    private bool touchingGround;

    public LayerMask groundMask;
    public float rotateSpeed = 100f; // velocidade de rota��o das rodas
    public float maxRotationAngle = 35f; // limite de rota��o das rodas
    public float currentRotation = 0f; // rota��o atual das rodas
    public float normalRotation = 0f; // rota��o normal das rodas
    private bool isRotating = false;

    [Header("Particles Drift Sparks")]
    public Transform leftDrift;
    public Transform rightDrift;
    public Color drift1;
    public Color drift2;
    public Color drift3;

    [HideInInspector]
    public float BoostTime = 0;
    [HideInInspector]
    public bool isSliding = false;
    public AudioClip audioClipAccelerate;
    public AudioClip audioClipBrake;
    public AudioClip audioClipDrift;
    public AudioClip audioClipIdle;


    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private bool canMove = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove) { 
            move();
            sound();
            tireSteer();
            steer();
            groundNormalRotation();
            boosts();
        }
    }
    private void sound(){
        if (!audioSource.isPlaying && CurrentSpeed < 1 && CurrentSpeed > -1){
            audioSource.clip = audioClipIdle;
            audioSource.volume = 0.05f;
            audioSource.Play();
        }else if(audioSource.isPlaying && audioSource.clip == audioClipIdle && CurrentSpeed > 1){
            audioSource.Stop();
        }else if(audioSource.isPlaying && audioSource.clip == audioClipIdle && CurrentSpeed < 0){
            audioSource.Stop();
        }

        if (audioSource.isPlaying && audioSource.clip == audioClipAccelerate && CurrentSpeed < 2)
        {
            audioSource.Stop();
        }
        if (isAccelerating)
        {
            if (!audioSource.isPlaying && CurrentSpeed > 0)
            {
                audioSource.clip = audioClipAccelerate;
                audioSource.volume = 0.05f;
                audioSource.Play();
            }
        }
        else if (isBraking)
        {
            if (audioSource.isPlaying && CurrentSpeed > 0 && audioSource.clip == audioClipAccelerate)
            {
                audioSource.Stop();
            }
            if (!audioSource.isPlaying && CurrentSpeed > 0)
            {
                audioSource.clip = audioClipBrake;
                audioSource.Play();
            }
            
        }
        
        

    }
    private void move()
    {
        RealSpeed = transform.InverseTransformDirection(rb.velocity).z; //real velocity before setting the value. This can be useful if say you want to have hair moving on the player, but don't want it to move if you are accelerating into a wall, since checking velocity after it has been applied will always be the applied value, and not real

        if (isAccelerating)
        {
            CurrentSpeed = Mathf.Lerp(CurrentSpeed, MaxSpeed, Time.deltaTime * 0.5f); //speed
        }
        else if (isBraking)
        {
            CurrentSpeed = Mathf.Lerp(CurrentSpeed, -MaxSpeed / 1.75f, 1f * Time.deltaTime);
        }
        else
        {
            CurrentSpeed = Mathf.Lerp(CurrentSpeed, 0, Time.deltaTime * 1.5f); //speed
        }

        if (driftLeft || driftRight)
        {
            rb.AddForce(-transform.up * outwardsDriftForce * Time.deltaTime, ForceMode.Acceleration);
        }

        Vector3 vel = transform.forward * CurrentSpeed;
        vel.y = rb.velocity.y; //gravity
        rb.velocity = vel;
    }

    private void steer()
    {
        steerDirection = turnAmount; // -1, 0, 1
        Vector3 steerDirVect; //this is used for the final rotation of the kart for steering

        float steerAmount;

        if (driftLeft && !driftRight)
        {
            steerDirection = turnAmount < 0 ? -1.5f : -0.5f;
            transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, Quaternion.Euler(0, -20f, 0), 8f * Time.deltaTime);


            if (isSliding && touchingGround)
                rb.AddForce(transform.right * outwardsDriftForce * Time.deltaTime, ForceMode.Acceleration);
        }
        else if (driftRight && !driftLeft)
        {
            steerDirection = turnAmount > 0 ? 1.5f : 0.5f;
            transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, Quaternion.Euler(0, 20f, 0), 8f * Time.deltaTime);

            if (isSliding && touchingGround)
                rb.AddForce(transform.right * -outwardsDriftForce * Time.deltaTime, ForceMode.Acceleration);
        }
        else
        {
            transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, Quaternion.Euler(0, 0f, 0), 8f * Time.deltaTime);
        }

        //since handling is supposed to be stronger when car is moving slower, we adjust steerAmount depending on the real speed of the kart, and then rotate the kart on its y axis with steerAmount
        steerAmount = RealSpeed > 30 ? RealSpeed / 4 * steerDirection : steerAmount = RealSpeed / 1.5f * steerDirection;

        steerDirVect = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + steerAmount, transform.eulerAngles.z);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, steerDirVect, 3 * Time.deltaTime);

    }

    private void groundNormalRotation()
    {
        RaycastHit hit;
        Vector3 carposition = transform.position + new Vector3(0f, offsety, 0f);
        if (Physics.Raycast(carposition, -transform.up, out hit, 0.75f, groundMask))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up * 2, hit.normal) * transform.rotation, 7.5f * Time.deltaTime);
            touchingGround = true;
        }
        else
        {
            touchingGround = false;
        }
    }

    private void drift()
    {
        if (isSpacePressed && touchingGround && CurrentSpeed > 40 && steerDirection != 0)
        {
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("DriftHop");
            if (steerDirection > 0)
            {
                driftRight = true;
                driftLeft = false;
            }
            else if (steerDirection < 0)
            {
                driftRight = false;
                driftLeft = true;
            }
        }

        if (isSpaceStillPressed && touchingGround && CurrentSpeed > 40 && isSliding)
        {
            driftTime += Time.deltaTime;

            //particle effects (sparks)
            if (driftTime < 2)
            {
                for (int i = 0; i < leftDrift.childCount; i++)
                {
                    
                    ParticleSystem DriftPS = rightDrift.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>(); //right wheel particles
                    ParticleSystem.MainModule PSMAIN = DriftPS.main;

                    ParticleSystem DriftPS2 = leftDrift.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>(); //left wheel particles
                    ParticleSystem.MainModule PSMAIN2 = DriftPS2.main;

                    PSMAIN.startColor = drift1;
                    PSMAIN2.startColor = drift1;

                    if (!DriftPS.isPlaying && !DriftPS2.isPlaying)
                    {
                        DriftPS.Play();
                        DriftPS2.Play();
                    }

                }
            }
            if (driftTime >= 2 && driftTime < 4)
            {
                //drift color particles
                for (int i = 0; i < leftDrift.childCount; i++)
                {
                    ParticleSystem DriftPS = rightDrift.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
                    ParticleSystem.MainModule PSMAIN = DriftPS.main;
                    ParticleSystem DriftPS2 = leftDrift.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
                    ParticleSystem.MainModule PSMAIN2 = DriftPS2.main;
                    PSMAIN.startColor = drift2;
                    PSMAIN2.startColor = drift2;


                }

            }
            if (driftTime >= 4)
            {
                for (int i = 0; i < leftDrift.childCount; i++)
                {

                    ParticleSystem DriftPS = rightDrift.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
                    ParticleSystem.MainModule PSMAIN = DriftPS.main;
                    ParticleSystem DriftPS2 = leftDrift.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
                    ParticleSystem.MainModule PSMAIN2 = DriftPS2.main;
                    PSMAIN.startColor = drift3;
                    PSMAIN2.startColor = drift3;

                }
            }
        }

        if (!isSpaceStillPressed || RealSpeed < 40)
        {
            driftLeft = false;
            driftRight = false;
            isSliding = false; /////////

            //give a boost
            if (driftTime > 0.5 && driftTime < 2)
            {
                BoostTime = 0.75f;
            }
            if (driftTime >= 2 && driftTime < 3)
            {
                BoostTime = 1.5f;

            }
            if (driftTime >= 3)
            {
                BoostTime = 2.5f;

            }

            //reset everything
            driftTime = 0;
            //stop particles
            for (int i = 0; i < 5; i++)
            {
                ParticleSystem DriftPS = rightDrift.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>(); //right wheel particles
                ParticleSystem DriftPS2 = leftDrift.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>(); //left wheel particles
                DriftPS.Stop();
                DriftPS2.Stop();

            }
        }
    }

    private void boosts()
    {
        BoostTime -= Time.deltaTime;
        if (BoostTime > 0)
        {
            MaxSpeed = boostSpeed;
            CurrentSpeed = Mathf.Lerp(CurrentSpeed, MaxSpeed, 1 * Time.deltaTime);       
        }
        else
        {
            MaxSpeed = boostSpeed - 20;
        }
    }

    private void tireSteer()
    {
        float horizontalInput = turnAmount;

        if (!isRotating)
        {
            // se as rodas n�o estiverem girando, defina a rota��o atual como normal
            currentRotation = Mathf.MoveTowards(currentRotation, normalRotation, rotateSpeed * Time.deltaTime);
        }

        // verifica se o bot�o de entrada para a esquerda est� sendo pressionado
        if (horizontalInput < 0)
        {
            currentRotation = Mathf.Clamp(currentRotation - maxRotationAngle, -maxRotationAngle, 0f);
            isRotating = true;
        }

        // verifica se o bot�o de entrada para a direita est� sendo pressionado
        if (horizontalInput > 0)
        {
            currentRotation = Mathf.Clamp(currentRotation + maxRotationAngle, 0f, maxRotationAngle);
            isRotating = true;
        }

        // calcula a rota��o atual com base na velocidade de rota��o
        float targetRotation = currentRotation;
        float rotationDelta = rotateSpeed * Time.deltaTime;

        if (Mathf.Abs(targetRotation - frontLeftTire.localEulerAngles.y) > Mathf.Epsilon)
        {
            float newRotation = Mathf.MoveTowardsAngle(frontLeftTire.localEulerAngles.y, targetRotation, rotationDelta);
            frontLeftTire.localRotation = Quaternion.Euler(0f, newRotation, 0f);
            frontRightTire.localRotation = Quaternion.Euler(0f, newRotation, 0f);
        }

        // verifica se nenhum dos bot�es de entrada est� sendo pressionado
        if (horizontalInput == 0)
        {
            isRotating = false;
        }


        //tire spinning

        if (CurrentSpeed > 30)
        {
            frontLeftTire.GetChild(0).Rotate(90 * Time.deltaTime * CurrentSpeed * 0.5f, 0, 0);
            frontRightTire.GetChild(0).Rotate(90 * Time.deltaTime * CurrentSpeed * 0.5f, 0, 0);
            backLeftTire.Rotate(90 * Time.deltaTime * CurrentSpeed * 0.5f, 0, 0);
            backRightTire.Rotate(90 * Time.deltaTime * CurrentSpeed * 0.5f, 0, 0);
        }
        else
        {
            frontLeftTire.GetChild(0).Rotate(90 * Time.deltaTime * RealSpeed * 0.5f, 0, 0);
            frontRightTire.GetChild(0).Rotate(90 * Time.deltaTime * RealSpeed * 0.5f, 0, 0);
            backLeftTire.Rotate(90 * Time.deltaTime * RealSpeed * 0.5f, 0, 0);
            backRightTire.Rotate(90 * Time.deltaTime * RealSpeed * 0.5f, 0, 0);
        }
    }

    private void Update()
    {
        drift();
    }

    public void StopCompletely()
    {
        CurrentSpeed = 0;
        RealSpeed = 0;
        steerDirection = 0;
        isAccelerating = false;
        isBraking = false;
        turnAmount = 0f;
        isSpacePressed = false;
        isSpaceStillPressed = false;
}

    public void SetInputs(bool isAccelerating, bool isBraking, float turnAmount, bool isSpacePressed, bool isSpaceStillPressed)
    {
        this.isAccelerating = isAccelerating;
        this.isBraking = isBraking;
        this.turnAmount = turnAmount;
        this.isSpacePressed = isSpacePressed;
        this.isSpaceStillPressed = isSpaceStillPressed;
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
}
