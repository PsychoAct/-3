using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static WindowsFormsApp1.CompNetw;
using static WindowsFormsApp1.MovingObject;
using static WindowsFormsApp1.Modeling;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        public List<CompNetw> LCom_Net = new List<CompNetw>();
        public List<MovingObject> LMov_Obj = new List<MovingObject>();
        
        
        public void Form1_Load(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
           
          
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void label1_Click(object sender, EventArgs e)
        {
            
        }

        public void label2_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
           
           
        }

        public void label3_Click(object sender, EventArgs e)
        {

        }

        public void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            
        }


        public void label3_Click_1(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            Modeling Model = new Modeling();          
            try
            {
              
               int number_of_compnetw = Convert.ToInt32(textBox1.Text);
               int number_of_movobj = Convert.ToInt32(textBox2.Text);
               int deltatime = Convert.ToInt32(textBox3.Text);

                int Coordinate;
                Random rnd = new Random();
                for (int i = 0; i < number_of_compnetw; i++)
                {
                    Coordinate = rnd.Next(1, 100);
                    CompNetw CompNet1 = new CompNetw(i+1, Coordinate, 0);
                    LCom_Net.Add(CompNet1);

                }
                for (int i = 0; i < number_of_movobj; i++)
                {
                    Coordinate = rnd.Next(1, 100);
                    MovingObject MovObj1 = new MovingObject(i+1, Coordinate);
                    LMov_Obj.Add(MovObj1);

                }
                LMov_Obj.Sort((a, b) => a.coordinate.CompareTo(b.coordinate));
                LCom_Net.Sort((a, b) => a.coordinate.CompareTo(b.coordinate));//Функция сортировки листа по координатам, для того чтобы у нас обьект подключался к лучшему по качеству связи сети
                Model.startmodeling(LCom_Net, LMov_Obj, deltatime); 
                textBox5.Text = Model.sumconnection.ToString();
                string specifier;
                CultureInfo culture;
                specifier = "F";
                culture = CultureInfo.CreateSpecificCulture("fr-FR"); //2 знака после запятой
                textBox6.Text = Model.UcrSig.ToString(specifier, culture);      //ср уровень сигнала у объекта
                textBox7.Text = Model.UcrCol.ToString(specifier, culture);    // ср кол-во обьектов подключ к сети
              

                for (int i = 0; i < Model.AllCon.Count; i++)
                {
                    textBox4.Text += Model.AllCon[i].ToString() + Environment.NewLine;
                }

                Model.sumconnection = 0;
                Model.AllCon.Clear();
                Model.AllConN = 0;
                LCom_Net.Clear();
                LMov_Obj.Clear();
                

            }
            catch (Exception ex) 
            {
               MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                string caption = "Ошибка";
                result = MessageBox.Show("Ошибка", caption, buttons);

           }
          


        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
