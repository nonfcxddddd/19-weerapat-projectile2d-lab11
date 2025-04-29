using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public ParticleSystem pickupEffect;
    public AudioClip collector; // ���§���ⴴ
    private AudioSource audioSource;

    // ��ҧ�ԧ UI ����Ѻ�ʴ��ӹǹྪ��������� (TextMesh Pro)
    public TextMeshProUGUI gemText;
    public TextMeshProUGUI cheeryText;

    // �纨ӹǹ�������
    private int gemValue = 0;
    private int cheeryValue = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��Ǩ������ѵ����������� item
        if (collision.transform.parent != null && collision.transform.parent.name == "item")
        {
            // ��Ǩ�ͺ��Ҫ�Դ�ͧ������� "Gem" ���� "Cheery"
            if (collision.gameObject.CompareTag("Gem"))
            {
                gemValue += 2;  // ����� Gem ������� 2
            }
            else if (collision.gameObject.CompareTag("Cheery"))
            {
                cheeryValue += 1;  // ����� Cheery ������� 1
            }

            // �Ѿവ��� UI
            gemText.text = "" + gemValue.ToString();
            cheeryText.text = "" + cheeryValue.ToString();

            // ����Ϳ࿡��
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, collision.transform.position, Quaternion.identity);
                audioSource.PlayOneShot(collector);
            }

            // ź��������������
            Destroy(collision.gameObject);
        }
    }
}
