using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeySprite.AutoKeyTask;

namespace KeySprite
{
    public partial class SpriteForm : Form
    {
        //private Point LinePosition, BtnParsePosition, ConfirmPosition;
        //private Point AddUserButtonPosition, AddUserConfirmPosition;
        //
        ////private Point BtnSearchPosition, RadioUserPosition, TbUserNamePosition, BtnSearchConfirmPosition, SearchResultPosition, BtnLogonPosition, BtnAddLogonPosition;
        //
        //private Point TbUserFullPathPosition, BtnAddLogonPosition;//56, 213
        int alreadyExecTimes;

        public SpriteForm()
        {
            InitializeComponent();

            //LinePosition = new Point(1111, 297);
            //BtnParsePosition = new Point(1111, 233);
            //ConfirmPosition = new Point(565, 517);

            numExecTime.Value = 1;

            //324, 224
            //AddUserButtonPosition = new Point(328, 228);
            //AddUserConfirmPosition = new Point(259, 758);

            //BtnSearchPosition = new Point(465, 225);
            //RadioUserPosition = new Point(508, 318);
            //TbUserNamePosition = new Point(904, 321);
            //BtnSearchConfirmPosition = new Point(1030, 318);
            //SearchResultPosition = new Point(482, 387);
            //BtnLogonPosition = new Point(565, 481);
            //BtnAddLogonPosition = new Point(419, 276);

            //TbUserFullPathPosition = new Point(104, 57);
            //BtnAddLogonPosition = new Point(56, 213);

            InvokeHelper.Instance.SetControl(this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            alreadyExecTimes = 0;
            Task.Factory.StartNew(() =>
            {
                IAutoKeyTask task = GetAutoKeyTask();
                task.Init(tbTaskArg.Text);
                Thread.Sleep(3000);
                do
                {
                    task.Execute(alreadyExecTimes);
                    this.Invoke(new Action(() =>
                    {
                        alreadyExecTimes++;
                        lbAlreadyExecTimes.Text = alreadyExecTimes.ToString();
                    }));
                } while (alreadyExecTimes < numExecTime.Value);
            });
        }

        private IAutoKeyTask GetAutoKeyTask()
        {
            //return new AddCupaaWJUsersTask();
            //return new AddCupaaFormsLogonTask();
            //return new ResetFormsPasswordTask();
            //return new ModifyCupaaFormsPasswordTask();
            return new InputRandomNumberForWebAppraisementTask();
        }

        //private void DoKeyForMessageService()
        //{
        //    for (int i = 0; i < numExecTime.Value; i++)
        //    {
        //        KeyService.Instance.MouseMove(LinePosition);
        //        Thread.Sleep(100);
        //        KeyService.Instance.Click();
        //        Thread.Sleep(100);


        //        KeyService.Instance.MouseMove(BtnParsePosition);
        //        Thread.Sleep(100);
        //        KeyService.Instance.Click();
        //        Thread.Sleep(500);
        //        KeyService.Instance.MouseMove(ConfirmPosition);
        //        Thread.Sleep(100);
        //        KeyService.Instance.Click();
        //        Thread.Sleep(3000);

        //        KeyService.Instance.Click();
        //        Thread.Sleep(5000);
        //    }
        //}

        //private void DoKeyForAddCupaaLogon()
        //{
        //    //while (numExecTime.Value < 71)
        //    //{
        //    string userName = "WJ420";
        //    string str = numExecTime.Value.ToString().PadLeft(2, '0');
        //    userName += str;

        //    KeyService.Instance.Click(BtnSearchPosition);
        //    Thread.Sleep(1000);

        //    KeyService.Instance.Click(RadioUserPosition);
        //    Thread.Sleep(1000);

        //    KeyService.Instance.Click(TbUserNamePosition);
        //    Thread.Sleep(100);
        //    KeyService.Instance.Input(userName);
        //    Thread.Sleep(100);
        //    KeyService.Instance.Click(BtnSearchConfirmPosition);
        //    Thread.Sleep(1500);

        //    KeyService.Instance.MouseMove(SearchResultPosition);
        //    Thread.Sleep(100);
        //    KeyService.Instance.RightClick();
        //    Thread.Sleep(300);

        //    KeyService.Instance.Click(BtnLogonPosition);
        //    Thread.Sleep(1500);
        //    KeyService.Instance.Click(BtnAddLogonPosition);

        //    this.Invoke(new Action(() =>
        //    {
        //        numExecTime.Value++;
        //    }));
        //    //}
        //}



        //private void DoKeyForAddCupaaLogon2()
        //{
        //    do
        //    {
        //        string userFullPath = "海关总署\\青岛海关\\黄岛海关\\查验处\\执勤武警\\WJ420";
        //        string userLogonName = "qdc\\WJ420";
        //        string str = numExecTime.Value.ToString().PadLeft(2, '0');
        //        userFullPath += str;
        //        userLogonName += str;
        //        this.Invoke(new Action(() =>
        //        {
        //            Clipboard.SetText(userFullPath);
        //        }));

        //        KeyService.Instance.Click(TbUserFullPathPosition);
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyDown("Ctrl");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyPress("A");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyPress("V");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyUp("Ctrl");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyPress("Enter");

        //        Thread.Sleep(2000);
        //        KeyService.Instance.Click(BtnAddLogonPosition);
        //        Thread.Sleep(500);

        //        this.Invoke(new Action(() =>
        //        {
        //            Clipboard.SetText(userLogonName);
        //        }));
        //        KeyService.Instance.KeyDown("Ctrl");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyPress("V");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyUp("Ctrl");

        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyPress("Tab");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyPress("Tab");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyPress("Space");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyDown("Alt");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyPress("O");
        //        Thread.Sleep(100);
        //        KeyService.Instance.KeyUp("Alt");

        //        Thread.Sleep(1000);
        //        KeyService.Instance.KeyPress("Space");
        //        Thread.Sleep(100);

        //        this.Invoke(new Action(() =>
        //        {
        //            numExecTime.Value++;
        //        }));
        //    } while (numExecTime.Value <= 66);
        //}
    }
}
