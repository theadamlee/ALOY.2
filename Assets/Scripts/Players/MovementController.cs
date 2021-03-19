using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public ShrinkController shrinkMovement;
    public YellowGuyController yellowMovement;
    public MainGuyController mainMovement;
    public IceController iceMovement;
    public BounceController bounceMovement;
    public GreenGuyController greenMovement;
    public YGuyController yGuyMovement;
    public OrangeGuyController orangeMovement;


    private bool Switchready;
    private bool Switchready2;

    public GameObject bounceGuy;
    public GameObject yellowGuy;
    public GameObject iceGuy;
    public GameObject mainGuy;
    public GameObject yGuy;
    public GameObject greenGuy;
    public GameObject ShrinkGuy;
    public GameObject OrangeGuy;

    private Rigidbody2D bounceRb;
    private Rigidbody2D yellowRb;
    private Rigidbody2D mainRb;
    private Rigidbody2D iceRb;
    private Rigidbody2D yGuyRb;
    private Rigidbody2D greenRb;
    private Rigidbody2D shrinkRb;
    private Rigidbody2D orangeRb;

    private ParticleSystem mainGlow;
    private ParticleSystem iceGlow;
    private ParticleSystem bounceGlow;
    private ParticleSystem greenGlow;
    private ParticleSystem shrinkGlow;
    private ParticleSystem orangeGlow;
    private ParticleSystem yellowGlow;
    private ParticleSystem yGuyGlow;


    // Start is called before the first frame update
    void Start()
    {
        mainMovement.enabled = false;
        iceMovement.enabled = false;
        bounceMovement.enabled = false;
        yGuyMovement.enabled = false;
        greenMovement.enabled = false;
        shrinkMovement.enabled = false;
        yellowMovement.enabled = false;
        orangeMovement.enabled = false;

        yellowRb = yellowGuy.GetComponent<Rigidbody2D>();
        bounceRb = bounceGuy.GetComponent<Rigidbody2D>();
        iceRb = iceGuy.GetComponent<Rigidbody2D>();
        mainRb = mainGuy.GetComponent<Rigidbody2D>();
        yGuyRb = yGuy.GetComponent<Rigidbody2D>();
        greenRb = greenGuy.GetComponent<Rigidbody2D>();
        shrinkRb = ShrinkGuy.GetComponent<Rigidbody2D>();
        orangeRb = OrangeGuy.GetComponent<Rigidbody2D>();

        yGuyRb.constraints = RigidbodyConstraints2D.FreezeAll;

       mainGlow = mainGuy.GetComponent<ParticleSystem>();
       iceGlow = iceGuy.GetComponent<ParticleSystem>();
       bounceGlow = bounceGuy.GetComponent<ParticleSystem>();
       yGuyGlow = yGuy.GetComponent<ParticleSystem>();
       greenGlow = greenGuy.GetComponent<ParticleSystem>();
       yellowGlow = yellowGuy.GetComponent<ParticleSystem>();
       orangeGlow = OrangeGuy.GetComponent<ParticleSystem>();
       shrinkGlow = ShrinkGuy.GetComponent<ParticleSystem>();

        mainGlow.Stop();
        bounceGlow.Stop();
        yGuyGlow.Stop();
        greenGlow.Stop();
        yellowGlow.Stop();
        orangeGlow.Stop();
        shrinkGlow.Stop();


    }

    // Update is called once per frame
    void Update()
    {
        InputControl();
        Switchmenu();
        Switchmenu2();
    }

    private void InputControl()
    {
        //Main Guy Access
        if (Input.GetButtonDown("1") || (Input.GetButtonDown("1C") && Switchready))
        {
            if (mainMovement != null)
                mainMovement.enabled = true;
            mainRb.drag = 1;
            mainRb.gravityScale = 10;
            mainGlow.Play();
          

            iceMovement.enabled = false;
            iceRb.drag = 40;
            iceRb.gravityScale = 80;
            

            bounceMovement.enabled = false;
            bounceRb.drag = 40;
            bounceRb.gravityScale = 80;
            bounceGlow.Stop();

            yGuyMovement.enabled = false;
            yGuyRb.constraints = RigidbodyConstraints2D.FreezeAll;
            yGuyGlow.Stop();

            greenMovement.enabled = false;
            greenRb.drag = 40;
            greenRb.gravityScale = 80;
            greenGlow.Stop();
            greenRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            shrinkMovement.enabled = false;
            shrinkRb.drag = 40;
            shrinkRb.gravityScale = 80;
            shrinkGlow.Stop();

            yellowMovement.enabled = false;
            yellowRb.drag = 40;
            yellowRb.gravityScale = 80;
            yellowGlow.Stop();

            orangeMovement.enabled = false;
            orangeRb.drag = 40;
            orangeRb.gravityScale = 80;
            orangeRb.rotation = 0;
        }
        //Ice Guy Access
        if (Input.GetButtonDown("2") || (Input.GetButtonDown("2C") && Switchready))
        {
            if (iceMovement != null)
                iceMovement.enabled = true;
            iceRb.drag = 1;
            iceRb.gravityScale = 10;

            mainMovement.enabled = false;
            mainRb.drag = 40;
            mainRb.gravityScale = 80;
            mainGlow.Stop();

            bounceMovement.enabled = false;
            bounceRb.drag = 40;
            bounceRb.gravityScale = 80;
            bounceGlow.Stop();


            yGuyMovement.enabled = false;
            yGuyRb.constraints = RigidbodyConstraints2D.FreezeAll;
            yGuyGlow.Stop();

            greenMovement.enabled = false;
            greenRb.drag = 40;
            greenRb.gravityScale = 80;
            greenGlow.Stop();
            greenRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            shrinkMovement.enabled = false;
            shrinkRb.drag = 40;
            shrinkRb.gravityScale = 80;
            shrinkGlow.Stop();

            yellowMovement.enabled = false;
            yellowRb.drag = 40;
            yellowRb.gravityScale = 80;
            yellowGlow.Stop();

            orangeMovement.enabled = false;
            orangeRb.drag = 40;
            orangeRb.gravityScale = 80;
            orangeRb.rotation = 0;
        }


        //Bounce Guy Access
        if (Input.GetButtonDown("3") || (Input.GetButtonDown("3C") && Switchready))
        {
            if (bounceMovement != null)
                bounceMovement.enabled = true;
            bounceRb.drag = 1;
            bounceRb.gravityScale = 10;
            bounceGlow.Play();

            mainMovement.enabled = false;
            mainRb.drag = 40;
            mainRb.gravityScale = 80;
            mainGlow.Stop();


            iceMovement.enabled = false;
            iceRb.drag = 40;
            iceRb.gravityScale = 80;


            yGuyMovement.enabled = false;
            yGuyRb.constraints = RigidbodyConstraints2D.FreezeAll;
            yGuyGlow.Stop();

            greenMovement.enabled = false;
            greenRb.drag = 40;
            greenRb.gravityScale = 80;
            greenGlow.Stop();
            greenRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            shrinkMovement.enabled = false;
            shrinkRb.drag = 40;
            shrinkRb.gravityScale = 80;
            shrinkGlow.Stop();

            yellowMovement.enabled = false;
            yellowRb.drag = 40;
            yellowRb.gravityScale = 80;
            yellowGlow.Stop();

            orangeMovement.enabled = false;
            orangeRb.drag = 40;
            orangeRb.gravityScale = 80;
            orangeRb.rotation = 0;
            orangeGlow.Stop();
        }

        //Y Guy Access
        if (Input.GetButtonDown("4") || (Input.GetButtonDown("4C") && Switchready))
        {
            if (yGuyMovement != null)
                yGuyMovement.enabled = true;
            yGuyGlow.Play();

            bounceMovement.enabled = false;
            bounceRb.drag = 40;
            bounceRb.gravityScale = 80;
            bounceGlow.Stop();

            mainMovement.enabled = false;
            mainRb.drag = 40;
            mainRb.gravityScale = 80;
            mainGlow.Stop();

            iceMovement.enabled = false;
            iceRb.drag = 40;
            iceRb.gravityScale = 80;

            greenMovement.enabled = false;
            greenRb.drag = 40;
            greenRb.gravityScale = 80;
            greenGlow.Stop();
            greenRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            shrinkMovement.enabled = false;
            shrinkRb.drag = 40;
            shrinkRb.gravityScale = 80;
            shrinkGlow.Stop();

            yellowMovement.enabled = false;
            yellowRb.drag = 40;
            yellowRb.gravityScale = 80;
            yellowGlow.Stop();

            orangeMovement.enabled = false;
            orangeRb.drag = 40;
            orangeRb.gravityScale = 80;
            orangeRb.rotation = 0;
            orangeGlow.Stop();
        }

        //Green Guy Access
        if (Input.GetButtonDown("6") || (Input.GetButtonDown("3C") && Switchready2))
        {
            if (greenMovement != null)
                greenMovement.enabled = true;
            greenRb.drag = 1;
            greenRb.gravityScale = 10;
            greenGlow.Play();

            bounceMovement.enabled = false;
            bounceRb.drag = 40;
            bounceRb.gravityScale = 80;
            bounceGlow.Stop();

            mainMovement.enabled = false;
            mainRb.drag = 40;
            mainRb.gravityScale = 80;
            mainGlow.Stop();

            iceMovement.enabled = false;
            iceRb.drag = 40;
            iceRb.gravityScale = 80;

            yGuyMovement.enabled = false;
            yGuyRb.constraints = RigidbodyConstraints2D.FreezeAll;
            yGuyGlow.Stop();

            shrinkMovement.enabled = false;
            shrinkRb.drag = 40;
            shrinkRb.gravityScale = 80;
            shrinkGlow.Stop();

            yellowMovement.enabled = false;
            yellowRb.drag = 40;
            yellowRb.gravityScale = 80;
            yellowGlow.Stop();

            orangeMovement.enabled = false;
            orangeRb.drag = 40;
            orangeRb.gravityScale = 80;
            orangeRb.rotation = 0;
            orangeGlow.Stop();
        }

        //Shrink Guy Access
        if (Input.GetButtonDown("5") || (Input.GetButtonDown("1C") && Switchready2))
        {
            if (shrinkMovement != null)
                shrinkMovement.enabled = true;
            shrinkRb.drag = 1;
            shrinkRb.gravityScale = 10;
            shrinkGlow.Play();

            bounceMovement.enabled = false;
            bounceRb.drag = 40;
            bounceRb.gravityScale = 80;
            bounceGlow.Stop();

            mainMovement.enabled = false;
            mainRb.drag = 40;
            mainRb.gravityScale = 80;
            mainGlow.Stop();

            iceMovement.enabled = false;
            iceRb.drag = 40;
            iceRb.gravityScale = 80;

            yGuyMovement.enabled = false;
            yGuyRb.constraints = RigidbodyConstraints2D.FreezeAll;
            yGuyGlow.Stop();

            greenMovement.enabled = false;
            greenRb.drag = 40;
            greenRb.gravityScale = 80;
            greenGlow.Stop();
            greenRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            yellowMovement.enabled = false;
            yellowRb.drag = 40;
            yellowRb.gravityScale = 80;
            yellowGlow.Stop();

            orangeMovement.enabled = false;
            orangeRb.drag = 40;
            orangeRb.gravityScale = 80;
            orangeRb.rotation = 0;
            orangeGlow.Stop();
        }

        //Yellow Guy Access
        if (Input.GetButtonDown("8") || (Input.GetButtonDown("2C") && Switchready2))
        {

            if (yellowMovement != null)
                yellowMovement.enabled = true;
            yellowRb.drag = 1;
            yellowRb.gravityScale = 3;
            yellowGlow.Play();

            shrinkMovement.enabled = false;
            shrinkRb.drag = 40;
            shrinkRb.gravityScale = 80;
            shrinkGlow.Stop();

            bounceMovement.enabled = false;
            bounceRb.drag = 40;
            bounceRb.gravityScale = 80;
            bounceGlow.Stop();

            mainMovement.enabled = false;
            mainRb.drag = 40;
            mainRb.gravityScale = 80;
            mainGlow.Stop();

            iceMovement.enabled = false;
            iceRb.drag = 40;
            iceRb.gravityScale = 80;

            yGuyMovement.enabled = false;
            yGuyRb.constraints = RigidbodyConstraints2D.FreezeAll;
            yGuyGlow.Stop();

            greenMovement.enabled = false;
            greenRb.drag = 40;
            greenRb.gravityScale = 80;
            greenGlow.Stop();
            greenRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            orangeMovement.enabled = false;
            orangeRb.drag = 40;
            orangeRb.gravityScale = 80;
            orangeRb.rotation = 0;
            orangeGlow.Stop();
        }

        //Orange Guy Access
        if (Input.GetButtonDown("7") || (Input.GetButtonDown("4C") && Switchready2))
        {
            if (orangeMovement != null)
                orangeMovement.enabled = true;
            orangeRb.drag = 1;
            orangeRb.gravityScale = 10;
            orangeGlow.Play();

            shrinkMovement.enabled = false;
            shrinkRb.drag = 40;
            shrinkRb.gravityScale = 80;
            shrinkGlow.Stop();

            bounceMovement.enabled = false;
            bounceRb.drag = 40;
            bounceRb.gravityScale = 80;
            bounceGlow.Stop();

            mainMovement.enabled = false;
            mainRb.drag = 40;
            mainRb.gravityScale = 80;
            mainGlow.Stop();

            iceMovement.enabled = false;
            iceRb.drag = 40;
            iceRb.gravityScale = 80;

            yGuyMovement.enabled = false;
            yGuyRb.constraints = RigidbodyConstraints2D.FreezeAll;
            yGuyGlow.Stop();

            greenMovement.enabled = false;
            greenRb.drag = 40;
            greenRb.gravityScale = 80;
            greenGlow.Stop();
            greenRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            yellowMovement.enabled = false;
            yellowRb.drag = 40;
            yellowRb.gravityScale = 80;
            yellowGlow.Stop();
        }

    }
        private void Switchmenu()
        {
            if (Input.GetButton("Shift"))
            {
                Switchready = true;
            }
            else
                Switchready = false;
        }

    private void Switchmenu2()
    {
        if (Input.GetButton("Shift2"))
        {
            Switchready2 = true;
        }
        else
            Switchready2 = false;
    }
}

