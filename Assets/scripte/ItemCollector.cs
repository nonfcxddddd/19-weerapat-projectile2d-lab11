using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public ParticleSystem pickupEffect;
    public AudioClip collector; // เสียงกระโดด
    private AudioSource audioSource;

    // อ้างอิง UI สำหรับแสดงจำนวนเพชรและเชอรี่ (TextMesh Pro)
    public TextMeshProUGUI gemText;
    public TextMeshProUGUI cheeryText;

    // เก็บจำนวนที่เก็บได้
    private int gemValue = 0;
    private int cheeryValue = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจว่าเป็นวัตถุภายใต้กลุ่ม item
        if (collision.transform.parent != null && collision.transform.parent.name == "item")
        {
            // ตรวจสอบว่าชนิดของไอเท็มเป็น "Gem" หรือ "Cheery"
            if (collision.gameObject.CompareTag("Gem"))
            {
                gemValue += 2;  // ถ้าเป็น Gem เพิ่มค่า 2
            }
            else if (collision.gameObject.CompareTag("Cheery"))
            {
                cheeryValue += 1;  // ถ้าเป็น Cheery เพิ่มค่า 1
            }

            // อัพเดตค่า UI
            gemText.text = "" + gemValue.ToString();
            cheeryText.text = "" + cheeryValue.ToString();

            // เล่นเอฟเฟกต์
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, collision.transform.position, Quaternion.identity);
                audioSource.PlayOneShot(collector);
            }

            // ลบไอเท็มที่เก็บแล้ว
            Destroy(collision.gameObject);
        }
    }
}
