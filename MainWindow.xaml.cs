using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace ToDoList
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon = null;
        public MainWindow()
        {
            InitializeComponent();
            this.Top = 5;
            this.Left = SystemParameters.PrimaryScreenWidth-300;
            InitialTray(); //最小化至托盘
        }
        private void InitialTray()
        {
            //隐藏主窗体
            //this.Visibility = Visibility.Hidden;
            //设置托盘的各个属性
            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.Text = "ToDoList";
            _notifyIcon.BalloonTipText = "ToDoListApp";//托盘气泡显示内容
            _notifyIcon.Visible = true;//托盘按钮是否可见
            _notifyIcon.Icon = new Icon(@"todolist.ico");//托盘中显示的图标
            _notifyIcon.ShowBalloonTip(2000);//托盘气泡显示时间
            _notifyIcon.MouseClick += _notifyIcon_MouseClick1; ;
            //窗体状态改变时触发
            System.Windows.Forms.MenuItem exit = new System.Windows.Forms.MenuItem("退出");
            exit.Click += exit_Click;
            System.Windows.Forms.MenuItem about = new System.Windows.Forms.MenuItem("关于");
            about.Click += About_Click; ;
            System.Windows.Forms.MenuItem[] childen = new System.Windows.Forms.MenuItem[] { about,exit };
            this._notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(childen);
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("about");
        }

        private void _notifyIcon_MouseClick1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (this.Visibility == Visibility.Visible)
                {
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.Visibility = Visibility.Visible;
                    this.Activate();
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
