using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //Giriş çıkış için

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.yandex.com");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.yahoo.com");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.bing.com");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongDateString();
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void yeşilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGreen;
        }

        private void maviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void sarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
        }

        private void wwwgooglecomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wwwyoutubecomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wwwyoutubecomToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.youtube.com");
        }

        private void wwwtwittercomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.mynet.com");
        }

        private void wwwamazoncomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.amazon.com");
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sayfaBaşlığıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(webBrowser1.DocumentTitle.ToString());
            
        }

        private void sayfaKaynağıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(webBrowser1.DocumentText);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox1.Text= webBrowser1.Url.ToString();
            string zaman = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
            string zaman2 = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

            //dosyayı oluşturma kısmı
            FileStream f = new FileStream("Gecmis.txt", FileMode.Append); //dosyanın oluşturulduğu ve buraya veri eklenebildiğini gösteriyor.
            StreamWriter yaz = new StreamWriter(f); //içine yazılabiliyor.
            yaz.WriteLine(zaman + "/" + zaman2 + "/" + webBrowser1.Url); //yukarıda yazdığımız zamanlara göre girilen siteleri yazdıracak.
            yaz.Close();
            GecmisGoster();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = webBrowser1.StatusText;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                toolStripProgressBar1.Maximum = Convert.ToInt32(e.MaximumProgress); //durum çubuğunun maksimum derecesi
                toolStripProgressBar1.Value = Convert.ToInt32(e.CurrentProgress); //durum çubuğunun o anki değeri
            }
            catch (Exception)
            {
                toolStripProgressBar1.Minimum = 0;
                
            }
        }

        private void geçmişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
          
        }

        private void GecmisGoster()
        {
            listBox1.Items.Clear();
            StreamReader dosya = new StreamReader("Gecmis.txt"); //bu adda bir metin belgesi oluşturdu.
            while (!dosya.EndOfStream) //dosya okunma süresi bitene kadar
            {
                listBox1.Items.Add(dosya.ReadLine()); //listboxa okunanları ekle
            }
            dosya.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            GecmisGoster();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            StreamWriter dosya = new StreamWriter("Gecmis.txt");
            dosya.Write(" ");
            dosya.Close();
            GecmisGoster();
        }
    }
}
