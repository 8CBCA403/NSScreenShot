using SysBot.Base;
using NSScreenShot.Properties;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace NSScreenShot
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            IP_Box.Text = Properties.Settings.Default.SwitchIP;
            IP_Box.TextChanged += IP_Box_TextChanged;
        }
        private readonly static SwitchConnectionConfig Config = new() { Protocol = SwitchProtocol.WiFi, IP = Settings.Default.SwitchIP, Port = 6000 };
        private readonly static SwitchSocketAsync SwitchConnection = new(Config);
        private CancellationTokenSource Source = new();

        private void Connect_BTN_Click(object sender, EventArgs e)
        {
            SwitchConnection.Connect();

            if (SwitchConnection.Connected)
            {
                Debug_Box.Text += ("连上了" + Environment.NewLine);
                Shot_BTN.Enabled = true;

            }
            else
            {
                Debug_Box.Text += ("没连上" + Environment.NewLine);
                Shot_BTN.Enabled = false;
            }
        }

        private void IP_Box_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Settings.Default.SwitchIP = textBox.Text;
            Config.IP = textBox.Text;
            Settings.Default.Save();
        }

        private void Disconnect_BTN_Click(object sender, EventArgs e)
        {
            SwitchConnection.Disconnect();
            if (!SwitchConnection.Connected)
            {
                Debug_Box.Text += ("断开了" + Environment.NewLine);
                Shot_BTN.Enabled = false;
            }
        }

        private async void Shot_BTN_Click(object sender, EventArgs e)
        {
            var byteArr = await SwitchConnection.Screengrab(Source.Token).ConfigureAwait(false) ?? Array.Empty<byte>();
            var image = ByteToImage(byteArr);
            var destimgae = ResizeImage(image, 1920,1080);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, $"{Name_TB.Text}.png");
            destimgae.Save(filePath, ImageFormat.Png);
            destimgae.Dispose();

            Debug_Box.Text += ("图片保存在" + filePath + Environment.NewLine);
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

       
    }
}