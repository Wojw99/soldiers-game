using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierShooting : MonoBehaviour
{
    public Sprite shootingSoldierSprite;
    public Sprite commonSoldierSprite;
    public GameObject defaultShotPrefab;
    public GameObject shotPrefab;
    public GameObject shotStartPoint;
    public GameObject granadePrefab;
    public int shootingForce;

    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    SoldierStatistics soldierStatistics;

    float timeToShot = 0f;
    float timeToRealease = 0f;
    bool keyUp = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        soldierStatistics = GetComponent<SoldierStatistics>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            keyUp = false;
            spriteRenderer.sprite = shootingSoldierSprite;

            if (timeToShot <= 0 && Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) > 0.65)
            {
                Shot();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) 
            && Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) > 0.65
            && soldierStatistics.granades.HasGranade())
        {
            ThrowGranade();
            soldierStatistics.granades.RemoveGranade();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            keyUp = true;
            timeToRealease = 0.35f;
        }

        if(timeToShot > 0) timeToShot -= Time.deltaTime;

        if(keyUp && timeToRealease <= 0)
        {
            keyUp = false;
            spriteRenderer.sprite = commonSoldierSprite;
        }
        else if(keyUp)
        {
            timeToRealease -= Time.deltaTime;
        }
    }

    void ThrowGranade()
    {
        Vector2 shotPosition = shotStartPoint.transform.position;
        GameObject shotObject = Instantiate(granadePrefab, new Vector3(shotPosition.x, shotPosition.y, 2), transform.rotation);
        Granade granade = shotObject.GetComponent<Granade>();

        granade.LaunchToTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    void Shot()
    {
        Vector2 shotPosition = shotStartPoint.transform.position;
        GameObject shotObject = Instantiate(shotPrefab, new Vector3(shotPosition.x, shotPosition.y, 2), transform.rotation);
        Projectile projectile = shotObject.GetComponent<Projectile>();

        projectile.Launch(shootingForce);
        audioSource.PlayOneShot(projectile.sound);

        timeToShot = 0.1f;
    }
}
