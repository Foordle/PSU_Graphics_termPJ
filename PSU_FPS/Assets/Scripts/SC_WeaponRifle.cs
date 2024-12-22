using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_WeaponRifle : MonoBehaviour
{
    [Header("weapon setting")]
    [SerializeField]
    private WeaponSetting weaponSetting;

    private float lastAttackTime = 0;


    [Header("weapon Audio Clips")]
    [SerializeField]
    private AudioClip AC_TakeOutWeapon;

    private AudioSource audioSC;
    private SC_PlayerAnimatorControler animatorControler;

    [Header("Bullets")]
    public Rigidbody Bullet; // �Ѿ� Prefab
    public AudioClip GunShot; // �Ѿ� �߻� �Ҹ�
    public float BulletSpeed; // �Ѿ� �ӵ�
    private Transform bulletSpawnPoint; // �Ѿ� �߻� ��ġ

    public int MaxAmmo => weaponSetting.maxAmmo;
    public int CurrentAmmo => weaponSetting.currentAmmo;

    private void PlaySound(AudioClip NewCips)
    {
        audioSC.Stop();
        audioSC.clip = NewCips;
        audioSC.Play();
    }

    private void Awake()
    {
        audioSC = GetComponent<AudioSource>();
        animatorControler = GetComponentInParent<SC_PlayerAnimatorControler>();

        bulletSpawnPoint = transform.Find("arms/assault_rifle_01/BulletSpawnPoint");
    }


    private void OnEnable()
    {
        PlaySound(AC_TakeOutWeapon);
    }
    void Update()
    {
        
    }

    public void StartWeaponAction(int type = 0)
    {
      if(weaponSetting.isAuto)
            StartCoroutine("OnAttackLoop");
        
        else
            OnAttack();
        
    }

    public void StopWeaponAction(int type = 0)
    {
        if (weaponSetting.isAuto)
            StopCoroutine("OnAttackLoop");

        animatorControler.ResetTrigger("IsAttack");

    }

    private IEnumerator OnAttackLoop()
    {
        while (true)
        {
            OnAttack();
            yield return null;
        }
    }

    public void ChangeAuto()
    {
        // isAuto ���� ���
        weaponSetting.isAuto = !weaponSetting.isAuto;
        Debug.Log($"Weapon Auto Mode Toggled: {weaponSetting.isAuto}");
    }


    public void OnAttack()
    {
        if (weaponSetting.currentAmmo > 0)
        {
            if (Time.time - lastAttackTime > 1 / weaponSetting.attackSpeed)
            {
                if (animatorControler.AnimeMoveSpeed > 0.5f) return;

                lastAttackTime = Time.time;

                weaponSetting.currentAmmo -= 1;
                animatorControler.SetTrigger("IsAttack");

                animatorControler.PlayAnime("fireRifle", -1, 0);


                if (bulletSpawnPoint != null && Bullet != null)
                {
                    //Debug.Log("�Ѿ� ���� ����");
                    Quaternion adjustedRotation = bulletSpawnPoint.rotation * Quaternion.Euler(90, 0, 0);

                    Rigidbody rb = Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    // �ùٸ� �������� �߻�
                    Vector3 shootDirection = bulletSpawnPoint.forward; // bulletSpawnPoint�� forward ����
                    rb.velocity = shootDirection * BulletSpeed;

                    AudioSource.PlayClipAtPoint(GunShot, bulletSpawnPoint.position);
                }
                else
                {
                    // Debug.LogError($"�Ѿ� ���� ����: BulletSpawnPoint = {bulletSpawnPoint}, Bullet = {Bullet}");
                }

            }
        }
        else
        {
            // Debog.LogError("źâ ����");
        }
    }
}
