using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TcpNetClient
{
    public partial class Form1 : Form
    {
        #region 변수선언
        delegate void CrossThreadSet(Control ctrl, string strText);
        TcpClient client;
        string strUuid;
        #endregion

        #region 메소드

        public Form1()
        {
            InitializeComponent();
            this.strUuid = string.Empty;
            this.txtShowMsg.ForeColor = Color.Navy;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connection();
        }

        /// <summary>
        /// 서버연결
        /// </summary>
        private async void Connection()
        {
            // 서버 Connect
            string strServerHostIp = System.Configuration.ConfigurationManager.AppSettings["serverHostIp"];
            int intServerPort = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["serverPort"]);

            try
            {
                this.client = new TcpClient();
                this.client.Connect(strServerHostIp, intServerPort);
                this.txtShowMsg.Text += Environment.NewLine + "TcpClient Connected!";
            } catch (Exception ex)
            {
                Console.WriteLine("에러메시지:", ex);
                this.txtShowMsg.Text += Environment.NewLine + "서버와의 연결이 실패되었습니다!";
                this.client.Dispose();
                this.client = null;
                return;
            }

            // 메시지 Receive
            while (client != null)
            {
                try
                {
                    NetworkStream stream = this.client.GetStream();

                    byte[] bytReceiveMsg = new byte[this.client.ReceiveBufferSize];
                    int bytRead = await stream.ReadAsync(bytReceiveMsg, 0, bytReceiveMsg.Length);
                    string strReceiveJson = Encoding.UTF8.GetString(bytReceiveMsg, 0, bytRead);

                    // 리시브 받은 json 데이터 처리
                    ReceiveProcess(strReceiveJson);

                } catch (Exception ex)
                {
                    Console.WriteLine("에러메시지:", ex);
                    ClientClose();
                    break;
                }
            }
        }

        /// <summary>z
        /// 연결 끊기
        /// </summary>
        private void ClientClose()
        {
            if (this.client != null)
            {
                this.client.Close();
                this.client.Dispose();
                this.client = null;
                this.txtShowMsg.Text += Environment.NewLine + "TcpClient Disconnected!";
            }
            else
            {
                MessageBox.Show("서버에 연결되어 있지 않습니다!");
            }
        }

        private void CrossThreadSetHandler(Control ctrl, string strText)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new CrossThreadSet(CrossThreadSetHandler), ctrl, strText);
            }
            else
            {
                ctrl.Text += strText;
            }
        }
        #endregion

        #region 이벤트 핸들러
        /// <summary>
        /// 리시브 받은 json 데이터 처리
        /// </summary>
        /// <param name="strReceiveData">json 스트링 데이터</param>
        private void ReceiveProcess(string strReceiveData)
        {
            JToken resultJson = JObject.Parse(strReceiveData);
            JToken jData = resultJson["data"];
            string strDefault = jData.ToString();
            string strAction = resultJson["action"].ToString();


            switch (strAction)
            {
                // 클라이언트에서 서버 연결시
                case "client.msg.connected":
                    {
                        this.strUuid = strDefault;
                        this.txtShowMsg.Text += Environment.NewLine + "Connect uuid:" + strDefault;

                        break;
                    }
                // 서버로부터 메시지 받았을 때
                case "client.msg.receive":
                    {
                        this.txtShowMsg.Text += Environment.NewLine + "Received Msg:" + strDefault;

                        break;
                    }
            }

            this.txtShowMsg.SelectionStart = this.txtShowMsg.TextLength;
            this.txtShowMsg.ScrollToCaret();
        }

        /// <summary>
        /// OBJECT -> JSON STRING 로 변환
        /// </summary>
        private string ToJsonString(object objJson)
        {
            return JsonConvert.SerializeObject(objJson);
        }

        /// <summary>
        /// 연결끊기 이벤트 핸들러
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            ClientClose();
        }

        /// <summary>
        /// 메시지 보내기
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                string strMsg = this.txtSendMsg.Text;
                this.txtSendMsg.Text = string.Empty;
                NetworkStream stream = client.GetStream();
                byte[] bytSendMsg = Encoding.UTF8.GetBytes(strMsg);
                stream.Write(bytSendMsg, 0, bytSendMsg.Length);
                this.txtShowMsg.Text += Environment.NewLine + "Send: " + strMsg;
                this.txtShowMsg.SelectionStart = this.txtShowMsg.TextLength;
                this.txtShowMsg.ScrollToCaret();
            }
            else
            {
                MessageBox.Show("서버에 연결되어 있지 않습니다!");
            }
        }
        #endregion
    }
}
