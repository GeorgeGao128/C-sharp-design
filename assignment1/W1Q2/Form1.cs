namespace W1Q2
{
    public partial class Form1 : Form
    {
        char sign1;
        double resultl;

        public Form1()
        {
            InitializeComponent();//初始化
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sign1 = '-';
            label3.Text = "-";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sign1 = '+';
            label3.Text = "+";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            sign1 = '/';
            label3.Text = "/";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);
            double result;
            switch (sign1)
            {
                case '+':
                    result = a + b;
                    label5.Text = result.ToString();
                    label7.Text = ("");
                    break;
                case '-':
                    result = a - b;
                    label5.Text = result.ToString();
                    label7.Text = ("");
                    break;
                case '*':
                    result = a * b;
                    label5.Text = result.ToString();
                    label7.Text = ("");
                    break;
                case '/':
                    if (b == 0)
                    {
                        label7.Text=("除数不可以为0");
                        label7.ForeColor = Color.Red;
                        return;
                    }
                    result = (double)a / b;
                    label5.Text = result.ToString();
                    label7.Text = ("");
                    break;
                default:
                    Console.WriteLine("不支持的运算符");
                    return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sign1 = '*';
            label3.Text = "*";
        }

        private void label3_Click(object sender, EventArgs e)
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
