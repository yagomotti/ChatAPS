using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using static System.Windows.Forms.LinkLabel;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text;

namespace ChatCliente
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            // Na saida da aplicação : desconectar
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
            this.txtLog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtLog_LinkClicked);

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    txtServidorIP.Text = ip.ToString();
                }
            }
        }


        // Trata o nome do usuário
        public event System.Windows.Forms.LinkClickedEventHandler LinkClicked;
        // public System.Diagnostics.Process p = new System.Diagnostics.Process();
        private string NomeUsuario = "Desconhecido";
        private StreamWriter stwEnviador;
        private StreamReader strReceptor;
        private TcpClient tcpServidor;
        // Necessário para atualizar o formulário com mensagens da outra thread
        private delegate void AtualizaLogCallBack(string strMensagem);
        // Necessário para definir o formulário para o estado "disconnected" de outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private Thread mensagemThread;
        private IPAddress enderecoIP;
        private bool Conectado;

        private void InicializaConexao()
        {

            // Trata o endereço IP informado em um objeto IPAdress
            enderecoIP = IPAddress.Parse(txtServidorIP.Text);
            // Inicia uma nova conexão TCP com o servidor chat
            tcpServidor = new TcpClient();
            tcpServidor.Connect(enderecoIP, 2502);

            // AJuda a verificar se estamos conectados ou não
            Conectado = true;

            // Prepara o formulário
            NomeUsuario = txtUsuario.Text;

            // Desabilita e habilita os campos apropriados
            txtServidorIP.Enabled = false;
            txtUsuario.Enabled = false;
            txtMensagem.Enabled = true;
            btnEnviar.Enabled = true;
            btnConectar.Text = "Desconectado";

            // Envia o nome do usuário ao servidor
            stwEnviador = new StreamWriter(tcpServidor.GetStream());
            stwEnviador.WriteLine(txtUsuario.Text);
            stwEnviador.Flush();

            //Inicia a thread para receber mensagens e nova comunicação
            mensagemThread = new Thread(new ThreadStart(RecebeMensagens));
            mensagemThread.Start();
        }

        private void RecebeMensagens()
        {
            // recebe a resposta do servidor
            strReceptor = new StreamReader(tcpServidor.GetStream());
            string ConResposta = strReceptor.ReadLine();
            // Se o primeiro caracater da resposta é 1 a conexão foi feita com sucesso
            if (ConResposta[0] == '1')
            {
                // Atualiza o formulário para informar que esta conectado
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
            }
            else // Se o primeiro caractere não for 1 a conexão falhou
            {
                string Motivo = "Não Conectado: ";
                // Extrai o motivo da mensagem resposta. O motivo começa no 3o caractere
                Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
                // Atualiza o formulário como o motivo da falha na conexão
                this.Invoke(new FechaConexaoCallBack(this.FechaConexao), new object[] { Motivo });
                // Sai do método
                return;
            }

            // Enquanto estiver conectado le as linhas que estão chegando do servidor
            while (Conectado)
            {
                // exibe mensagems no Textbox
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { strReceptor.ReadLine() });
            }
        }

        private void AtualizaLog(string strMensagem)
        {
            // Anexa texto ao final de cada linha
            txtLog.AppendText(strMensagem + "\r\n");
        }

        private void txtLog_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            var ps = new ProcessStartInfo(e.LinkText)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }



        private void EnviaMensagem()
        {
            try
            {
                if (txtMensagem.Lines.Length >= 1)
                {   //escreve a mensagem da caixa de texto
                    stwEnviador.WriteLine(txtMensagem.Text);
                    stwEnviador.Flush();
                    txtMensagem.Lines = null;
                }
                txtMensagem.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar mensagem! \n" + ex.Message);
            }
        }



        private void EnviaImagem(string filePath)
        {
            string name = filePath.Substring(filePath.LastIndexOf("\\"));
            string path = Directory.GetCurrentDirectory();
            string imageReceivedPath = path.Substring(0, path.IndexOf("ChatCliente")) + "Receber" + name;

            if (filePath.Length >= 1)
            {
                try
                {
                    byte[] arquivo = File.ReadAllBytes(filePath);

                    File.WriteAllBytes(imageReceivedPath, arquivo);
                    Uri uri = new Uri(imageReceivedPath);
                    stwEnviador.WriteLine("Arquivo enviado, link para visualizar: " + uri);
                    stwEnviador.Flush();
                    txtMensagem.Lines = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao enviar Imagem! \n" + ex.Message);
                }
            }
            txtMensagem.Text = "";
        }

        // Fecha a conexão com o servidor
        private void FechaConexao(string Motivo)
        {
            // Mostra o motivo porque a conexão encerrou
            txtLog.AppendText(Motivo + "\r\n");
            // Habilita e desabilita os controles apropriados no formulario
            txtServidorIP.Enabled = true;
            txtUsuario.Enabled = true;
            txtMensagem.Enabled = false;
            btnEnviar.Enabled = false;
            btnConectar.Text = "Conectado";

            // Fecha os objetos
            Conectado = false;
            stwEnviador.Close();
            strReceptor.Close();
            tcpServidor.Close();
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Conectado == true)
            {
                // Fecha as conexões, streams, etc...
                Conectado = false;
                stwEnviador.Close();
                strReceptor.Close();
                tcpServidor.Close();
            }
        }


        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Conectado == false)
                {
                    InicializaConexao();
                }
                else // Se esta conectado entao desconecta
                {
                    FechaConexao("Desconectado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar/desconectar do servidor!\n" + ex.Message);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviaMensagem();
        }

        private void txtMensagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                EnviaMensagem();
            }
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnAnexaImagem_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files (*.png)|*.png|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();
                }

                EnviaImagem(filePath);
            }
        }
    }
}
