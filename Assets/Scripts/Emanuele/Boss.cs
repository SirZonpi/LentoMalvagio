using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public int rand;

    //public BarraBoss hpBar;

    public BossStateManager stateman;

    public GameObject tentacoli;

    public float coolDownTime=3;
    public float nextTimeFire=1;

    public Quaternion startRot;

    public Transform spellPoint;
    public GameObject spellprefab;

    //public Player player;

    public GameObject vittoriaPanel;


    public void BossCastSpell()
    {
        GameObject spell = Instantiate(spellprefab, spellPoint.transform.position, Quaternion.identity, null);

        Rigidbody rb = spell.GetComponent<Rigidbody>();
        rb.velocity = new Vector2(0, 0);

        rb.AddForce(transform.forward * 8, ForceMode.Impulse);

        SpellBoss sb = spell.GetComponent<SpellBoss>();
        sb.attacco = attaccoMagico;

        Destroy(spell, 5f);
    }

    public void Cooldown()
    {
        if(Time.time > nextTimeFire)
        {
            rand = Random.Range(0, stateman.allStates.Length);

            stateman.SwitchState(stateman.allStates[rand]);
            nextTimeFire = Time.time + coolDownTime;
        }
    }

   

    public void BossGira()
    {
        float time = 5;
        float t = 0;

        if (t < time)
        {
            t += Time.deltaTime;

            transform.Rotate(Vector3.up * (50 * Time.deltaTime));
        }
        else { transform.rotation = startRot; }

        

    }

    public override void TakeDamage(int amount)
    {
        //hpBar.SetHealth(Health);
        base.TakeDamage(amount);
    }

    public override void KillEnemy()
    {
        vittoriaPanel.SetActive(true);
        Cursor.visible = true;
        base.KillEnemy();
    }

    void Start()
    {
        startRot = transform.rotation;
        player = GameManager.instance.player;

        vittoriaPanel = GameManager.instance.panelVittoria;

        //hpBar.SetMaxHealth(maxHealth);

    }

   

    private void Update()
    {
        if (player.Health <= 0)
        {
            this.RestoreHealth();
            //OnHealthChanged(maxHealth);
        }
    }

}
