using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taslakOdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Kaydın ilerleyen sürecini açar.
        private void button_kayitDevam_Click(object sender, EventArgs e)
        {
            if (IsValidNickName(textBox_kullaniciAdi.Text) &&
                IsValidEmail(textBox_ePosta.Text) &&
                IsValidPassword(textBox_parola.Text, textBox_reParola.Text))
            {
                panel_kayitFirst.Visible = false;
                panel_kayitSecond.Visible = true;
                textBox_isim.Focus();
            };

        }

     
        //Bir önceki kayıt ekranını açar.
        private void button_kayitGeri_Click(object sender, EventArgs e)
        {
            panel_kayitSecond.Visible = false;
            panel_kayitFirst.Visible = true;
            textBox_kullaniciAdi.Focus();            
        }
        private void button_kayitTamamla_Click(object sender, EventArgs e)
        {
            if( IsValidName(textBox_isim.Text)      &&
                IsValidName(textBox_soyisim.Text)   &&
                IsValidTCKNO(textBox_tckNo.Text)    &&
                IsValidAdres(textBox_adres.Text)    &&
                IsValidTelNum(textBox_telefonNo.Text))
            {
                MessageBox.Show("Kayıt Başarılı","Oldu!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Tüm textboxların dolu olup olmadığına bakar. Ve butonları aktif eder.
        private void textBoxes_IsAllNotEmpity_First(object sender, EventArgs e)
        {
            if (textBox_kullaniciAdi.Text.Length > 0 &&
                    textBox_ePosta.Text.Length > 0 &&
                    textBox_parola.Text.Length > 0 &&
                    textBox_reParola.Text.Length > 0  )
            {
                button_kayitDevam.Enabled = true;
            }
            else
            {
                button_kayitDevam.Enabled = false;
            }
        }
        
        //Tüm textboxların dolu olup olmadığına bakar. Ve butonları aktif eder.
        private void textBoxes_IsAllNotEmpity_Second(object sender, EventArgs e)
        {
            if (textBox_isim.Text.Length > 0 &&
                    textBox_soyisim.Text.Length > 0 &&
                    textBox_tckNo.Text.Length > 0 &&
                    textBox_telefonNo.Text.Length > 0 &&
                    textBox_adres.Text.Length > 0)
            {
                button_kayitTamamla.Enabled = true;
            }
            else
            {
                button_kayitTamamla.Enabled = false;
            }
        }

        #region Validasyon Fonksiyonları
        //Parola geçerlilik testi yapar. İki parolayı kıyaslar eşitmi diye.
        private bool IsValidPassword(string pwdFirst, string pwdSecond)
        {

            bool onay = (pwdFirst == pwdSecond);
            if (!onay)
                MessageBox.Show("Parolalar eşleşmiyor. Lütfen parolanızı kontrol edin.","Parolalar eşleşmiyor!", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            return onay;
        }

        //Kullanıcı adının geçerli olup olmadıgını kontrol eder.
        private bool IsValidNickName(string nickName)
        {
            /**
             Yazan: Yakup Hamit Hancı
             Kullanıcı adı verisinin boşluk karakteri içerip içermediğine göre boolen bir onay değeri döndürür. 
             */

            bool onay = false;
            //Kullanıcı adında BOŞLUK olup olmadıgı kıyaslanıyor.
            onay = !nickName.Contains(' ');
            if( !onay)
                MessageBox.Show("Kullanıcı adınızda lütfen BOŞLUK karakteri kullanmayın.", "Geçersiz Kullanıcı Adı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            

            return onay;
        }

        //EPostanın geçerli olup olmadığına bakar.
        bool IsValidEmail(string email)
        {
            // Email onaylama v1
            //EMail verisi @ sembolü içeriyorsa onaylar. 
            bool onay = email.Contains("@");
            if( !onay )
                MessageBox.Show("Lütfen geçerli bir E-Posta giriniz.", "Geçersiz E-Posta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return onay;
        }

        //İsmin geçerli olup olmadıgına bakar.
        private bool IsValidName(string name)
        {
            //Sadece harf ve boşluk olacak şekilde kontrol edilir.
            Regex kontrol = new Regex(@"[\p{L} ]+$");
            bool onay = kontrol.IsMatch(name);
            if( !onay )
                MessageBox.Show("İsminizde sadece harf ve boşluk olabilir.","Uygunsuz isim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return onay;
        }

        //Tckimlik numarasının geçerli olup olmadıgı kontrol edilir.
        private bool IsValidTCKNO (string TCKNo)
        {
            bool onay = false;
            onay = TCKNo.Trim(' ').Length == 11;
            if( !onay )
                MessageBox.Show("Lütfen 11 Haneli TC Kimlik Numaranızı giriniz.", "Geçersiz TCKNo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return onay;
        }

        //Adres bilgisi girilmiş mi diye kontrol edilir. En az üç karakter.
        private bool IsValidAdres(string adres)
        {
            bool onay = false;
            onay = adres.Length > 3;
            if (!onay)
                MessageBox.Show("Adresinizi eksiksiz giriniz lütfen.", "Eksik Adres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return onay;
        }

        private bool IsValidTelNum(string telNum)
        {
            bool onay = false;
            onay = telNum.Trim(' ').Length == 10;
            if (!onay)
                MessageBox.Show("Lütfen telefon numaranızı eksiksiz giriniz.", "Hatalı telefon numarası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return onay;
        }
        #endregion
    }
}
