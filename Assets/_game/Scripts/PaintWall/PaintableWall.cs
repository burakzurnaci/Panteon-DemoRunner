using System.Linq;
using System.Threading.Tasks;
using _game.Scripts.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace _game.Scripts.PaintWall
{
    public class PaintableWall : MonoBehaviour
    {
        
        [SerializeField] private RenderTexture rendTex;
        [SerializeField] private Slider slider;
        [SerializeField] private Text text;
        [Header("Brush")]
        [SerializeField] private GameObject brush;
        private Camera _pCam;
        [SerializeField] private float brushSize = 0.3f;
        [SerializeField] private float timerStart= .4f;
        private float _timer;
        private int _whiteAmount = 0;
        private Color _pixelColor;
        private bool find = true;

        void Start()
        {
            _pCam = GetComponentInChildren<Camera>();
            _timer = timerStart;
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = _pCam.ScreenPointToRay(Input.mousePosition); 
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                    go.transform.localScale = Vector3.one * brushSize;
                }
            }
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = timerStart;
                CalculatePercentage();
            }
        }

        async private void CalculatePercentage()
        {
            RenderTexture.active = rendTex;
            var texture2D = new Texture2D(rendTex.width, rendTex.height);
            texture2D.ReadPixels(new Rect(0, 0, rendTex.width, rendTex.height), 0, 0);
            
            var totalPixels = texture2D.width * texture2D.height;
            var pixels = texture2D.GetPixels(0, 0, texture2D.width, texture2D.height);
            if (find)
            {
                _pixelColor=texture2D.GetPixel(0, 0);
                find = false;
            }
            
            await GetWhiteAmount(pixels);
            
            var percentage = 100 - ((float)_whiteAmount / (float)totalPixels) *100;
            slider.value = percentage;
            text.text = Mathf.RoundToInt(percentage).ToString() + " / 100";

            if (!(percentage >= 100)) return;
            GameManager.Instance.LevelWin();
        }

        Task GetWhiteAmount(Color[] pixels)
        {
            _whiteAmount = 0;
            
            foreach (var pixel in pixels)
            {
                if(pixel==_pixelColor)
                {
                    _whiteAmount++;
                }
            }
            return Task.CompletedTask;
        }
        

        public void ResetWall()
        {
            var paints = GameObject.FindGameObjectsWithTag("Paint").ToList();
            foreach (var p in paints)
            {
                Destroy(p);
            }
            slider.value = 0;
            text.text = "00 / 100";
        }
    }
}
