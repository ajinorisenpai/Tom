using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform      root;
    [SerializeField] private SpriteRenderer playerImage;
    [SerializeField] private float          animationSpeed = 1f;
    [SerializeField] private float          speed          = 4.0f;
    private                  Sprite[]       images;
    private                  int            frame          = 0;
    private                  int            animeState     = 0;
    private                  float          countTime      = 0f;
    const                    int            AnimeFrameCout = 3; //アニメーションの総フレーム数
    // Start is called before the first frame update


    private void Awake()
    {
        images                      = Resources.LoadAll<Sprite>("Player/");
        playerImage.sprite          = images[0];
        Application.targetFrameRate = 60;
    }


    // Update is called once per frame
    void Update()
    {
        int vx = 0;
        int vy = 0;


        if (Input.GetKey(KeyCode.DownArrow))
        {
            vy -= 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vx -= 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            vx += 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vy += 1;
        }

        int[,] directionAnimeIndexes = new int[3, 3] { { 7, 6, 5 }, { 2, -1, 4 }, { 3, 0, 1 } };

        if (vx != 0 || vy != 0)
        {
            animeState = directionAnimeIndexes[-vy + 1, vx + 1];
        }

        countTime += Time.deltaTime * animationSpeed;

        if (countTime > 1f)
        {
            countTime -= 1f;
            frame     =  (frame + 1) % (AnimeFrameCout * 2 - 2);
        }

        if (animeState != -1)
        {
            PlayerAnimationUpdate(animeState, frame);
        }

        root.position = new Vector3(root.position.x + vx * speed, root.position.y + vy * speed , root.position.z);
    }

    private void PlayerAnimationUpdate(int index, int frame)
    {
        int frameTime;
        if (frame >= AnimeFrameCout)
            frameTime = AnimeFrameCout * 2 - 2 - frame;
        else
            frameTime = frame;
        PlayerAnimationUpdate(animeState * AnimeFrameCout + frameTime);
    }

    private void PlayerAnimationUpdate(int index) { playerImage.sprite = images[index]; }
}